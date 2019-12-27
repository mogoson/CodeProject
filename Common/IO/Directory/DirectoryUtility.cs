/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DirectoryUtility.cs
 *  Description  :  Utility for directory.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using System;
using System.IO;

namespace MGS.Common.IO
{
    /// <summary>
    /// Utility for directory.
    /// </summary>
    public static class DirectoryUtility
    {
        #region Public Method
        /// <summary>
        /// Require the directory path exist.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="error">Error message.</param>
        /// <returns>Create directory path succeed?</returns>
        public static bool RequirePath(string path, out string error)
        {
            if (string.IsNullOrEmpty(path))
            {
                error = "The path is null or empty.";
                LogUtility.LogError(0, "Require path error: {0}", error);
                return false;
            }

            error = string.Empty;
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
                error = ex.Message;
                LogUtility.LogError(0, "Require path exception: {0}", error);
                return false;
            }
        }

        /// <summary>
        /// Require the directory path exist.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <returns>Create directory path succeed?</returns>
        public static bool RequirePath(string path)
        {
            return RequirePath(path, out string error);
        }
        #endregion
    }
}