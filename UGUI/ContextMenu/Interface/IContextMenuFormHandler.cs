/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuFormHandler.cs
 *  Description  :  Define interface for context menu form handler.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for context menu form handler.
    /// </summary>
    public interface IContextMenuFormHandler
    {
        #region Method
        /// <summary>
        /// On context menu item click.
        /// </summary>
        /// <param name="tag">Tag of menu item.</param>
        void OnMenuItemClick(string tag);
        #endregion
    }
}