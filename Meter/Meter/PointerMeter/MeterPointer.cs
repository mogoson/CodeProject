/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MeterPointer.cs
 *  Description  :  Define meter pointer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Meter
{
    /// <summary>
    /// Meter Pointer.
    /// </summary>
    [Serializable]
    public struct MeterPointer
    {
        /// <summary>
        /// Transform of meter pointer.
        /// </summary>
        public Transform pointerTrans;

        /// <summary>
        /// Ratio of meter pointer.
        /// </summary>
        public float pointerRatio;

        /// <summary>
        /// Constructor of MeterPointer.
        /// </summary>
        /// <param name="pointerTrans">Transform of meter pointer.</param>
        /// <param name="pointerRatio">Ratio of meter pointer.</param>
        public MeterPointer(Transform pointerTrans, float pointerRatio)
        {
            this.pointerTrans = pointerTrans;
            this.pointerRatio = pointerRatio;
        }
    }
}