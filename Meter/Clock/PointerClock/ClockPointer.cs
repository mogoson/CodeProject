/*************************************************************************
 *  Copyright (c) 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ClockPointer.cs
 *  Description  :  Pointers of clock.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Pointers of clock.
    /// </summary>
    [Serializable]
    public struct ClockPointer
    {
        /// <summary>
        /// Hour pointer of clock.
        /// </summary>
        public Transform hour;

        /// <summary>
        /// Minute pointer of clock.
        /// </summary>
        public Transform minute;

        /// <summary>
        /// Second pointer of clock.
        /// </summary>
        public Transform second;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="hour">Hour pointer of clock.</param>
        /// <param name="minute">Minute pointer of clock.</param>
        /// <param name="second">Second pointer of clock.</param>
        public ClockPointer(Transform hour, Transform minute, Transform second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
}