/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISubtitleClip.cs
 *  Description  :  Interface of subtitle clip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// Interface of subtitle clip.
    /// </summary>
    public interface ISubtitleClip
    {
        #region Property
        /// <summary>
        /// Index of clip.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Start time(Milliseconds) of clip.
        /// </summary>
        int StartTime { get; }

        /// <summary>
        /// End time(Milliseconds) of clip.
        /// </summary>
        int EndTime { get; }

        /// <summary>
        /// Content of Clip.
        /// </summary>
        string Content { get; }
        #endregion

        #region Method
        /// <summary>
        /// Check clip state base on play time.
        /// </summary>
        /// <param name="milliseconds">Play time(Milliseconds).</param>
        /// <returns>Clip state.</returns>
        SubtitleClipState CheckState(int milliseconds);
        #endregion
    }

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