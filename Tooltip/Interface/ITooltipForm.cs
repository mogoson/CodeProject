/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITooltipForm.cs
 *  Description  :  Interface for tool tip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.Tooltip
{
    /// <summary>
    /// Interface for tool tip form.
    /// </summary>
    public interface ITooltipForm : IUIForm
    {
        #region Property
        /// <summary>
        /// Tip form auto follow mouse pointer?
        /// </summary>
        bool AutoFollowPointer { set; get; }

        /// <summary>
        /// Margin of tip form base on screen.
        /// </summary>
        RectOffset Margin { set; get; }

        /// <summary>
        /// Offset for tip form to align to target position.
        /// </summary>
        Vector2 Offset { set; get; }

        /// <summary>
        /// Alignment for tip form to align to target position.
        /// </summary>
        TextAnchor Alignment { set; get; }
        #endregion
    }
}