/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LED.cs
 *  Description  :  Define LED component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ElecEquipment
{
    /// <summary>
    /// LED component.
    /// </summary>
    [AddComponentMenu("MGS/ElecEquipment/LED")]
    [RequireComponent(typeof(Renderer))]
    public class LED : MonoLED
    {
        #region Field and Property
        /// <summary>
        /// Highlight material of LED.
        /// </summary>
        [Tooltip("Highlight material of LED.")]
        public Material highlightMat;

        /// <summary>
        /// Default material of LED.
        /// </summary>
        protected Material defaultMat;

        /// <summary>
        /// Renderer of LED.
        /// </summary>
        protected Renderer LEDRenderer;
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            LEDRenderer = GetComponent<Renderer>();
            defaultMat = LEDRenderer.material;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on LED.
        /// </summary>
        public override void TurnOn()
        {
            if (isEnabled)
            {
                LEDRenderer.material = highlightMat;
            }
        }

        /// <summary>
        /// Turn off LED.
        /// </summary>
        public override void TurnOff()
        {
            if (isEnabled)
            {
                LEDRenderer.material = defaultMat;
            }
        }
        #endregion
    }
}