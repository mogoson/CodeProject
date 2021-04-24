/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SubtitleClipState.cs
 *  Description  :  State of subtitle clip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// State of subtitle clip base on current play time.
    /// </summary>
    public enum SubtitleClipState
    {
        /// <summary>
        /// Clip is delayed.
        /// </summary>
        Delayed = 0,

        /// <summary>
        /// Clip is timely.
        /// </summary>
        Timely = 1,

        /// <summary>
        /// Clip is premature.
        /// </summary>
        Premature = 2
    }
}