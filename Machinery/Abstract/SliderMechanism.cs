/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SliderMechanism.cs
 *  Description  :  Slider joint mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Slider joint mechanism.
    /// </summary>
    public abstract class SliderMechanism : RockerLinkMechanism
    {
        #region Field and Property
        /// <summary>
        /// Stroke of slider.
        /// </summary>
        [Tooltip("Stroke of slider.")]
        public Range stroke = new Range(-1, 1);

        /// <summary>
        /// Displacement of slider.
        /// </summary>
        public float Displacement { protected set; get; }

        /// <summary>
        /// Telescopic state of slider.
        /// </summary>
        public TelescopicState State
        {
            get
            {
                var state = TelescopicState.Between;
                if (Displacement <= stroke.min)
                {
                    state = TelescopicState.Minimum;
                }
                else if (Displacement >= stroke.max)
                {
                    state = TelescopicState.Maximum;
                }
                return state;
            }
        }

        /// <summary>
        /// Start position of slider.
        /// </summary>
        public Vector3 StartPosition { protected set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Move slider by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of move.</param>
        protected abstract void DriveSlider(float velocity);
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize joint.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            StartPosition = transform.localPosition;
        }

        /// <summary>
        /// Drive slider by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity, DriveType type = DriveType.Ignore)
        {
            DriveSlider(velocity);
        }
        #endregion
    }
}