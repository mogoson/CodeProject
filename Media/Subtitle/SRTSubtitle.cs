/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SRTSubtitle.cs
 *  Description  :  SRT subtitle of video.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.IO;
using MGS.Common.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGS.Media.Subtitle
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
        public const int CLIP_LINES = 3;

        /// <summary>
        /// Separator of new line.
        /// </summary>
        public static readonly string[] NEWLINE_SEPARATOR = new string[] { "\r", "\n", "\r\n" };

        /// <summary>
        /// Separator of clip time range.
        /// </summary>
        public static readonly string[] TIMERANGE_SEPARATOR = new string[] { "-->" };

        /// <summary>
        /// Separator of clip time.
        /// </summary>
        public static readonly string[] TIME_SEPARATOR = new string[] { ":", "," };
        #endregion

        #region Protected Method
        /// <summary>
        /// Parse text to subtitle clip.
        /// </summary>
        /// <param name="index">Index text of clip.</param>
        /// <param name="timeRange">The text of clip time range.</param>
        /// <param name="centent">Content text of clip.</param>
        /// <returns>Subtitle clip.</returns>
        protected SubtitleClip ParseToClip(string index, string timeRange, string centent)
        {
            if (string.IsNullOrEmpty(index) || string.IsNullOrEmpty(timeRange))
            {
                LogUtility.LogError("Parse text to subtitle clip error: The index or timeRange is null.");
                return null;
            }

            if (!int.TryParse(index, out int clipIndex))
            {
                LogUtility.LogError("Parse text to subtitle clip error: The index \"{0}\" can not parse to int.", index);
                return null;
            }

            if (!ParseToTimeRange(timeRange, out int startTime, out int endTime))
            {
                LogUtility.LogError("Parse text to subtitle clip error: The timeRange \"{0}\" can not parse to start and end time.", timeRange);
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

            if (!int.TryParse(items[0], out int hours))
            {
                return false;
            }

            if (!int.TryParse(items[1], out int minute))
            {
                return false;
            }

            if (!int.TryParse(items[2], out int seconds))
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
        /// Set subtitle source.
        /// </summary>
        /// <param name="source">The source data of subtitle.</param>
        /// <param name="isFile">The source is a local file path?</param>
        public override void SetSource(string source, bool isFile = true)
        {
            ClearCache();

            string[] lines = null;
            if (isFile)
            {
                lines = FileUtility.ReadAllLines(source, Encoding.Default);
            }
            else
            {
                lines = source.Split(NEWLINE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
            }
            SetSource(lines);
        }

        /// <summary>
        /// Set source of srt subtitle.
        /// </summary>
        /// <param name="source">Data lines of srt subtitle.</param>
        /// <returns>Succeed?</returns>
        public void SetSource(string[] source)
        {
            ClearCache();

            if (source == null || source.Length < CLIP_LINES)
            {
                LogUtility.LogError("Set source of srt subtitle error: The content of source is null or invalid.");
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
}