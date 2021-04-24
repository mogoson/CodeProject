/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DirectoryUtility.cs
 *  Description  :  Utility for directory.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using MGS.Common.Threading;
using System;
using System.Collections.Generic;
using System.IO;

namespace MGS.Common.IO
{
    /// <summary>
    /// Utility for directory.
    /// </summary>
    public sealed class DirectoryUtility
    {
        #region Public Method
        /// <summary>
        /// Require the directory of path exist.
        /// </summary>
        /// <param name="path">Directory or file path.</param>
        /// <returns>Succeed?</returns>
        public static bool RequireDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                LogUtility.LogError("Require directory error: The path is null or empty.");
                return false;
            }

            var dir = Path.GetDirectoryName(path);
            if (Directory.Exists(dir))
            {
                return true;
            }

            try
            {
                Directory.CreateDirectory(dir);
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Require directory exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Copy the children entries of source to dest directory.
        /// </summary>
        /// <param name="sourceDir">Source dir.</param>
        /// <param name="destDir">Dest dir.</param>
        /// <param name="ignores">Ignore files or directories.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public static void CopyChildrenEntries(string sourceDir, string destDir, IEnumerable<string> ignores = null,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            if (!Directory.Exists(sourceDir))
            {
                var error = string.Format("Copy children entries error: The source directory {0} does not exist.", sourceDir);
                completeCallback?.Invoke(false, error);
                return;
            }

            var entries = Directory.GetFileSystemEntries(sourceDir);
            if (entries == null || entries.Length == 0)
            {
                progressCallback?.Invoke(1.0f);
                completeCallback?.Invoke(true, destDir);
                return;
            }

            if (!Directory.Exists(destDir))
            {
                try
                {
                    Directory.CreateDirectory(destDir);
                }
                catch (Exception ex)
                {
                    var error = string.Format("Copy children entries exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                    completeCallback?.Invoke(false, error);
                    return;
                }
            }

            var ignoreList = new List<string>();
            if (ignores != null)
            {
                ignoreList.AddRange(ignores);
            }

            var finishCount = 0;
            foreach (var entrie in entries)
            {
                try
                {
                    //子目录
                    if (Directory.Exists(entrie))
                    {
                        var dirInfo = new DirectoryInfo(entrie);
                        if (!ignoreList.Contains(dirInfo.Name))
                        {
                            var cloneDirName = destDir + "/" + dirInfo.Name;
                            if (!Directory.Exists(cloneDirName))
                            {
                                Directory.CreateDirectory(cloneDirName);
                            }

                            CopyChildrenEntries(entrie, cloneDirName, ignores,
                                progress =>
                                {
                                    var childProgress = (finishCount + progress) / entries.Length;
                                    progressCallback?.Invoke(childProgress);
                                },
                                (succeed, info) =>
                                {
                                    if (!succeed)
                                    {
                                        completeCallback?.Invoke(succeed, info);
                                        return;
                                    }
                                    finishCount++;
                                });
                            continue;
                        }
                    }
                    else  //文件
                    {
                        var fileName = Path.GetFileName(entrie);
                        if (!ignoreList.Contains(fileName))
                        {
                            var cloneFileName = destDir + "/" + Path.GetFileName(entrie);
                            File.Copy(entrie, cloneFileName, true);
                        }
                    }

                    finishCount++;
                    var totalProgress = (float)finishCount / entries.Length;
                    progressCallback?.Invoke(totalProgress);
                }
                catch (Exception ex)
                {
                    var error = string.Format("Copy children entries exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                    completeCallback?.Invoke(false, error);
                }
            }

            completeCallback?.Invoke(true, destDir);
        }

        /// <summary>
        /// Copy the children entries of source to dest directory async.
        /// </summary>
        /// <param name="sourceDir">Source dir.</param>
        /// <param name="destDir">Dest dir.</param>
        /// <param name="ignores">Ignore files or directories.</param>
        /// <param name="guid">Guid of async threadGuid of async thread [System will automatically assign if it is null or empty].</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <returns>Guid of async thread.</returns>
        public static string CopyChildrenEntriesAsync(string sourceDir, string destDir, IEnumerable<string> ignores = null, string guid = null,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            guid = ThreadUtility.RunAsync(() =>
            {
                CopyChildrenEntries(sourceDir, destDir, ignores, progressCallback, completeCallback);
            }, guid);

            return guid;
        }

        /// <summary>
        /// Delete the children entries of the directory.
        /// </summary>
        /// <param name="destDir">Dest dir.</param>
        /// <param name="ignores">Ignore files or directories.</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        public static void DeleteChildrenEntries(string destDir, IEnumerable<string> ignores = null,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            if (!Directory.Exists(destDir))
            {
                var error = string.Format("Delete children entries error: The target dir {0} does not exist.", destDir);
                completeCallback?.Invoke(false, error);
                return;
            }

            var entries = Directory.GetFileSystemEntries(destDir);
            if (entries == null || entries.Length == 0)
            {
                progressCallback?.Invoke(1.0f);
                completeCallback?.Invoke(true, destDir);
                return;
            }

            var ignoreList = new List<string>();
            if (ignores != null)
            {
                ignoreList.AddRange(ignores);
            }

            var finishCount = 0;
            foreach (var entrie in entries)
            {
                try
                {
                    //子目录
                    if (Directory.Exists(entrie))
                    {
                        var dirInfo = new DirectoryInfo(entrie);
                        if (!ignoreList.Contains(dirInfo.Name))
                        {
                            dirInfo.Delete(true);
                        }
                    }
                    else  //文件
                    {
                        var fileName = Path.GetFileName(entrie);
                        if (!ignoreList.Contains(fileName))
                        {
                            File.Delete(entrie);
                        }
                    }

                    finishCount++;
                    var progress = (float)finishCount / entries.Length;
                    progressCallback?.Invoke(progress);
                }
                catch (Exception ex)
                {
                    var error = string.Format("Delete children entries error: {0}", ex.Message);
                    completeCallback?.Invoke(false, error);
                }
            }

            completeCallback?.Invoke(true, destDir);
        }

        /// <summary>
        /// Delete the children entries of the directory async.
        /// </summary>
        /// <param name="destDir">Dest dir.</param>
        /// <param name="ignores">Ignore files or directories.</param>
        /// <param name="guid">Guid of async threadGuid of async thread [System will automatically assign if it is null or empty].</param>
        /// <param name="progressCallback">Progress callback.</param>
        /// <param name="completeCallback">Complete callback.</param>
        /// <returns>Guid of async thread.</returns>
        public static string DeleteChildrenEntriesAsync(string destDir, IEnumerable<string> ignores = null, string guid = null,
            Action<float> progressCallback = null, Action<bool, string> completeCallback = null)
        {
            guid = ThreadUtility.RunAsync(() =>
            {
                DeleteChildrenEntries(destDir, ignores, progressCallback, completeCallback);
            }, guid);

            return guid;
        }

        /// <summary>
        /// Abort Async thread.
        /// </summary>
        /// <param name="guid">Guid of async thread.</param>
        public static void AbortAsync(string guid)
        {
            ThreadUtility.AbortAsync(guid);
        }
        #endregion
    }
}