/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtility.cs
 *  Description  :  Utility for log output.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/5/2015
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Common.Logger
{
    /// <summary>
    /// Utility for log output.
    /// </summary>
    public static class LogUtility
    {
        #region Field and Property
        /// <summary>
        /// Logger of utility.
        /// </summary>
        public static ILogger Logger { set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="level">Level of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void Log(int level, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.Log(level, format, args);
            }
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="level">Level of error message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogError(int level, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.LogError(level, format, args);
            }
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="level">Level of warning message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogWarning(int level, string format, params object[] args)
        {
            if (Logger != null)
            {
                Logger.LogWarning(level, format, args);
            }
        }
        #endregion
    }
}