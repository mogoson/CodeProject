/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuItem.cs
 *  Description  :  Define context menu item.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.Common.Logger;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Item of context menu.
    /// </summary>
    [AddComponentMenu("MGS/ContextMenu/ContextMenuItem")]
    [RequireComponent(typeof(Button))]
    public class ContextMenuItem : ContextMenuElement, IContextMenuItem
    {
        #region Field and Property
        /// <summary>
        /// Text component of menu item.
        /// </summary>
        [Tooltip("Text component of menu item.")]
        [SerializeField]
        protected Text itemText;

        /// <summary>
        /// Tag of menu item.
        /// </summary>
        [Tooltip("Tag of menu item.")]
        [SerializeField]
        protected string itemTag;

        /// <summary>
        /// Button of menu item.
        /// </summary>
        protected Button button;

        /// <summary>
        /// Tag of menu item.
        /// </summary>
        public string Tag
        {
            set { itemTag = value; }
            get { return itemTag; }
        }

        /// <summary>
        /// Menu item is interactable?
        /// </summary>
        public virtual bool Interactable
        {
            set { button.interactable = value; }
            get { return button.interactable; }
        }

        /// <summary>
        /// Event on menu item click.
        /// </summary>
        public GenericEvent<string> OnClick { get; } = new GenericEvent<string>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake UI component.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        /// <summary>
        /// On menu item button click.
        /// </summary>
        protected virtual void OnButtonClick()
        {
            OnClick.Invoke(itemTag);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh menu item.
        /// </summary>
        /// <param name="data">Data of context menu item, type is ContextMenuItemData.</param>
        /// <returns>Succeed?</returns>
        public override bool Refresh(ContextMenuElementData data)
        {
            if (data is ContextMenuItemData itemData)
            {
                itemText.text = itemData.name;
                itemTag = itemData.tag;
                button.interactable = itemData.interactable;
            }
            else
            {
                LogUtility.LogWarning(0, "Refresh menu item failed: The type of info is not ContextMenuItemData.");
                return false;
            }
            return true;
        }
        #endregion
    }

    /// <summary>
    /// Data of context menu item.
    /// </summary>
    public class ContextMenuItemData : ContextMenuElementData
    {
        #region Field and Property
        /// <summary>
        /// Type of context menu element.
        /// </summary>
        public override ContextMenuElementType ElementType { get { return ContextMenuElementType.ContextMenuItem; } }

        /// <summary>
        /// Name of menu item.
        /// </summary>
        public string name;

        /// <summary>
        /// Tag of menu item.
        /// </summary>
        public string tag;

        /// <summary>
        /// Menu item is interactable?
        /// </summary>
        public bool interactable;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of menu item.</param>
        /// <param name="tag">Tag of menu item.</param>
        /// <param name="interactable">Menu item is interactable?</param>
        public ContextMenuItemData(string name, string tag, bool interactable = true)
        {
            this.name = name;
            this.tag = tag;
            this.interactable = interactable;
        }
        #endregion
    }
}