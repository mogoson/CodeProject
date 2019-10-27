/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISubtitle.cs
 *  Description  :  Interface of subtitle.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Media.Subtitle
{
    /// <summary>
    /// Interface of subtitle.
    /// </summary>
    public interface ISubtitle
    {
        #region Method
        /// <summary>
        /// Set subtitle source.
        /// </summary>
        /// <param name="source">The source data of subtitle.</param>
        /// <param name="isFile">The source is a local file path?</param>
        void SetSource(string source, bool isFile = true);

        /// <summary>
        /// Get subtitle clip content at play time.
        /// </summary>
        /// <param name="time">Play time(Milliseconds) of clip.</param>
        /// <returns>Subtitle clip content.</returns>
        string GetClip(int time);
        #endregion
    }
}