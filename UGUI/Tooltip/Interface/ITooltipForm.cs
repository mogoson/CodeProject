/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITooltipForm.cs
 *  Description  :  Interface for tool tip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for tool tip form.
    /// </summary>
    public interface ITooltipForm : IForm
    {
        #region Property
        /// <summary>
        /// Tip form auto follow mouse pointer?
        /// </summary>
        bool AutoFollowPointer { set; get; }

        /// <summary>
        /// Offset for tip form to align to mouse pointer.
        /// </summary>
        Vector2 Offset { set; get; }
        #endregion
    }
}