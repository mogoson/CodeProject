/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuElement.cs
 *  Description  :  Define interface for context menu element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/3/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for context menu element.
    /// </summary>
    public interface IContextMenuElement : IUIElement
    {
        #region Method
        /// <summary>
        /// Refresh menu element.
        /// </summary>
        /// <param name="data">Data to refresh.</param>
        /// <returns>Succeed?</returns>
        bool Refresh(ContextMenuElementData data);
        #endregion
    }

    /// <summary>
    /// Base class for context menu element data.
    /// </summary>
    public abstract class ContextMenuElementData
    {
        #region Property
        /// <summary>
        /// Type of context menu element.
        /// </summary>
        public abstract ContextMenuElementType ElementType { get; }
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