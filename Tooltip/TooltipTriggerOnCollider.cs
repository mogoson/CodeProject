/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTriggerOnCollider.cs
 *  Description  :  Trigger for Tooltip on collider.
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
    /// Trigger for Tooltip on collider.
    /// </summary>
    [AddComponentMenu("MGS/Tooltip/TooltipTriggerOnCollider")]
    [RequireComponent(typeof(Collider))]
    public class TooltipTriggerOnCollider : TooltipTrigger
    {
        #region Protected Method
        /// <summary>
        /// On mouse pointer enter collider.
        /// </summary>
        protected virtual void OnMouseEnter()
        {
            UIFormManager.Instance.OpenForm<TextTooltipForm>(tipContent);
        }

        /// <summary>
        /// On mouse pointer exit collider.
        /// </summary>
        protected virtual void OnMouseExit()
        {
            UIFormManager.Instance.CloseForm<TextTooltipForm>();
        }
        #endregion
    }
}