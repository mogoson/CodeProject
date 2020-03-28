/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeepUpMode.cs
 *  Description  :  Mode of keep up.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// State of telescopic joint.
    /// </summary>
    public enum TelescopicState
    {
        /// <summary>
        /// Minimum state.
        /// </summary>
        Minimum = 0,

        /// <summary>
        /// State between minimum and maximum.
        /// </summary>
        Between = 1,

        /// <summary>
        /// Maximum state.
        /// </summary>
        Maximum = 2
    }
}