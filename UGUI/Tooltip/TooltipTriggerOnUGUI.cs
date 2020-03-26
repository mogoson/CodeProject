/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTriggerOnUGUI.cs
 *  Description  :  Trigger for Tooltip on UGUI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// Trigger for Tooltip on UGUI.
    /// </summary>
    [AddComponentMenu("MGS/UGUI/TooltipTriggerOnUGUI")]
    [RequireComponent(typeof(UIBehaviour))]
    public class TooltipTriggerOnUGUI : TooltipTrigger, IPointerEnterHandler, IPointerExitHandler
    {
        #region Protected Method
        /// <summary>
        /// On mouse pointer enter UI.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            var tipForm = FormManager.Instance.OpenForm<TextTooltipForm>();
            tipForm.SetTipContent(tipContent);
        }

        /// <summary>
        /// On mouse pointer exit UI.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            FormManager.Instance.CloseForm<TextTooltipForm>();
        }
        #endregion
    }
}