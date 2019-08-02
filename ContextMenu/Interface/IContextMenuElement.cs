/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuElement.cs
 *  Description  :  Define interface for context menu element.
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
    /// Interface for context menu element.
    /// </summary>
    public interface IContextMenuElement : IUIElement
    {
        #region Method
        /// <summary>
        /// Sets the sibling index of menu element.
        /// </summary>
        /// <param name="index">Index to set.</param>
        void SetSiblingIndex(int index);
        #endregion
    }
}