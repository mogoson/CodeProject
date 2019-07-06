/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Rocker.cs
 *  Description  :  Define rocker component.
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
    /// Rocker component.
    /// </summary>
    [AddComponentMenu("MGS/ElectronicComponent/Rocker")]
    [RequireComponent(typeof(Collider))]
    public class Rocker : MonoElectronicComponent, IRocker
    {
        #region Field and Property
        /// <summary>
        /// Radius angle.
        /// </summary>
        [Tooltip("Radius angle.")]
        [SerializeField]
        protected float radiusAngle = 25;

        /// <summary>
        /// Rocker rotate speed.
        /// </summary>
        [Tooltip("Rocker rotate speed.")]
        [SerializeField]
        protected float rotateSpeed = 250;

        /// <summary>
        /// Revert speed.
        /// </summary>
        [Tooltip("Revert speed.")]
        [SerializeField]
        protected float revertSpeed = 0;

        /// <summary>
        /// Current angles.
        /// </summary>
        protected Vector3 angles;

        /// <summary>
        /// Start angles.
        /// </summary>
        public Vector3 StartAngles { protected set; get; }

        /// <summary>
        /// Radius angle.
        /// </summary>
        public float RadiusAngle
        {
            set { radiusAngle = value; }
            get { return radiusAngle; }
        }

        /// <summary>
        /// Rocker rotate speed.
        /// </summary>
        public float RotateSpeed
        {
            set { rotateSpeed = value; }
            get { return rotateSpeed; }
        }

        /// <summary>
        /// Revert speed.
        /// </summary>
        public float RevertSpeed
        {
            set { revertSpeed = value; }
            get { return revertSpeed; }
        }

        /// <summary>
        /// Rocker current angles normalized vector.
        /// </summary>
        public Vector2 Vector
        {
            get { return angles.normalized; }
        }

        /// <summary>
        /// Rocker drag event.
        /// </summary>
        public GenericEvent OnDrag { get; } = new GenericEvent();

        /// <summary>
        /// Rocker Release event.
        /// </summary>
        public GenericEvent OnRelease { get; } = new GenericEvent();

        /// <summary>
        /// Rocker revert event.
        /// </summary>
        public GenericEvent OnRevert { get; } = new GenericEvent();
        #endregion

        #region Protected Method
        /// <summary>
        /// Drag rocker.
        /// </summary>
        protected virtual void OnMouseDrag()
        {
            if (!isEnabled)
            {
                return;
            }

            var x = Input.GetAxis("Mouse Y");
            var y = Input.GetAxis("Mouse X");
            angles += new Vector3(x, -y) * rotateSpeed * Time.deltaTime;
            if (angles.magnitude > radiusAngle)
            {
                angles = angles.normalized * radiusAngle;
            }
            Rotate(angles);
            OnDrag.Invoke();
        }

        /// <summary>
        /// Release rocker.
        /// </summary>
        protected virtual void OnMouseUp()
        {
            if (!isEnabled)
            {
                return;
            }

            if (revertSpeed > 0)
            {
                InvokeRepeating("Revert", 0, Time.fixedDeltaTime);
            }
            OnRelease.Invoke();
        }

        /// <summary>
        /// Revert rocker to default.
        /// </summary>
        protected virtual void Revert()
        {
            if (angles.magnitude == 0)
            {
                CancelInvoke("Revert");
                OnRevert.Invoke();
            }
            angles = Vector3.MoveTowards(angles, Vector3.zero, revertSpeed * Time.deltaTime);
            Rotate(angles);
        }

        /// <summary>
        /// Rotate rocker to target angles.
        /// </summary>
        /// <param name="eulerAngles">Rotate euler angles.</param>
        protected virtual void Rotate(Vector3 eulerAngles)
        {
            transform.localRotation = Quaternion.Euler(StartAngles + eulerAngles);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize rocker component.
        /// </summary>
        public override void Initialize()
        {
            StartAngles = transform.localEulerAngles;
        }
        #endregion
    }
}