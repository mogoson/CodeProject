/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CompressManager.cs
 *  Description  :  Compress manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using MGS.Common.Threading;
using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Compress manager.
    /// </summary>
    public class CompressManager : Singleton<CompressManager>, ICompressManager
    {
        #region Field and Property
        /// <summary>
        /// Compressor for manager.
        /// </summary>
        public ICompressor Compressor { set; get; } = IonicCompressor.Instance;

        /// <summary>
        /// Max run count of async operate.
        /// </summary>
        public int MaxRunCount { set; get; } = 3;
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private CompressManager() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Compress entrie[File or Directory] to dest file async.
        /// </summary>
        /// <param name="entrie">Target entrie[File or Directory].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        /// <returns>Guid of async thread.</returns>
        public string CompressAsync(string entrie, string destFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compress entrie[Files or Directories] to dest file async.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        /// <returns>Guid of async thread.</returns>
        public string CompressAsync(IEnumerable<string> entries, string destFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

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
        public string DecompressAsync(string filePath, string destDir,
            bool clear = false, string guid = null,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            return ThreadUtility.RunAsync(() =>
            {

            }, string.Empty);
        }

        /// <summary>
        /// Abort Async thread.
        /// </summary>
        /// <param name="guid">Guid of async thread.</param>
        public void AbortAsync(string guid)
        {
            ThreadUtility.AbortAsync(guid);
        }
        #endregion
    }
}