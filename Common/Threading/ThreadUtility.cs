/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ThreadUtility.cs
 *  Description  :  Utility for thread.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/23/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;

namespace MGS.Common.Threading
{
    /// <summary>
    /// Utility for thread.
    /// </summary>
    public sealed class ThreadUtility
    {
        #region Field and Property
        /// <summary>
        /// Dictionary for asyncs.
        /// </summary>
        private static Dictionary<string, Thread> asyncs = new Dictionary<string, Thread>();
        #endregion

        /// <summary>
        /// Async run action in a thread.
        /// </summary>
        /// <param name="action">Run action.</param>
        /// <returns>Thread instance.</returns>
        public static Thread RunAsync(Action action)
        {
            if (action == null)
            {
                return null;
            }

            var thread = new Thread(new ThreadStart(action)) { IsBackground = true };
            thread.Start();

            return thread;
        }

        /// <summary>
        /// Async run action in a thread.
        /// </summary>
        /// <param name="action">Run action.</param>
        /// <param name="guid">Guid of async thread [System will automatically assign if it is null or empty].</param>
        /// <returns>Thread instance.</returns>
        public static string RunAsync(Action action, string guid = null)
        {
            if (action == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(guid))
            {
                guid = Guid.NewGuid().ToString();
            }

            var thread = new Thread(() =>
            {
                action.Invoke();

                if (asyncs.ContainsKey(guid))
                {
                    asyncs.Remove(guid);
                }
            })
            { IsBackground = true };

            if (asyncs.ContainsKey(guid))
            {
                asyncs[guid] = thread;
            }
            else
            {
                asyncs.Add(guid, thread);
            }

            thread.Start();
            return guid;
        }

        /// <summary>
        /// Abort Async thread.
        /// </summary>
        /// <param name="guid">Guid of async thread.</param>
        public static void AbortAsync(string guid)
        {
            if (asyncs.ContainsKey(guid))
            {
                asyncs[guid].Abort();
            }
        }
    }
}