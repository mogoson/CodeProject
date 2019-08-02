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
        protected RectOffset margin;

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
        /// Margin of menu form base on screen.
        /// </summary>
        public RectOffset Margin
        {
            set { margin = value; }
            get { return margin; }
        }

        /// <summary>
        /// Handler of contex menu form.
        /// </summary>
        public IContextMenuFormHandler Handler { set; get; }

        /// <summary>
        /// Prefab of menu item to create clone.
        /// </summary>
        public GameObject ItemPrefab
        {
            set
            {
                if (value == null)
                {
                    LogUtility.LogError(0, "The prefab of menu item can not be set as null.");
                    return;
                }

                if (value.GetComponent<IContextMenuItem>() == null)
                {
                    LogUtility.LogError(0, "The prefab of menu item has no component that implement IContextMenuItem interface.");
                    return;
                }

                itemPrefab = value;
            }
            get { return itemPrefab; }
        }

        /// <summary>
        /// Prefab of menu separator to create clone.
        /// </summary>
        public GameObject SeparatorPrefab
        {
            set
            {
                if (value == null)
                {
                    LogUtility.LogError(0, "The prefab of menu separator can not be set as null.");
                    return;
                }

                if (value.GetComponent<IContextMenuSeparator>() == null)
                {
                    LogUtility.LogError(0, "The prefab of menu separator has no component that implement IContextMenuSeparator interface.");
                    return;
                }

                separatorPrefab = value;
            }
            get { return separatorPrefab; }
        }

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
        protected override void Initialize()
        {
            base.Initialize();
            rectTransform.anchorMin = rectTransform.anchorMax = Vector2.zero;

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
        /// Refresh the elements of menu base on element datas.
        /// </summary>
        /// <param name="elementDatas">Data of menu elements.</param>
        protected void RefreshElements(IEnumerable<IContextMenuElementData> elementDatas)
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

                menuElement.SetSiblingIndex(elementIndex);
                menuElement.Open(elementData);
                elementIndex++;
            }

            if (itemIndex < items.Count - 1)
            {
                var surplusItems = items.GetRange(itemIndex + 1, items.Count - itemIndex - 1);
                foreach (var surplusItem in surplusItems)
                {
                    if (surplusItem.IsOpen)
                    {
                        surplusItem.Close();
                    }
                }
            }

            if (separatorIndex < separators.Count - 1)
            {
                var surplusSeparators = separators.GetRange(separatorIndex + 1, separators.Count - separatorIndex - 1);
                foreach (var surplusSeparator in surplusSeparators)
                {
                    if (surplusSeparator.IsOpen)
                    {
                        surplusSeparator.Close();
                    }
                }
            }
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
        }

        /// <summary>
        /// Set menu form position.
        /// </summary>
        /// <param name="screenPos">Target screen position of menu form.</param>
        protected virtual void SetFormPosition(Vector2 screenPos)
        {
            //Default left align.
            var xPivot = 0.0f;
            var xPos = screenPos.x;
            if (xPos <= margin.left)
            {
                xPos = margin.left;
            }
            else
            {
                var xMax = Screen.width - margin.right;
                var leftAlignMax = xMax - rectTransform.rect.width;
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
            var yMax = Screen.height - margin.top;
            var yPos = screenPos.y;
            if (yPos >= yMax)
            {
                yPos = yMax;
            }
            else
            {
                var upperAlignMin = margin.bottom + rectTransform.rect.height;
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

            rectTransform.pivot = new Vector2(xPivot, yPivot);
            rectTransform.anchoredPosition = new Vector2(xPos, yPos);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh context menu form.
        /// </summary>
        /// <param name="data">Data for context menu form, type is Vector2 or Vector3 or ContextMenuFormInfo or ContextMenuFormData.</param>
        public override void Refresh(object data)
        {
            if (data is Vector2 vector2)
            {
                SetFormPosition(vector2);
            }
            else if (data is Vector3 vector3)
            {
                SetFormPosition(vector3);
            }
            else if (data is ContextMenuFormInfo formInfo)
            {
                SetFormPosition(formInfo.position);
                DisableItems(formInfo.disableItems);
            }
            else if (data is ContextMenuFormData formData)
            {
                SetFormPosition(formData.position);
                RefreshElements(formData.elementDatas);
            }
            else
            {
                LogUtility.LogError(0, "Refresh context menu form failed: The type of data is not Vector2 or Vector3 or ContextMenuFormInfo or ContextMenuFormData.");
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
    public class ContextMenuFormInfo
    {
        /// <summary>
        /// Screen position to display menu form.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Tags of disable menu items.
        /// </summary>
        public IEnumerable<string> disableItems;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position">Screen position to display menu form.</param>
        /// <param name="disableItems">Tags of disable menu items.</param>
        public ContextMenuFormInfo(Vector2 position, IEnumerable<string> disableItems)
        {
            this.position = position;
            this.disableItems = disableItems;
        }
    }

    /// <summary>
    /// Data of contex menu form.
    /// </summary>
    public class ContextMenuFormData
    {
        /// <summary>
        /// Screen position to display menu form.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Data of menu elements.
        /// </summary>
        public IEnumerable<IContextMenuElementData> elementDatas;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="position">Screen position to display menu form.</param>
        /// <param name="elementDatas">Data of menu elements.</param>
        public ContextMenuFormData(Vector2 position, IEnumerable<IContextMenuElementData> elementDatas)
        {
            this.position = position;
            this.elementDatas = elementDatas;
        }
    }
}