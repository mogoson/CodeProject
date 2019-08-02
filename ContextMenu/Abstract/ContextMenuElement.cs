/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuElement.cs
 *  Description  :  Define context menu element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/3/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.UI;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Element of context menu.
    /// </summary>
    public abstract class ContextMenuElement : UIElement, IContextMenuElement
    {
        #region Public Method
        /// <summary>
        /// Sets the sibling index of menu element.
        /// </summary>
        /// <param name="index">Index to set.</param>
        public virtual void SetSiblingIndex(int index)
        {
            transform.SetSiblingIndex(index);
        }
        #endregion
    }
}