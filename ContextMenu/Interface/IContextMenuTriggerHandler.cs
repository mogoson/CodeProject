/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuTriggerHandler.cs
 *  Description  :  Define interface for context menu trigger handler.
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
    /// Interface for context menu trigger handler.
    /// </summary>
    public interface IContextMenuTriggerHandler
    {
        #region Method
        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        /// <returns>Instance of context menu form.</returns>
        IContextMenuForm OnMenuTriggerEnter(RaycastHit hitInfo);

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        /// <param name="menuForm">Instance of context menu form.</param>
        void OnMenuTriggerExit(IContextMenuForm menuForm);
        #endregion
    }
}