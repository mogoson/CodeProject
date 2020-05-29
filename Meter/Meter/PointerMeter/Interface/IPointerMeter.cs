/*************************************************************************
 *  Copyright (c) 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IPointerMeter.cs
 *  Description  :  Define interface of pointer meter.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Meter
{
    /// <summary>
    /// Interface of pointer meter.
    /// </summary>
    public interface IPointerMeter
    {
        #region Property
        /// <summary>
        /// Angle of meter main pointer.
        /// </summary>
        float MainAngle { set; get; }
        #endregion
    }
}