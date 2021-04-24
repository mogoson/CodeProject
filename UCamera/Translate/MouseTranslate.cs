﻿/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MouseTranslate.cs
 *  Description  :  Mouse pointer drag to translate gameobject.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.UCamera
{
    /// <summary>
    /// Mouse pointer drag to translate gameobject.
    /// </summary>
    [AddComponentMenu("MGS/UCamera/MouseTranslate")]
    public class MouseTranslate : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Target camera for translate direction.
        /// </summary>
        [Tooltip("Target camera for translate direction.")]
        public Transform targetCamera;

        /// <summary>
        /// Settings of mouse button and pointer.
        /// </summary>
        [Tooltip("Settings of mouse button and pointer.")]
        public MouseSettings mouseSettings = new MouseSettings(0, 1, 0);

        /// <summary>
        /// Settings of move area.
        /// </summary>
        [Tooltip("Settings of move area.")]
        public PlaneArea areaSettings = new PlaneArea(null, 10, 10);

        /// <summary>
        /// Damper for move.
        /// </summary>
        [Tooltip("Damper for move.")]
        [Range(0, 10)]
        public float damper = 5;

        /// <summary>
        /// Current offset base area center.
        /// </summary>
        public Vector3 CurrentOffset { protected set; get; }

        /// <summary>
        /// Target offset base area center.
        /// </summary>
        protected Vector3 targetOffset;
        #endregion

        #region Protected Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            CurrentOffset = targetOffset = transform.position - areaSettings.center.position;
        }

        /// <summary>
        /// Component update.
        /// </summary>
        protected virtual void Update()
        {
            TranslateByMouse();
        }

        /// <summary>
        /// Translate this gameobject by mouse.
        /// </summary>
        protected void TranslateByMouse()
        {
            if (Input.GetMouseButton(mouseSettings.mouseButtonID))
            {
                //Mouse pointer.
                var mouseX = Input.GetAxis("Mouse X") * mouseSettings.pointerSensitivity;
                var mouseY = Input.GetAxis("Mouse Y") * mouseSettings.pointerSensitivity;

                //Deal with offset base direction of target camera.
                targetOffset -= targetCamera.right * mouseX;
                targetOffset -= Vector3.Cross(targetCamera.right, Vector3.up) * mouseY;

                //Range limit.
                targetOffset.x = Mathf.Clamp(targetOffset.x, -areaSettings.width, areaSettings.width);
                targetOffset.z = Mathf.Clamp(targetOffset.z, -areaSettings.length, areaSettings.length);
            }

            //Lerp and update transform position.
            CurrentOffset = Vector3.Lerp(CurrentOffset, targetOffset, damper * Time.deltaTime);
            transform.position = areaSettings.center.position + CurrentOffset;
        }
        #endregion
    }
}