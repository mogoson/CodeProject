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
        /// <returns>Create directory path succeed?</returns>
        public static bool RequirePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                LogUtility.LogError(0, "[DirectoryUtility] RequirePath error: the path can not be null.");
                return false;
            }

            if (Directory.Exists(path))
            {
                return true;
            }

            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(0, "[DirectoryUtility] RequirePath error: {0}.", ex.Message);
                return false;
            }
        }
        #endregion
    }
}