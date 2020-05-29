/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ProcessUtility.cs
 *  Description  :  Utility for process.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/23/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MGS.Common.Diagnostics
{
    /// <summary>
    /// Utility for process.
    /// </summary>
    public sealed class ProcessUtility
    {
        /// <summary>
        /// Start process from file.
        /// </summary>
        /// <param name="fileName">Path of process file.</param>
        /// <returns>Succeed?</returns>
        public static bool StartProcess(string fileName)
        {
            if (!File.Exists(fileName))
            {
                LogUtility.LogError("Start process error: The file {0} does not exist.", fileName);
                return false;
            }

            try
            {
                Process.Start(fileName);
                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Start process exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Kill process by name.
        /// </summary>
        /// <param name="processName">Name of process.</param>
        /// <returns>Succeed?</returns>
        public static bool KillProcess(string processName)
        {
            if (string.IsNullOrEmpty(processName))
            {
                LogUtility.LogError("Kill process error: The process name is null or empty.");
                return false;
            }

            var processes = Process.GetProcessesByName(processName);
            if (processes == null || processes.Length == 0)
            {
                LogUtility.LogError("Kill process error: Can not find the process {0}.", processName);
                return false;
            }

            try
            {
                foreach (var process in processes)
                {
                    if (process.HasExited)
                    {
                        continue;
                    }

                    process.Kill();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Kill process exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Kill processes by names.
        /// </summary>
        /// <param name="processNames">Names of processes.</param>
        /// <returns>Succeed?</returns>
        public static bool KillProcess(IEnumerable<string> processNames)
        {
            if (processNames == null)
            {
                LogUtility.LogError("Kill processes error: The names of processes is null.");
                return false;
            }

            foreach (var processName in processNames)
            {
                if (!KillProcess(processName))
                {
                    return false;
                }
            }

            return true;
        }
    }
}