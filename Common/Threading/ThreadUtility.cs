/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
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
using System.Threading;

namespace MGS.Common.Threading
{
    /// <summary>
    /// Utility for thread.
    /// </summary>
    public sealed class ThreadUtility
    {
        /// <summary>
        /// Async Run action in thread.
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
    }
}