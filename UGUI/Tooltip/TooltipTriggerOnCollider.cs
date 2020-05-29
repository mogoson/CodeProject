/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTriggerOnCollider.cs
 *  Description  :  Trigger for Tooltip on collider.
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
    /// Trigger for Tooltip on collider.
    /// </summary>
    [AddComponentMenu("MGS/UGUI/TooltipTriggerOnCollider")]
    [RequireComponent(typeof(Collider))]
    public class TooltipTriggerOnCollider : TooltipTrigger
    {
        #region Protected Method
        /// <summary>
        /// On mouse pointer enter collider.
        /// </summary>
        protected virtual void OnMouseEnter()
        {
            var tipForm = FormManager.Instance.OpenForm<TextTooltipForm>();
            tipForm.SetTipContent(tipContent);
        }

        /// <summary>
        /// On mouse pointer exit collider.
        /// </summary>
        protected virtual void OnMouseExit()
        {
            FormManager.Instance.CloseForm<TextTooltipForm>();
        }
        #endregion
    }
}