/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ILogger.cs
 *  Description  :  Interface of logger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/5/2015
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Common.Logger
{
    /// <summary>
    /// Interface of logger.
    /// </summary>
    public interface ILogger
    {
        #region Method
        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="level">Level of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        void Log(int level, string format, params object[] args);

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="level">Level of error message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        void LogError(int level, string format, params object[] args);

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="level">Level of warning message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        void LogWarning(int level, string format, params object[] args);
        #endregion
    }
}