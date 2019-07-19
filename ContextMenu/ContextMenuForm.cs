/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuForm.cs
 *  Description  :  Context menu form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UIForm;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Context menu form.
    /// </summary>
    [AddComponentMenu("MGS/ContextMenu/ContextMenuForm")]
    [UIFormInfo(UIFromPattern.Single, "ContextMenu")]
    public class ContextMenuForm : MonoUIForm, IContextMenuForm
    {
        #region Field and Property
        /// <summary>
        /// Margin of menu form base on screen.
        /// </summary>
        [Tooltip("Margin of menu form base on screen.")]
        [SerializeField]
        protected RectOffset margin = new RectOffset(5, 5, 5, 5);

        /// <summary>
        /// Prefab of menu item to create clone.
        /// </summary>
        [Tooltip("Prefab of menu item to create clone.")]
        [SerializeField]
        protected GameObject itemPrefab;

        /// <summary>
        /// Margin of menu form base on screen.
        /// </summary>
        public RectOffset Margin
        {
            set { margin = value; }
            get { return margin; }
        }

        /// <summary>
        /// List of context menu items.
        /// </summary>
        protected List<IContextMenuItem> items = new List<IContextMenuItem>();

        /// <summary>
        /// Handler of context menu.
        /// </summary>
        protected IContextMenuHandler handler;
        #endregion

        #region Protected Method
        /// <summary>
        /// Reset menu form.
        /// </summary>
        protected virtual void Reset()
        {
            rectTransform.pivot = Text.GetTextAnchorPivot(TextAnchor.UpperLeft);
        }

        /// <summary>
        /// On menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        protected virtual void OnItemClick(string tag)
        {
            Close();
            handler.OnMenuItemClick(tag);
        }

        /// <summary>
        /// Refresh items of menu base on item datas.
        /// </summary>
        /// <param name="itemDatas">Data of menu items.</param>
        protected void RefreshItems(ICollection<ContextMenuItemData> itemDatas)
        {
            RequireItems(itemDatas.Count);

            var index = 0;
            foreach (var itemData in itemDatas)
            {
                items[index].Refresh(itemData);
                index++;
            }
        }

        /// <summary>
        /// Require a sufficient number of items.
        /// </summary>
        /// <param name="expectedCount">Count of expected items.</param>
        protected void RequireItems(int expectedCount)
        {
            while (items.Count < expectedCount)
            {
                var newItem = Instantiate(itemPrefab);
                var menuItem = newItem.GetComponent<IContextMenuItem>();

                menuItem.OnClick.AddListener(OnItemClick);
                items.Add(menuItem);
            }

            var currentCount = items.Count;
            while (currentCount > expectedCount)
            {
                var item = items[currentCount - 1];
                if (item.IsOpen)
                {
                    item.Close();
                }
                currentCount--;
            }
        }

        /// <summary>
        /// Enable all menu items.
        /// </summary>
        protected void EnableItems()
        {
            foreach (var item in items)
            {
                if (!item.Interactable)
                {
                    item.Interactable = true;
                }
            }
        }

        /// <summary>
        /// Disable menu items by tags.
        /// </summary>
        /// <param name="tags">Tags of menu items.</param>
        protected void DisableItems(IEnumerable<string> tags)
        {
            var targetTags = new List<string>(tags);
            var targetItems = items.FindAll(item =>
            {
                return targetTags.Contains(item.Tag);
            });

            foreach (var item in targetItems)
            {
                if (item.Interactable)
                {
                    item.Interactable = false;
                }
            }
        }

        /// <summary>
        /// Set menu form position.
        /// </summary>
        /// <param name="screenPos">Target screen position of menu form.</param>
        protected void SetFormPosition(Vector2 screenPos)
        {
            rectTransform.anchoredPosition = GetPreferredPosition(screenPos);
        }

        /// <summary>
        /// Get preferred position of menu form base on screen.
        /// </summary>
        /// <param name="screenPos">Target screen position of menu form.</param>
        /// <returns>Preferred position of menu form.</returns>
        protected virtual Vector2 GetPreferredPosition(Vector2 screenPos)
        {
            var rootTrans = transform as RectTransform;
            var halfWidth = rootTrans.rect.width * 0.5f;
            var halfHeight = rootTrans.rect.height * 0.5f;

            var newX = screenPos.x < Screen.width - rootTrans.rect.width ? screenPos.x + halfWidth : Screen.width - halfWidth;
            var newY = screenPos.y < rootTrans.rect.height ? screenPos.y + halfHeight : screenPos.y - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize menu form.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            var preCreateItems = GetComponentsInChildren<IContextMenuItem>();
            foreach (var item in preCreateItems)
            {
                item.OnClick.AddListener(OnItemClick);
                items.Add(item);
            }
        }

        /// <summary>
        /// Refresh context menu form.
        /// </summary>
        /// <param name="data">Data for context menu form, type is Vector2 or ContextMenuFormInfo or ContextMenuFormData.</param>
        public override void Refresh(object data)
        {
            if (data is Vector2 position)
            {
                SetFormPosition(position);
            }
            else if (data is ContextMenuFormInfo formInfo)
            {
                SetFormPosition(formInfo.position);
                DisableItems(formInfo.disables);
            }
            else if (data is ContextMenuFormData formData)
            {
                SetFormPosition(formData.position);
                RefreshItems(formData.items);
            }
            else
            {
                LogUtility.LogError(0, "Refresh context menu form failed: The type of data is not Vector2 or ContextMenuFormInfo or ContextMenuFormData.");
            }
        }

        /// <summary>
        /// Close context menu form.
        /// </summary>
        /// <param name="dispose">Dispose form on close?</param>
        public override void Close(bool dispose = false)
        {
            base.Close(dispose);

            if (!dispose)
            {
                EnableItems();
            }
        }
        #endregion
    }

    /// <summary>
    /// Info of contex menu form.
    /// </summary>
    public struct ContextMenuFormInfo
    {
        /// <summary>
        /// Screen position to display menu form.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Tags of disable menu items.
        /// </summary>
        public IEnumerable<string> disables;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position">Screen position to display menu form.</param>
        /// <param name="disables">Tags of disable menu items.</param>
        public ContextMenuFormInfo(Vector2 position, IEnumerable<string> disables)
        {
            this.position = position;
            this.disables = disables;
        }
    }

    /// <summary>
    /// Data of contex menu form.
    /// </summary>
    public struct ContextMenuFormData
    {
        /// <summary>
        /// Screen position to display menu form.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Data of menu items.
        /// </summary>
        public ICollection<ContextMenuItemData> items;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position">Screen position to display menu form.</param>
        /// <param name="items">Data of menu items.</param>
        public ContextMenuFormData(Vector2 position, ICollection<ContextMenuItemData> items)
        {
            this.position = position;
            this.items = items;
        }
    }
}