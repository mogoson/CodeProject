/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTrigger.cs
 *  Description  :  Trigger for Tooltip.
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
    /// Trigger for Tooltip.
    /// </summary>
    public abstract class TooltipTrigger : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Tooltip content.
        /// </summary>
        [Tooltip("Tooltip content.")]
        [SerializeField]
        [Multiline]
        protected string tipContent = "Tooltip Content";

        /// <summary>
        /// Tooltip content.
        /// </summary>
        public string TipContent
        {
            set { tipContent = value; }
            get { return tipContent; }
        }
        #endregion
    }
}