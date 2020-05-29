/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SubtitleClip.cs
 *  Description  :  Clip of subtitle.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// Clip of subtitle.
    /// </summary>
    public class SubtitleClip
    {
        #region Field and Property
        /// <summary>
        /// Index of clip.
        /// </summary>
        public int Index { protected set; get; }

        /// <summary>
        /// Start time(Milliseconds) of clip.
        /// </summary>
        public int StartTime { protected set; get; }

        /// <summary>
        /// End time(Milliseconds) of clip.
        /// </summary>
        public int EndTime { protected set; get; }

        /// <summary>
        /// Content of Clip.
        /// </summary>
        public string Content { protected set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        public SubtitleClip() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="index">Index of clip.</param>
        /// <param name="startTime">Start time(Milliseconds) of clip.</param>
        /// <param name="endTime">End time(Milliseconds) of clip.</param>
        /// <param name="content">Content of Clip.</param>
        public SubtitleClip(int index, int startTime, int endTime, string content)
        {
            Index = index;
            StartTime = startTime;
            EndTime = endTime;
            Content = content;
        }

        /// <summary>
        /// Check clip state base on play time.
        /// </summary>
        /// <param name="time">Play time(Milliseconds).</param>
        /// <returns>Clip state.</returns>
        public virtual SubtitleClipState CheckState(int time)
        {
            var state = SubtitleClipState.Timely;
            if (time < StartTime)
            {
                state = SubtitleClipState.Premature;
            }
            else if (time > EndTime)
            {
                state = SubtitleClipState.Delayed;
            }
            return state;
        }
        #endregion
    }
}