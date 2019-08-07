/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuSeparator.cs
 *  Description  :  Define context menu separator.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/3/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Separator of context menu.
    /// </summary>
    [AddComponentMenu("MGS/ContextMenu/ContextMenuSeparator")]
    public class ContextMenuSeparator : ContextMenuElement, IContextMenuSeparator
    {
        #region Public Method
        /// <summary>
        /// Refresh menu separator.
        /// </summary>
        /// <param name="data">Data of context menu separator.</param>
        /// <returns>Succeed?</returns>
        public override bool Refresh(object data)
        {
            return true;
        }
        #endregion
    }

    /// <summary>
    /// Data of context menu separator.
    /// </summary>
    public class ContextMenuSeparatorData : IContextMenuElementData
    {
        #region Field and Property
        /// <summary>
        /// Type of context menu element.
        /// </summary>
        public ContextMenuElementType ElementType { get { return ContextMenuElementType.ContextMenuSeparator; } }
        #endregion
    }
}