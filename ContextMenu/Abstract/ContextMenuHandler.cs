/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuHandler.cs
 *  Description  :  Handler of contex menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Handler of contex menu.
    /// </summary>
    public abstract class ContextMenuHandler : MonoBehaviour, IContextMenuHandler
    {
        #region Field and Property
        /// <summary>
        /// Current menu form.
        /// </summary>
        protected IContextMenuForm current;
        #endregion

        #region Public Method
        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        public abstract void OnMenuTriggerEnter(RaycastHit hitInfo);

        /// <summary>
        /// On context menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        public abstract void OnMenuItemClick(string tag);

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        public virtual void OnMenuTriggerExit()
        {
            if (current == null || !current.IsOpen)
            {
                return;
            }
            current.Close();
        }
        #endregion
    }
}