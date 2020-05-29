/*************************************************************************
 *  Copyright ? 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuTrigger.cs
 *  Description  :  Define interface for context menu trigger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/17/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for context menu trigger.
    /// </summary>
    public interface IContextMenuTrigger
    {
        #region Property
        /// <summary>
        /// Camera to raycast.
        /// </summary>
        Camera RayCamera { get; }

        /// <summary>
        ///  LayerMask of raycast.
        /// </summary>
        LayerMask LayerMask { set; get; }

        /// <summary>
        /// Max distance of raycast.
        /// </summary>
        float MaxDistance { set; get; }

        /// <summary>
        /// Handler of contex menu trigger.
        /// </summary>
        IContextMenuTriggerHandler Handler { set; get; }
        #endregion
    }
}