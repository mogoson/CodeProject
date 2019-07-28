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

using MGS.Common.Logger;
using MGS.UCommon.Generic;
using MGS.UCommon.UI;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Item of context menu.
    /// </summary>
    [AddComponentMenu("MGS/ContextMenu/ContextMenuItem")]
    [RequireComponent(typeof(Button))]
    public class ContextMenuItem : InteractableUI, IContextMenuItem
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
        public override bool Interactable
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
        /// Initialize menu item.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

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
        public override void Refresh(object data)
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
            }
        }
        #endregion
    }
}