/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Axle.cs
 *  Description  :  Define Axle component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/5/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Axle rotate around axis Z.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/Axle")]
    public class Axle : Mechanism, ICoaxeMechanism
    {
        #region Field and Property
        /// <summary>
        /// Coaxe mechanisms.
        /// </summary>
        [Tooltip("Coaxe mechanisms.")]
        [SerializeField]
        protected List<Mechanism> coaxes;
        #endregion

        #region Protected Method
        /// <summary>
        /// Drive coaxial mechanisms by angular velocity.
        /// </summary>
        /// <param name="velocity">Angular velocity of drive.</param>
        protected void DriveCoaxes(float velocity)
        {
            foreach (var coaxe in coaxes)
            {
                coaxe.Drive(velocity, DriveType.Angular);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive axle by angular velocity.
        /// </summary>
        /// <param name="velocity">Angular velocity of drive.</param>
        /// <param name="type">Invalid parameter (Axle can only drived by angular velocity).</param>
        public override void Drive(float velocity, DriveType type = DriveType.Ignore)
        {
            transform.Rotate(Vector3.forward, velocity * Time.deltaTime, Space.Self);
            DriveCoaxes(velocity);
        }

        /// <summary>
        /// Link coaxe.
        /// </summary>
        /// <param name="mechanism">Target mechanism.</param>
        public void LinkCoaxe(IMechanism mechanism)
        {
            var coaxe = mechanism as Mechanism;
            if (coaxe == null || coaxes.Contains(coaxe))
            {
                return;
            }

            coaxes.Add(coaxe);
        }

        /// <summary>
        /// Break coaxe.
        /// </summary>
        /// <param name="mechanism">Target mechanism.</param>
        public void BreakCoaxe(IMechanism mechanism)
        {
            coaxes.Remove(mechanism as Mechanism);
        }
        #endregion
    }
}