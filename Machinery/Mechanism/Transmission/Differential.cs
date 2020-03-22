/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Differential.cs
 *  Description  :  Define Differential component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/1/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Ordinary differential.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/Differential")]
    public class Differential : Mechanism
    {
        #region Field and Property
        /// <summary>
        /// Left gear of differential.
        /// </summary>
        [Tooltip("")]
        public Gear leftGear;

        /// <summary>
        /// Right gear of differential.
        /// </summary>
        [Tooltip("")]
        public Gear rightGear;

        /// <summary>
        /// Left axle of differential.
        /// </summary>
        [Tooltip("")]
        public Axle leftAxle;

        /// <summary>
        /// Right axle of differential.
        /// </summary>
        [Tooltip("")]
        public Axle rightAxle;

        /// <summary>
        /// Offset coefficient of differential.
        /// </summary>
        public float Coefficient
        {
            set
            {
                coefficient = value;
                leftCoefficient = 1 - coefficient;
                rightCoefficient = 1 + coefficient;
            }
            get { return coefficient; }
        }

        /// <summary>
        /// Offset coefficient of differential.
        /// </summary>
        protected float coefficient = 0;

        /// <summary>
        /// Offset coefficient of left axle.
        /// </summary>
        protected float leftCoefficient = 1;

        /// <summary>
        /// Offset coefficient of right axle.
        /// </summary>
        protected float rightCoefficient = 1;
        #endregion

        #region Public Method
        /// <summary>
        /// Drive differential by angular velocity.
        /// </summary>
        /// <param name="velocity">Angular velocity of drive.</param>
        /// <param name="type">Invalid parameter (Differential can only drived by angular velocity).</param>
        public override void Drive(float velocity, DriveType type = DriveType.Ignore)
        {
            type = DriveType.Angular;
            leftGear.Drive(velocity * coefficient, type);
            rightGear.Drive(velocity * coefficient, type);

            leftAxle.Drive(-velocity * leftCoefficient, type);
            rightAxle.Drive(velocity * rightCoefficient, type);
        }
        #endregion
    }
}