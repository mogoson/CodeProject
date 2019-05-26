/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Knob.cs
 *  Description  :  Define knob component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
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
        [SerializeField]
        protected string inputAxis = "Mouse X";

        /// <summary>
        /// Knob rotate speed.
        /// </summary>
        [SerializeField]
        protected float rotateSpeed = 250;

        /// <summary>
        /// Limit rotate angle?
        /// </summary>
        [SerializeField]
        protected bool rotateLimit = false;

        /// <summary>
        /// Range of rotate angle.
        /// </summary>
        [SerializeField]
        protected Range angleRange = new Range(-60, 60);

        /// <summary>
        /// Adsorbent to target angle on mouse up?
        /// </summary>
        [SerializeField]
        protected bool adsorbent = false;

        /// <summary>
        /// Adsorbable angles.
        /// </summary>
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
        public event Action OnDrag;

        /// <summary>
        /// Knob release event.
        /// </summary>
        public event Action OnRelease;

        /// <summary>
        /// Knob adsorbent event.
        /// </summary>
        public event Action OnAdsorbent;
        #endregion

        #region Protected Method
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
            OnDrag?.Invoke();
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

            OnRelease?.Invoke();

            if (!adsorbent || adsorbableAngles.Length == 0)
            {
                return;
            }

            Angle = GetAdsorbentAngle(Angle, adsorbableAngles);
            Rotate(Angle);
            OnAdsorbent?.Invoke();
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

        #region Public Method
        /// <summary>
        /// Initialize knob component.
        /// </summary>
        public override void Initialize()
        {
            StartAngles = transform.localEulerAngles;
        }
        #endregion
    }
}