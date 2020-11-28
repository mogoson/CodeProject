/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LogUtility.cs
 *  Description  :  Utility for log output.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/5/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.Common.Logger
{
    /// <summary>
    /// Utility for log output.
    /// </summary>
    public sealed class LogUtility
    {
        #region Field and Property
        /// <summary>
        /// Loggers of utility.
        /// </summary>
        private static ICollection<ILogger> loggers = new List<ILogger>() { new FileLogger() };
        #endregion

        #region Public Method
        /// <summary>
        /// Add logger to utility.
        /// </summary>
        /// <param name="logger">Logger for output message.</param>
        public static void AddLogger(ILogger logger)
        {
            if (logger == null)
            {
                return;
            }

            if (loggers.Contains(logger))
            {
                return;
            }

            loggers.Add(logger);
        }

        /// <summary>
        /// Remove logger from utility.
        /// </summary>
        /// <param name="logger">Logger for output message.</param>
        public static void RemoveLogger(ILogger logger)
        {
            if (loggers.Contains(logger))
            {
                loggers.Remove(logger);
            }
        }

        /// <summary>
        /// Clear the loggers of utility.
        /// </summary>
        public static void ClearLoggers()
        {
            loggers.Clear();
        }

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void Log(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.Log(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogError(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.LogError(format, args);
            }
        }

        /// <summary>
        /// Logs a formatted warning message.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public static void LogWarning(string format, params object[] args)
        {
            foreach (var logger in loggers)
            {
                logger.LogWarning(format, args);
            }
        }
        #endregion
    }
}