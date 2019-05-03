/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SRTSubtitle.cs
 *  Description  :  SRT subtitle of video.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.IO;
using MGS.Common.Logger;
using System;
using System.Collections.Generic;

namespace MGS.Media
{
    /// <summary>
    /// SRT subtitle of video.
    /// </summary>
    public class SRTSubtitle : Subtitle
    {
        #region Field and Property
        /// <summary>
        /// Lines count of a clip.
        /// </summary>
        protected const int CLIP_LINES = 3;

        /// <summary>
        /// Separator of new line.
        /// </summary>
        protected static readonly string[] NEWLINE_SEPARATOR = new string[] { "\r", "\n", "\r\n" };

        /// <summary>
        /// Separator of clip time range.
        /// </summary>
        protected static readonly string[] TIMERANGE_SEPARATOR = new string[] { "-->" };

        /// <summary>
        /// Separator of clip time.
        /// </summary>
        protected static readonly string[] TIME_SEPARATOR = new string[] { ":", "," };
        #endregion

        #region Protected Method
        /// <summary>
        /// Parse text to subtitle clip.
        /// </summary>
        /// <param name="index">Index text of clip.</param>
        /// <param name="timeRange">The text of clip time range.</param>
        /// <param name="centent">Content text of clip.</param>
        /// <returns>Subtitle clip.</returns>
        protected ISubtitleClip ParseToClip(string index, string timeRange, string centent)
        {
            if (string.IsNullOrEmpty(index) || string.IsNullOrEmpty(timeRange))
            {
                return null;
            }

            var clipIndex = 0;
            if (!int.TryParse(index, out clipIndex))
            {
                return null;
            }

            var startTime = 0;
            var endTime = 0;
            if (!ParseToTimeRange(timeRange, out startTime, out endTime))
            {
                return null;
            }

            return new SubtitleClip(clipIndex, startTime, endTime, centent);
        }

        /// <summary>
        /// Parse text to the time range of subtitle clip.
        /// </summary>
        /// <param name="timeRange">The text of clip time range.</param>
        /// <param name="startTime">Start time(Milliseconds) of clip.</param>
        /// <param name="endTime">End time(Milliseconds) of clip.</param>
        /// <returns>Is parsed?</returns>
        protected bool ParseToTimeRange(string timeRange, out int startTime, out int endTime)
        {
            startTime = 0;
            endTime = 0;

            var times = timeRange.Split(TIMERANGE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            if (times.Length < 2)
            {
                return false;
            }

            if (ParseToTime(times[0], out startTime))
            {
                return false;
            }

            if (ParseToTime(times[1], out endTime))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parse text to the time of subtitle clip.
        /// </summary>
        /// <param name="timeText">The text of clip time.</param>
        /// <param name="time">Time(Milliseconds) of clip.</param>
        /// <returns>Is parsed?</returns>
        protected bool ParseToTime(string timeText, out int time)
        {
            time = 0;
            var items = timeText.Split(TIME_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length < 3)
            {
                return false;
            }

            var hours = 0;
            if (!int.TryParse(items[0], out hours))
            {
                return false;
            }

            var minute = 0;
            if (!int.TryParse(items[1], out minute))
            {
                return false;
            }

            var seconds = 0;
            if (!int.TryParse(items[2], out seconds))
            {
                return false;
            }

            var millisecond = 0;
            if (items.Length > 3)
            {
                int.TryParse(items[3], out millisecond);
            }

            time = ((hours * 60 + minute) * 60 + seconds) * 1000 + millisecond;
            return true;
        }

        /// <summary>
        /// Clear subtitle cache.
        /// </summary>
        protected virtual void ClearCache()
        {
            clips.Clear();
            clip = null;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh srt subtitle base on the data source.
        /// </summary>
        /// <param name="source">Data source(type is SRTSubtitleSource) to refresh srt subtitle.</param>
        public override void Refresh(object source)
        {
            ClearCache();

            var data = source as SRTSubtitleSource;
            if (data == null)
            {
                LogUtility.LogError("[SRTSubtitle] Refresh srt subtitle error: the type of source is not SRTSubtitleSource.");
                return;
            }

            if (string.IsNullOrEmpty(data.source))
            {
                LogUtility.LogError("[SRTSubtitle] Refresh srt subtitle error: the source data can not be null or empty.");
                return;
            }

            string[] lines = null;
            if (data.type == SRTSubtitleSourceType.File)
            {
                lines = FileUtility.ReadAllLines(data.source);
            }
            else
            {
                lines = data.source.Split(NEWLINE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            }
            Refresh(lines);
        }

        /// <summary>
        /// Refresh srt subtitle base on the data source.
        /// </summary>
        /// <param name="source">Data source to refresh srt subtitle.</param>
        public void Refresh(string[] source)
        {
            ClearCache();

            if (source == null || source.Length < CLIP_LINES)
            {
                LogUtility.LogError("[SRTSubtitle]  Refresh srt subtitle error: the content of source can not be null.");
                return;
            }

            var lines = new List<string>(source);
            while (lines.Count >= CLIP_LINES)
            {
                if (string.IsNullOrEmpty(lines[0]))
                {
                    lines.RemoveAt(0);
                    continue;
                }

                var newClip = ParseToClip(lines[0], lines[1], lines[2]);
                if (newClip == null)
                {
                    lines.RemoveAt(0);
                    continue;
                }
                else
                {
                    clips.Add(newClip);
                    lines.RemoveRange(0, CLIP_LINES);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Type of srt subtitle source.
    /// </summary>
    public enum SRTSubtitleSourceType
    {
        /// <summary>
        /// SRTSubtitle from file.
        /// </summary>
        File = 0,

        /// <summary>
        /// SRTSubtitle from text content.
        /// </summary>
        Text = 1
    }

    /// <summary>
    /// Source of srt subtitle.
    /// </summary>
    public class SRTSubtitleSource
    {
        /// <summary>
        /// Source of srt subtitle.
        /// </summary>
        public string source;

        /// <summary>
        /// Type of srt subtitle source.
        /// </summary>
        public SRTSubtitleSourceType type;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Source of srt subtitle.</param>
        /// <param name="type">Type of srt subtitle source.</param>
        public SRTSubtitleSource(string source, SRTSubtitleSourceType type = SRTSubtitleSourceType.File)
        {
            this.source = source;
            this.type = type;
        }
    }
}