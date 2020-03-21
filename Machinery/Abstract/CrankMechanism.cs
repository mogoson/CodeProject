/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CrankMechanism.cs
 *  Description  :  Crank mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Crank mechanism.
    /// </summary>
	public abstract class CrankMechanism : RockerLinkMechanism
    {
        #region Field and Property
        /// <summary>
        /// Current rotate angle of crank.
        /// </summary>
        public float Angle { protected set; get; }

        /// <summary>
        /// Start eulerAngles.
        /// </summary>
        public Vector3 StartAngles { protected set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Rotate crank by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        protected abstract void DriveCrank(float velocity, DriveType type);
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize crank.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            StartAngles = transform.localEulerAngles;
        }

        /// <summary>
        /// Drive crank by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity, DriveType type)
        {
            DriveCrank(velocity, type);
        }
        #endregion
    }
}