/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTriggerHandler.cs
 *  Description  :  Handler of contex menu trigger.
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
    /// Handler of contex menu trigger.
    /// </summary>
    public abstract class ContextMenuTriggerHandler : MonoBehaviour, IContextMenuTriggerHandler
    {
        #region Public Method
        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        /// <returns>Instance of context menu form.</returns>
        public abstract IContextMenuForm OnMenuTriggerEnter(RaycastHit hitInfo);

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        /// <param name="menuForm">Instance of context menu form.</param>
        public virtual void OnMenuTriggerExit(IContextMenuForm menuForm)
        {
            if (menuForm == null || menuForm.IsDisposed)
            {
                return;
            }

            if (menuForm.IsOpen)
            {
                FormManager.Instance.CloseForm(menuForm);
            }
        }
        #endregion
    }
}