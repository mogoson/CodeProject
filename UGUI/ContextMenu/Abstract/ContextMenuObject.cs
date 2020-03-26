/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuObject.cs
 *  Description  :  Context menu support object.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Context menu support object.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class ContextMenuObject : MonoBehaviour, IContextMenuFormHandler
    {
        #region Method
        /// <summary>
        /// On context menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        public abstract void OnMenuItemClick(string tag);
        #endregion
    }
}