/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuItem.cs
 *  Description  :  Define interface for context menu item.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using MGS.UCommon.UI;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Interface for context menu item.
    /// </summary>
    public interface IContextMenuItem : IContextMenuElement, IInteractableUI
    {
        #region Property
        /// <summary>
        /// Tag of menu item.
        /// </summary>
        string Tag { set; get; }
        #endregion

        #region Event
        /// <summary>
        /// Event on menu item click.
        /// </summary>
        GenericEvent<string> OnClick { get; }
        #endregion
    }
}