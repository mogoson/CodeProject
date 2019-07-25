/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuHandler.cs
 *  Description  :  Define interface for context menu handler.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Interface for context menu handler.
    /// </summary>
    public interface IContextMenuHandler
    {
        #region Method
        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        void OnMenuTriggerEnter(RaycastHit hitInfo);

        /// <summary>
        /// On context menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        void OnMenuItemClick(string tag);

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        void OnMenuTriggerExit();
        #endregion
    }
}