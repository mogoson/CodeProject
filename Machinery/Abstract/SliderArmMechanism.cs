/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SliderArmMechanism.cs
 *  Description  :  Arm with slider joints.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Arm with slider joints.
    /// </summary>
	public abstract class SliderArmMechanism : Mechanism
    {
        #region Field and Property
        /// <summary>
        /// Slider joints of arm.
        /// </summary>
        public List<SliderMechanism> sliders = new List<SliderMechanism>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Clamp slider index in the range.
        /// </summary>
        /// <param name="index">Index of slider.</param>
        /// <returns>Correct index of slider.</returns>
        protected int ClampIndex(int index)
        {
            return Mathf.Clamp(index, 0, sliders.Count - 1);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive arm by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override abstract void Drive(float velocity, DriveType type = DriveType.Ignore);
        #endregion
    }
}