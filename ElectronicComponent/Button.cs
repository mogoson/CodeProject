/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Button.cs
 *  Description  :  Define button component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/31/2016
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/9/2018
 *  Description  :  Use MonoLED to control the LED of button.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Button component.
    /// </summary>
    [AddComponentMenu("MGS/ElectronicComponent/Button")]
    [RequireComponent(typeof(Collider))]
    public class Button : MonoElectronicComponent, IButton
    {
        #region Field and Property
        /// <summary>
        /// Button down offset.
        /// </summary>
        [SerializeField]
        protected float downOffset = 1;

        /// <summary>
        /// Self lock on button down?
        /// </summary>
        [SerializeField]
        protected bool selfLock = false;

        /// <summary>
        /// Self lock offset percent.
        /// </summary>
        [Range(0, 1)]
        [SerializeField]
        protected float lockPercent = 0.5f;

        /// <summary>
        /// Toggle LED on toggle button?
        /// </summary>
        [SerializeField]
        protected bool useLED = false;

        /// <summary>
        /// LED of button.
        /// </summary>
        [SerializeField]
        protected MonoLED monoLED = null;

        /// <summary>
        /// Current offset base start position.
        /// </summary>
        protected float currentOffset = 0;

        /// <summary>
        /// Current self lock state.
        /// </summary>
        protected bool isLock = false;

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
        public event Action OnUp
        {
            add { onUp += value; }
            remove { onUp -= value; }
        }

        /// <summary>
        /// Button down event.
        /// </summary>
        public event Action OnDown
        {
            add { onDown += value; }
            remove { onDown -= value; }
        }

        /// <summary>
        /// Button lock event.
        /// </summary>
        public event Action OnLock
        {
            add { onLock += value; }
            remove { onLock -= value; }
        }

        /// <summary>
        /// Button up event.
        /// </summary>
        protected Action onUp;

        /// <summary>
        /// Button down event.
        /// </summary>
        protected Action onDown;

        /// <summary>
        /// Button lock event.
        /// </summary>
        protected Action onLock;
        #endregion

        #region Protected Method
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
                monoLED.Open();
            }

            onDown?.Invoke();
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
                onLock?.Invoke();
            }
            else
            {
                IsDown = false;
                currentOffset = 0;
                onUp?.Invoke();
            }
            Translate(currentOffset);

            if (useLED && !isLock)
            {
                monoLED.Close();
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

        #region Public Method
        /// <summary>
        /// Initialize button component.
        /// </summary>
        public override void Initialize()
        {
            StartPosition = transform.localPosition;
            LED = monoLED;
        }
        #endregion
    }
}