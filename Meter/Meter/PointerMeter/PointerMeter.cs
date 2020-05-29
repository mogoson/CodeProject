/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerMeter.cs
 *  Description  :  Define meter with pointers.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Meter with pointers.
    /// </summary>
    [AddComponentMenu("MGS/Meter/PointerMeter")]
    public class PointerMeter : MonoBehaviour, IPointerMeter
    {
        #region Field and Property 
        /// <summary>
        /// Pointers of meter.
        /// First is main pointer.
        /// </summary>
        [Tooltip("Pointers of meter, first is main pointer.")]
        public MeterPointer[] pointers = { };

        /// <summary>
        /// Pointers start angles.
        /// </summary>
        public Vector3[] StartAngles { protected set; get; }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        public float MainAngle
        {
            set
            {
                mainPointerAngle = value;
                OnMainAngleChanged(mainPointerAngle);
            }
            get { return mainPointerAngle; }
        }

        /// <summary>
        /// Angle of main pointer.
        /// </summary>
        protected float mainPointerAngle = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            StartAngles = new Vector3[pointers.Length];
            for (int i = 0; i < pointers.Length; i++)
            {
                StartAngles[i] = pointers[i].pointerTrans.localEulerAngles;
            }
        }

        /// <summary>
        /// On main pointer's angle changed.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected virtual void OnMainAngleChanged(float mainAngle)
        {
            SetPointersAngle(mainAngle);
        }

        /// <summary>
        /// Set pointers angle.
        /// </summary>
        /// <param name="mainAngle">Main pointer's angle.</param>
        protected void SetPointersAngle(float mainAngle)
        {
            for (int i = 0; i < pointers.Length; i++)
            {
                var euler = StartAngles[i] + Vector3.back * mainAngle * pointers[i].pointerRatio;
                pointers[i].pointerTrans.localRotation = Quaternion.Euler(euler);
            }
        }
        #endregion
    }
}