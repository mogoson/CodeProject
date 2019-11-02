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
        /// Prefab of menu item to create clone.
        /// </summary>
        [Tooltip("Prefab of menu item to create clone.")]
        [SerializeField]
        protected GameObject itemPrefab;

        /// <summary>
        /// Prefab of menu separator to create clone.
        /// </summary>
        [Tooltip("Prefab of menu separator to create clone.")]
        [SerializeField]
        protected GameObject separatorPrefab;

        /// <summary>
        /// Handler of contex menu form.
        /// </summary>
        public IContextMenuFormHandler Handler { set; get; }

        /// <summary>
        /// List of context menu items.
        /// </summary>
        protected List<IContextMenuItem> items = new List<IContextMenuItem>();

        /// <summary>
        /// List of context menu separators.
        /// </summary>
        protected List<IContextMenuSeparator> separators = new List<IContextMenuSeparator>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Initialize menu form.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            RectTrans.anchorMin = RectTrans.anchorMax = Vector2.zero;
            var preCreateItems = GetComponentsInChildren<IContextMenuItem>();
            foreach (var item in preCreateItems)
            {
                item.OnClick.AddListener(OnItemClick);
                items.Add(item);
            }

            var preCreateSeparators = GetComponentsInChildren<IContextMenuSeparator>();
            foreach (var separator in preCreateSeparators)
            {
                separators.Add(separator);
            }
        }

        /// <summary>
        /// On menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        protected virtual void OnItemClick(string tag)
        {
            Close();

            if (Handler == null)
            {
                LogUtility.LogWarning(0, "Do nothing on menu item click: The handler of menu form is null.");
                return;
            }
            Handler.OnMenuItemClick(tag);
        }

        /// <summary>
        /// Create menu item.
        /// </summary>
        /// <returns>New menu item.</returns>
        protected IContextMenuItem CreateItem()
        {
            var newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(transform);

            var menuItem = newItem.GetComponent<IContextMenuItem>();
            menuItem.OnClick.AddListener(OnItemClick);
            items.Add(menuItem);
            return menuItem;
        }

        /// <summary>
        /// Create menu separator.
        /// </summary>
        /// <returns>New menu separator.</returns>
        protected IContextMenuSeparator CreateSeparator()
        {
            var newSeparator = Instantiate(separatorPrefab);
            newSeparator.transform.SetParent(transform);

            var menuSeparator = newSeparator.GetComponent<IContextMenuSeparator>();
            separators.Add(menuSeparator);
            return menuSeparator;
        }

        /// <summary>
        /// Hide menu items.
        /// </summary>
        /// <param name="index">Start index.</param>
        /// <param name="count">Hide count.</param>
        protected void HideItems(int index, int count)
        {
            var rangeItems = items.GetRange(index, count);
            foreach (var item in rangeItems)
            {
                if (item.IsOpen)
                {
                    item.Close();
                }
            }
        }

        /// <summary>
        /// Hide menu separators.
        /// </summary>
        /// <param name="index">Start index.</param>
        /// <param name="count">Hide count.</param>
        protected void HideSeparators(int index, int count)
        {
            var rangeSeparators = separators.GetRange(index, count);
            foreach (var separator in rangeSeparators)
            {
                if (separator.IsOpen)
                {
                    separator.Close();
                }
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
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh the elements of menu base on element datas.
        /// </summary>
        /// <param name="elementDatas">Data of menu elements.</param>
        public void RefreshElements(IEnumerable<ContextMenuElementData> elementDatas)
        {
            if (elementDatas == null)
            {
                return;
            }

            int itemIndex = 0, separatorIndex = 0, elementIndex = 0;
            foreach (var elementData in elementDatas)
            {
                IContextMenuElement menuElement;
                if (elementData.ElementType == ContextMenuElementType.ContextMenuItem)
                {
                    if (itemIndex >= items.Count)
                    {
                        menuElement = CreateItem();
                    }
                    else
                    {
                        menuElement = items[itemIndex];
                    }
                    itemIndex++;
                }
                else
                {
                    if (separatorIndex >= separators.Count)
                    {
                        menuElement = CreateSeparator();
                    }
                    else
                    {
                        menuElement = separators[separatorIndex];
                    }
                    separatorIndex++;
                }

                menuElement.RectTrans.SetSiblingIndex(elementIndex);
                menuElement.Refresh(elementData);
                menuElement.Open();
                elementIndex++;
            }

            //Hide surplus menu items.
            if (itemIndex < items.Count)
            {
                HideItems(itemIndex, items.Count - itemIndex);
            }

            //Hide surplus menu separators.
            if (separatorIndex < separators.Count)
            {
                HideSeparators(separatorIndex, separators.Count - separatorIndex);
            }

#if UNITY_5_3_OR_NEWER
            LayoutRebuilder.ForceRebuildLayoutImmediate(RectTrans);
#endif
        }

        /// <summary>
        /// Disable menu items by tags.
        /// </summary>
        /// <param name="tags">Tags of menu items.</param>
        public void DisableItems(IEnumerable<string> tags)
        {
            if (tags == null)
            {
                return;
            }

            //Find target items.
            var targetTags = new List<string>(tags);
            var targetItems = items.FindAll(item =>
            {
                return targetTags.Contains(item.Tag);
            });

            //Set items interactable as false.
            foreach (var item in targetItems)
            {
                if (item.Interactable)
                {
                    item.Interactable = false;
                }
            }

#if UNITY_5_3_OR_NEWER
            LayoutRebuilder.ForceRebuildLayoutImmediate(RectTrans);
#endif
        }

        /// <summary>
        /// Set form anchored position.
        /// </summary>
        /// <param name="anchoredPosition">Target anchored position of form.</param>
        public override void SetPosition(Vector2 anchoredPosition)
        {
            //Default left align.
            var xPivot = 0.0f;
            var xPos = anchoredPosition.x;
            if (xPos <= margin.left)
            {
                xPos = margin.left;
            }
            else
            {
                var xMax = ParentTrans.rect.width - margin.right;
                var leftAlignMax = xMax - RectTrans.rect.width;
                if (xPos > leftAlignMax)
                {
                    //Right align.
                    xPivot = 1.0f;
                    if (xPos > xMax)
                    {
                        xPos = xMax;
                    }
                }
            }

            //Default upper align.
            var yPivot = 1.0f;
            var yMax = ParentTrans.rect.height - margin.top;
            var yPos = anchoredPosition.y;
            if (yPos >= yMax)
            {
                yPos = yMax;
            }
            else
            {
                var upperAlignMin = margin.bottom + RectTrans.rect.height;
                if (yPos < upperAlignMin)
                {
                    //Lower align.
                    yPivot = 0.0f;
                    if (yPos < margin.bottom)
                    {
                        yPos = margin.bottom;
                    }
                }
            }

            RectTrans.pivot = new Vector2(xPivot, yPivot);
            RectTrans.anchoredPosition = new Vector2(xPos, yPos);
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
}