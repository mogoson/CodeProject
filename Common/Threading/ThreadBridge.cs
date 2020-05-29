/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ThreadBridge.cs
 *  Description  :  Bridge for thread.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/23/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;

namespace MGS.Common.Threading
{
    /// <summary>
    /// Bridge for thread.
    /// </summary>
    public sealed class ThreadBridge
    {
        #region Field and Property
        /// <summary>
        /// Queue for actions.
        /// </summary>
        private static Queue queue = new Queue();
        #endregion

        #region Public Method
        /// <summary>
        /// Enqueue an action.
        /// </summary>
        /// <param name="action">Register action.</param>
        public static void Enqueue(Action action)
        {
            if (action == null)
            {
                return;
            }

            lock (queue.SyncRoot)
            {
                queue.Enqueue(action);
            }
        }

        /// <summary>
        /// Dequeue all actions.
        /// </summary>
        public static void Dequeue()
        {
            if (queue.Count > 0)
            {
                lock (queue.SyncRoot)
                {
                    while (queue.Count > 0)
                    {
                        var action = queue.Dequeue() as Action;
                        action.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// Dequeue the number of count actions.
        /// </summary>
        /// <param name="count">Count of dequeue actions once.</param>
        public static void Dequeue(int count)
        {
            if (queue.Count > 0)
            {
                lock (queue.SyncRoot)
                {
                    var deCount = 0;
                    while (queue.Count > 0)
                    {
                        var action = queue.Dequeue() as Action;
                        action.Invoke();

                        deCount++;
                        if (deCount >= count)
                        {
                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}