/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IKnob.cs
 *  Description  :  Interface for knob.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Structure;
using System;

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Interface for knob.
    /// </summary>
    public interface IKnob : IElectronicComponent
    {
        #region Property
        /// <summary>
        /// Input axis.
        /// </summary>
        string InputAxis { set; get; }

        /// <summary>
        /// Switch rotate speed.
        /// </summary>
        float RotateSpeed { set; get; }

        /// <summary>
        /// Limit rotate angle?
        /// </summary>
        bool RotateLimit { set; get; }

        /// <summary>
        /// Range of rotate angle.
        /// </summary>
        Range AngleRange { set; get; }

        /// <summary>
        /// Adsorbent to target angle on knob release?
        /// </summary>
        bool Adsorbent { set; get; }

        /// <summary>
        /// Target adsorbent angles.
        /// </summary>
        float[] AdsorbableAngles { set; get; }

        /// <summary>
        /// Switch current angle.
        /// </summary>
        float Angle { get; }

        /// <summary>
        /// Knob current rotate percent base range.
        /// </summary>
        float Percent { get; }
        #endregion

        #region Event
        /// <summary>
        /// Knob drag event.
        /// </summary>
        event Action OnDrag;

        /// <summary>
        /// Knob release event.
        /// </summary>
        event Action OnRelease;

        /// <summary>
        /// Knob adsorbent event.
        /// </summary>
        event Action OnAdsorbent;
        #endregion
    }
}