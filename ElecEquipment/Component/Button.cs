/*************************************************************************
 *  Copyright (c) 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Button.cs
 *  Description  :  Define button component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/31/2016
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  1.1
 *  Date         :  3/9/2018
 *  Description  :  Use MonoLED to control the LED of button.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.ElecEquipment
{
    /// <summary>
    /// Button component.
    /// </summary>
    [AddComponentMenu("MGS/ElecEquipment/Button")]
    [RequireComponent(typeof(Collider))]
    public class Button : MonoElecComponent, IButton
    {
        #region Field and Property
        /// <summary>
        /// Button down offset.
        /// </summary>
        [Tooltip("Button down offset.")]
        [SerializeField]
        protected float downOffset = 1;

        /// <summary>
        /// Self lock on button down?
        /// </summary>
        [Tooltip("Self lock on button down?")]
        [SerializeField]
        protected bool selfLock = false;

        /// <summary>
        /// Self lock offset percent.
        /// </summary>
        [Tooltip("Self lock offset percent.")]
        [Range(0, 1)]
        [SerializeField]
        protected float lockPercent = 0.5f;

        /// <summary>
        /// Toggle LED on toggle button?
        /// </summary>
        [Tooltip("Toggle LED on toggle button?")]
        [SerializeField]
        protected bool useLED = false;

        /// <summary>
        /// LED of button.
        /// </summary>
        [Tooltip("LED of button.")]
        [SerializeField]
        protected MonoLED monoLED;

        /// <summary>
        /// Current offset base start position.
        /// </summary>
        protected float currentOffset;

        /// <summary>
        /// Current self lock state.
        /// </summary>
        protected bool isLock;

        /// <summary>
        /// Local move axis.
        /// </summary>
        protected Vector3 MoveAxis
        {
            get
            {
                var axis = transform.forward;
                if (transform.parent)
                {
                    axis = transform.parent.InverseTransformDirection(axis);
                }
                return axis;
            }
        }

        /// <summary>
        /// Start position.
        /// </summary>
        public Vector3 StartPosition { protected set; get; }

        /// <summary>
        /// Button down offset.
        /// </summary>
        public float DownOffset
        {
            set { downOffset = value; }
            get { return downOffset; }
        }

        /// <summary>
        /// Self lock on button down?
        /// </summary>
        public bool SelfLock
        {
            set { selfLock = value; }
            get { return selfLock; }
        }

        /// <summary>
        /// Self lock offset percent.
        /// </summary>
        public float LockPercent
        {
            set { lockPercent = value; }
            get { return lockPercent; }
        }

        /// <summary>
        /// Toggle LED on toggle button?
        /// </summary>
        public bool UseLED
        {
            set { useLED = value; }
            get { return useLED; }
        }

        /// <summary>
        /// LED of button.
        /// </summary>
        public ILED LED { set; get; }

        /// <summary>
        /// Button is down?
        /// </summary>
        public bool IsDown { protected set; get; }

        /// <summary>
        /// Button up event.
        /// </summary>
        public GenericEvent OnUp { get; } = new GenericEvent();

        /// <summary>
        /// Button down event.
        /// </summary>
        public GenericEvent OnDown { get; } = new GenericEvent();

        /// <summary>
        /// Button lock event.
        /// </summary>
        public GenericEvent OnLock { get; } = new GenericEvent();
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            StartPosition = transform.localPosition;
            LED = monoLED;
        }

        /// <summary>
        /// Response mouse left button down.
        /// </summary>
        protected virtual void OnMouseDown()
        {
            if (!isEnabled)
            {
                return;
            }

            IsDown = true;
            currentOffset = downOffset;
            Translate(currentOffset);

            if (useLED)
            {
                LED.TurnOn();
            }

            OnDown.Invoke();
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

            if (selfLock)
            {
                isLock = !isLock;
            }

            if (isLock)
            {
                currentOffset = downOffset * lockPercent;
                OnLock.Invoke();
            }
            else
            {
                IsDown = false;
                currentOffset = 0;
                OnUp.Invoke();
            }
            Translate(currentOffset);

            if (useLED && !isLock)
            {
                LED.TurnOff();
            }
        }

        /// <summary>
        /// Translate button to target position.
        /// </summary>
        /// <param name="offset">Offset of z axis.</param>
        protected virtual void Translate(float offset)
        {
            transform.localPosition = StartPosition + MoveAxis * offset;
        }
        #endregion
    }
}