/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICompressManager.cs
 *  Description  :  Interface for compress manager.
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
    /// Interface for compress manager.
    /// </summary>
    public interface ICompressManager
    {
        #region Property
        /// <summary>
        /// Compressor for manager.
        /// </summary>
        ICompressor Compressor { set; get; }

        /// <summary>
        /// Max run count of async operate.
        /// </summary>
        int MaxRunCount { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Compress entrie[File or Directory] to dest file async.
        /// </summary>
        /// <param name="entrie">Target entrie[File or Directory].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        /// <returns>Guid of async thread.</returns>
        string CompressAsync(string entrie, string destFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// Compress entrie[Files or Directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        /// <returns>Guid of async thread.</returns>
        string CompressAsync(IEnumerable<string> entries, string destFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// Decompress file to dest dir async.
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="guid">Guid of async thread [System will automatically assign if it is null or empty].</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        /// <returns>Guid of async thread.</returns>
        string DecompressAsync(string filePath, string destDir,
            bool clear = false, string guid = null,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null);

        /// <summary>
        /// Abort Async thread.
        /// </summary>
        /// <param name="guid">Guid of async thread.</param>
        void AbortAsync(string guid);
        #endregion
    }
}