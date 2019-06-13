/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Subtitle.cs
 *  Description  :  Subtitle of video.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/26/2019
 *  Description  :  Initial development version.
 *************************************************************************/

#if UNITY_EDITOR
using MGS.Common.Logger;
#endif

using System;
using System.Collections.Generic;

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// Subtitle of video.
    /// </summary>
    public abstract class Subtitle : ISubtitle
    {
        #region Field and Property
        /// <summary>
        /// Clips of this subtitle.
        /// </summary>
        protected List<ISubtitleClip> clips = new List<ISubtitleClip>();

        /// <summary>
        /// The last clip record.
        /// </summary>
        protected ISubtitleClip clip;
        #endregion

        #region Protected Method
        /// <summary>
        /// Check the play time is in this subtitle time range.
        /// </summary>
        /// <param name="time">Play time(Milliseconds).</param>
        /// <returns>Play time is in this subtitle time range?</returns>
        protected bool CheckRange(int time)
        {
            var isInRange = false;
            if (clips.Count > 0)
            {
                if (time >= clips[0].StartTime && time < clips[clips.Count - 1].EndTime)
                {
                    isInRange = true;
                }
#if UNITY_EDITOR
                else
                {
                    LogUtility.LogWarning(0, "The play time is out of the subtitle range.");
                }
#endif
            }
#if UNITY_EDITOR
            else
            {
                LogUtility.LogWarning(0, "Not any clip in the subtitle.");
            }
#endif
            return isInRange;
        }

        /// <summary>
        /// Find the timely clip. 
        /// </summary>
        /// <param name="time">Play time(Milliseconds).</param>
        /// <param name="start">Search start index.</param>
        /// <param name="end">Search end index.</param>
        /// <returns>Timely clip if find.</returns>
        protected ISubtitleClip FindClip(int time, int start, int end)
        {
            start = Math.Min(Math.Max(start, 0), clips.Count - 1);
            end = Math.Min(Math.Max(end, start), clips.Count - 1);

            for (int i = start; i <= end; i++)
            {
                var state = clips[start + i].CheckState(time);
                if (state == SubtitleClipState.Delayed)
                {
                    continue;
                }
                else if (state == SubtitleClipState.Timely)
                {
                    return clips[start + i];
                }
                else
                {
                    break;
                }
            }
            return null;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get subtitle clip content at play time.
        /// </summary>
        /// <param name="time">Play time(Milliseconds) of clip.</param>
        /// <returns>Subtitle clip content.</returns>
        public string GetClip(int time)
        {
            var content = string.Empty;
            if (CheckRange(time))
            {
                if (clip == null)
                {
                    clip = clips[Math.Max(clips.Count / 2 - 1, 0)];
                }

                var state = clip.CheckState(time);
                if (state == SubtitleClipState.Timely)
                {
                    content = clip.Content;
                }
                else
                {
                    int start = 0, end = 0;
                    if (state == SubtitleClipState.Delayed)
                    {
                        start = clip.Index + 1;
                        end = clips.Count - 1;
                    }
                    else
                    {
                        start = 0;
                        end = clip.Index - 1;
                    }

                    clip = FindClip(time, start, end);
                    content = (clip == null ? string.Empty : clip.Content);
                }
            }
            return content;
        }

        /// <summary>
        /// Refresh subtitle base on the data source.
        /// </summary>
        /// <param name="source">Data source to refresh subtitle.</param>
        public abstract void Refresh(object source);
        #endregion
    }
}