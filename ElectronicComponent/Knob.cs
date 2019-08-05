/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Knob.cs
 *  Description  :  Define knob component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Knob component.
    /// </summary>
    [AddComponentMenu("MGS/ElectronicComponent/Knob")]
    [RequireComponent(typeof(Collider))]
    public class Knob : MonoElectronicComponent, IKnob
    {
        #region Field and Property
        /// <summary>
        /// Input axis.
        /// </summary>
        [Tooltip("Input axis.")]
        [SerializeField]
        protected string inputAxis = "Mouse X";

        /// <summary>
        /// Knob rotate speed.
        /// </summary>
        [Tooltip("Knob rotate speed.")]
        [SerializeField]
        protected float rotateSpeed = 250;

        /// <summary>
        /// Limit rotate angle?
        /// </summary>
        [Tooltip("Limit rotate angle?")]
        [SerializeField]
        protected bool rotateLimit = false;

        /// <summary>
        /// Range of rotate angle.
        /// </summary>
        [Tooltip("Range of rotate angle.")]
        [SerializeField]
        protected Range angleRange = new Range(-60, 60);

        /// <summary>
        /// Adsorbent to target angle on mouse up?
        /// </summary>
        [Tooltip("Adsorbent to target angle on mouse up?")]
        [SerializeField]
        protected bool adsorbent = false;

        /// <summary>
        /// Adsorbable angles.
        /// </summary>
        [Tooltip("Adsorbable angles.")]
        [SerializeField]
        protected float[] adsorbableAngles;

        /// <summary>
        /// Start angles.
        /// </summary>
        public Vector3 StartAngles { protected set; get; }

        /// <summary>
        /// Input axis.
        /// </summary>
        public string InputAxis
        {
            set { inputAxis = value; }
            get { return inputAxis; }
        }

        /// <summary>
        /// Knob rotate speed.
        /// </summary>
        public float RotateSpeed
        {
            set { rotateSpeed = value; }
            get { return rotateSpeed; }
        }

        /// <summary>
        /// Limit rotate angle?
        /// </summary>
        public bool RotateLimit
        {
            set { rotateLimit = value; }
            get { return rotateLimit; }
        }

        /// <summary>
        /// Range of rotate angle.
        /// </summary>
        public Range AngleRange
        {
            set { angleRange = value; }
            get { return angleRange; }
        }

        /// <summary>
        /// Adsorbent to target angle on mouse up?
        /// </summary>
        public bool Adsorbent
        {
            set { adsorbent = value; }
            get { return adsorbent; }
        }

        /// <summary>
        /// Adsorbable angles.
        /// </summary>
        public float[] AdsorbableAngles
        {
            set { adsorbableAngles = value; }
            get { return adsorbableAngles; }
        }

        /// <summary>
        /// Knob current angle.
        /// </summary>
        public float Angle { protected set; get; }

        /// <summary>
        /// Knob current rotate percent base range.
        /// </summary>
        public float Percent
        {
            get
            {
                if (rotateLimit)
                {
                    var range = angleRange.Length;
                    return (Angle - angleRange.min) / (range == 0 ? 1 : range);
                }
                return 0;
            }
        }

        /// <summary>
        /// Knob drag event.
        /// </summary>
        public GenericEvent OnDrag { get; } = new GenericEvent();

        /// <summary>
        /// Knob release event.
        /// </summary>
        public GenericEvent OnRelease { get; } = new GenericEvent();

        /// <summary>
        /// Knob adsorbent event.
        /// </summary>
        public GenericEvent OnAdsorbent { get; } = new GenericEvent();
        #endregion

        #region Protected Method
        /// <summary>
        /// Initialize knob component.
        /// </summary>
        protected override void Initialize()
        {
            StartAngles = transform.localEulerAngles;
        }

        /// <summary>
        /// Response mouse left button drag.
        /// </summary>
        protected virtual void OnMouseDrag()
        {
            if (!isEnabled)
            {
                return;
            }

            Angle += Input.GetAxis(inputAxis) * rotateSpeed * Time.deltaTime;
            if (rotateLimit)
            {
                Angle = Mathf.Clamp(Angle, angleRange.min, angleRange.max);
            }
            Rotate(Angle);
            OnDrag.Invoke();
        }

        /// <summary>
        /// Response mouse left button up.
        /// </summary>
        protected virtual void OnMouseUp()
        {
            if (!isEnabled)
            {
                return;
            }

            OnRelease.Invoke();

            if (!adsorbent || adsorbableAngles.Length == 0)
            {
                return;
            }

            Angle = GetAdsorbentAngle(Angle, adsorbableAngles);
            Rotate(Angle);
            OnAdsorbent.Invoke();
        }

        /// <summary>
        /// Rotate knob to target angle.
        /// </summary>
        /// <param name="rotateAngle">Rotate angle.</param>
        protected virtual void Rotate(float rotateAngle)
        {
            transform.localRotation = Quaternion.Euler(StartAngles + Vector3.back * rotateAngle);
        }

        /// <summary>
        /// Get the adsorbent angle base on knob current angle.
        /// </summary>
        /// <param name="currentAngle">Current angle of knob.</param>
        /// <param name="adsorbableAngles">Adsorbable angles of knob.</param>
        /// <returns>Target adsorbent angle of knob.</returns>
        protected float GetAdsorbentAngle(float currentAngle, float[] adsorbableAngles)
        {
            var nearAngle = 0f;
            var deltaAngle = 0f;
            var nearDelta = float.PositiveInfinity;
            foreach (var adsorbentAngle in adsorbableAngles)
            {
                deltaAngle = Mathf.Abs(currentAngle - adsorbentAngle);
                if (deltaAngle < nearDelta)
                {
                    nearDelta = deltaAngle;
                    nearAngle = adsorbentAngle;
                }
            }
            return nearAngle;
        }
        #endregion
    }
}