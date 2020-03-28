/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Synchronizer.cs
 *  Description  :  Define Synchronizer component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/27/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Synchronizer for mechanisms.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/Synchronizer")]
    public class Synchronizer : Mechanism
    {
        #region Field and Property
        /// <summary>
        /// Mechanisms drive by this synchronizer.
        /// </summary>
        [Tooltip("Mechanisms drive by this synchronizer.")]
        public List<Mechanism> mechanisms = new List<Mechanism>();
        #endregion

        #region Public Method
        /// <summary>
        /// Drive synchronizer by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity, DriveType type)
        {
            foreach (var mechanism in mechanisms)
            {
                mechanism.Drive(velocity, type);
            }
        }
        #endregion
    }
}