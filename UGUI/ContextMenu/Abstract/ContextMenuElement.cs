/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuElement.cs
 *  Description  :  Define context menu element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/3/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// Element of context menu.
    /// </summary>
    public abstract class ContextMenuElement : UIElement, IContextMenuElement
    {
        #region Public Method
        /// <summary>
        /// Refresh menu element.
        /// </summary>
        /// <param name="data">Data to refresh.</param>
        /// <returns>Succeed?</returns>
        public abstract bool Refresh(ContextMenuElementData data);
        #endregion
    }
}