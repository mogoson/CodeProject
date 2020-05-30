/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SharpCompressor.cs
 *  Description  :  Sharp compressor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace MGS.Compress
{
    /// <summary>
    /// Sharp compressor.
    /// </summary>
    public class SharpCompressor : Singleton<SharpCompressor>, ICompressor
    {
        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private SharpCompressor() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Compress entrie[File or Directory] to dest file.
        /// </summary>
        /// <param name="entrie">Target entrie[File or Directory].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        public void Compress(string entrie, string destFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compress entrie[Files or Directories] to dest file.
        /// </summary>
        /// <param name="entries">Target entrie[Files or Directories].</param>
        /// <param name="destFile">The dest file.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        public void Compress(IEnumerable<string> entries, string destFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decompress file to dest dir [Support zip, rar, tar, gzip, 7z].
        /// </summary>
        /// <param name="filePath">Target file.</param>
        /// <param name="destDir">The dest decompress directory.</param>
        /// <param name="clear">Clear the dest dir before decompress.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <param name="errorCallback">Error callback.</param>
        public void Decompress(string filePath, string destDir, bool clear = false,
              Action<float> progressCallback = null,
              Action<string> completeCallback = null,
              Action<string> errorCallback = null)
        {
            if (!File.Exists(filePath))
            {
                var error = string.Format("Decompress file error: Can not find the file in the path {0}", filePath);
                errorCallback?.Invoke(error);
                return;
            }

            if (string.IsNullOrEmpty(destDir))
            {
                var error = "Decompress file error: The dest directory can not be null or empty.";
                errorCallback?.Invoke(error);
                return;
            }

            try
            {
                if (clear)
                {
                    if (Directory.Exists(destDir))
                    {
                        Directory.Delete(destDir, true);
                    }
                }

                using (var archive = ArchiveFactory.Open(filePath))
                {
                    var totalSize = archive.TotalUncompressSize;
                    long unzipSize = 0;
                    archive.EntryExtractionEnd += (s, e) =>
                    {
                        unzipSize += e.Item.Size;
                        var progress = (float)unzipSize / totalSize;
                        progressCallback?.Invoke(progress);
                    };

                    var options = new ExtractionOptions()
                    {
                        Overwrite = true,
                        ExtractFullPath = true,
                        PreserveFileTime = false,
                        PreserveAttributes = false
                    };

                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            entry.WriteToDirectory(destDir, options);
                        }
                    }
                }

                completeCallback?.Invoke(destDir);
            }
            catch (Exception ex)
            {
                var error = string.Format("Decompress file exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                errorCallback?.Invoke(error);
            }
        }
        #endregion
    }
}