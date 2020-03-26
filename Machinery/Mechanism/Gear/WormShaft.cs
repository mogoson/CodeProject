/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WormShaft.cs
 *  Description  :  Define WormShaft component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  5/18/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Worm shaft.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/WormShaft")]
    public class WormShaft : Axle
    {
        #region Field and Property
        /// <summary>
        /// Gears drived by this worm.
        /// </summary>
        [Tooltip("Gears drived by this worm.")]
        public List<WormGear> gears;

        /// <summary>
        /// Count of worm threads.
        /// </summary>
        [Tooltip("Count of worm threads.")]
        public int threads = 1;
        #endregion

        #region Protected Method
        /// <summary>
        /// Drive worm gears by angular velocity.
        /// </summary>
        /// <param name="velocity">Angular velocity of drive.</param>
        protected void DriveGears(float velocity)
        {
            foreach (var gear in gears)
            {
                gear.Drive(velocity * threads / gear.teeth, DriveType.Angular);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive worm shaft by angular velocity.
        /// </summary>
        /// <param name="velocity">Angular velocity of drive.</param>
        /// <param name="type">Invalid parameter (WormShaft can only drived by angular velocity).</param>
        public override void Drive(float velocity, DriveType type = DriveType.Ignore)
        {
            base.Drive(velocity);
            DriveGears(velocity);
        }
        #endregion
    }
}