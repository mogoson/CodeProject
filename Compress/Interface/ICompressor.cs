/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICompressor.cs
 *  Description  :  Interface for compressor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Interface for compressor.
    /// </summary>
    public interface ICompressor
    {
        #region Method
        /// <summary>
        /// Compress entrie[File or Directory] to dest file.
        /// </summary>
        /// <param name="entrie">Target entrie[File or Directory].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        void Compress(string entrie, string destFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// Compress entrie[Files or Directories] to dest file.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        void Compress(IEnumerable<string> entries, string destFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// Decompress file to dest dir.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        void Decompress(string filePath, string destDir, bool clear = false,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null);
        #endregion
    }
}