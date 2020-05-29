/*************************************************************************
 *  Copyright (c) 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RockerSpring.cs
 *  Description  :  Define RockerSpring component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/24/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.SkinnedMesh;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Rocker spring look at joint.
    /// </summary>
    [AddComponentMenu("MGS/Machinery/RockerSpring")]
    public class RockerSpring : RockerJoint
    {
        #region Field and Property
        /// <summary>
        /// Spring of rocker.
        /// </summary>
        [Tooltip("Spring of rocker.")]
        public HelixHose spring;

        /// <summary>
        /// Top padding of spring.
        /// </summary>
        [Tooltip("Top padding of spring.")]
        public float top = 0;

        /// <summary>
        /// Bottom padding of spring.
        /// </summary>
        [Tooltip("Bottom padding of spring.")]
        public float bottom = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Drive mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="mode">Mode of drive.</param>
        /// <returns>Drive is unrestricted?</returns>
        protected override bool OnDrive(float velocity, DriveMode mode)
        {
            if (!base.OnDrive(velocity, mode))
            {
                return false;
            }

            return DriveSpring();
        }

        /// <summary>
        /// Drive spring.
        /// </summary>
        /// <returns>Drive spring is unrestricted?</returns>
        protected virtual bool DriveSpring()
        {
            if (!Application.isPlaying && spring == null)
            {
                return false;
            }

            //Rivet spring.
            spring.transform.localPosition = Vector3.zero;
            spring.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Rebuild spring.
            spring.bottomEllipse.center.y = bottom;
            spring.topEllipse.center.y = Vector3.Distance(transform.position, joint.position) - top;
            spring.Rebuild();
            return true;
        }
        #endregion
    }
}