/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuElementData.cs
 *  Description  :  Define interface for context menu element data.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/3/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ContextMenu
{
    /// <summary>
    /// Interface for context menu element data.
    /// </summary>
    public interface IContextMenuElementData
    {
        #region Property
        /// <summary>
        /// Type of context menu element.
        /// </summary>
        ContextMenuElementType ElementType { get; }
        #endregion
    }

    /// <summary>
    /// Type of context menu element.
    /// </summary>
    public enum ContextMenuElementType
    {
        /// <summary>
        /// Context menu item element.
        /// </summary>
        ContextMenuItem = 0,

        /// <summary>
        /// Context menu separator element.
        /// </summary>
        ContextMenuSeparator = 1
    }
}