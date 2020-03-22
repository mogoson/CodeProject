/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Gear.cs
 *  Description  :  Define Gear component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/22/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Gear rotate around axis Z.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/Gear")]
    public class Gear : Axle, IEngageMechanism
    {
        #region Field and Property
        /// <summary>
        /// Engaged mechanisms.
        /// </summary>
        [Tooltip("Engaged mechanisms.")]
        [SerializeField]
        protected List<Mechanism> engages;

        /// <summary>
        /// Radius of gear.
        /// </summary>
        [Tooltip("Radius of gear.")]
        public float radius = 0.5f;
        #endregion

        #region Protected Method
        /// <summary>
        /// Drive engage mechanisms by linear velocity.
        /// </summary>
        /// <param name="velocity">Linear velocity of drive.</param>
        protected void DriveEngages(float velocity)
        {
            foreach (var engage in engages)
            {
                engage.Drive(velocity, DriveType.Linear);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive gear by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity, DriveType type)
        {
            var angular = velocity;
            var linear = velocity;

            if (type == DriveType.Linear)
            {
                angular = velocity / radius * Mathf.Rad2Deg;
            }
            else
            {
                linear = velocity * Mathf.Deg2Rad * radius;
            }

            transform.Rotate(Vector3.forward, angular * Time.deltaTime, Space.Self);
            DriveCoaxes(angular);
            DriveEngages(-linear);
        }

        /// <summary>
        /// Link engage.
        /// </summary>
        /// <param name="mechanism">Target mechanism.</param>
        public void LinkEngage(IMechanism mechanism)
        {
            var engage = mechanism as Mechanism;
            if (engage == null || engages.Contains(engage))
            {
                return;
            }

            engages.Add(engage);
        }

        /// <summary>
        /// Break engage.
        /// </summary>
        /// <param name="mechanism">Target mechanism.</param>
        public void BreakEngage(IMechanism mechanism)
        {
            engages.Remove(mechanism as Mechanism);
        }
        #endregion
    }
}