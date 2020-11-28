/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileLogger.cs
 *  Description  :  Loggger for log to local file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.IO;
using System;
using System.IO;

namespace MGS.Common.Logger
{
    /// <summary>
    /// Loggger for log to local file.
    /// </summary>
    public sealed class FileLogger : ILogger
    {
        #region Field and Property
        /// <summary>
        /// Root directory of log files.
        /// </summary>
        public string RootDir { get; } = Environment.CurrentDirectory + "/Log/";
        #endregion

        #region Private Method
        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="tag">Tag of log message.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        private void LogToFile(string tag, string format, params object[] args)
        {
            var logFile = string.Format("{0}/{1}/{2}.log", RootDir, DateTime.Now.Month, DateTime.Now.Date);
            var formatLog = string.Format("{0} - {1} - {2}\r\n", DateTime.Now, tag, string.Format(format, args));
            if (DirectoryUtility.RequireDirectory(logFile))
            {
                try
                {
                    File.AppendAllText(logFile, formatLog);
                }
#if DEBUG
                catch (Exception ex)
                {
                    throw ex;
                }
#else
                catch { }
#endif
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        public FileLogger() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootDir">Root directory of log files.</param>
        public FileLogger(string rootDir)
        {
            if (!Directory.Exists(rootDir))
            {
                try
                {
                    Directory.CreateDirectory(rootDir);
                }
#if DEBUG
                catch (Exception ex)
                {
                    throw ex;
                }
#else
                catch
                {
                    return;
                }
#endif
            }

            RootDir = rootDir;
        }

        /// <summary>
        /// Logs a formatted message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void Log(string format, params object[] args)
        {
            LogToFile("Log", format, args);
        }

        /// <summary>
        /// Logs a formatted error message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogError(string format, params object[] args)
        {
            LogToFile("Error", format, args);
        }

        /// <summary>
        /// Logs a formatted warning message to local file.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarning(string format, params object[] args)
        {
            LogToFile("Warning", format, args);
        }
        #endregion
    }
}