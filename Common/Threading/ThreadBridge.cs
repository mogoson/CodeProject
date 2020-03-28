/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ThreadBridge.cs
 *  Description  :  Bridge for thread.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/23/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using System;
using System.Collections;

namespace MGS.Common.Threading
{
    /// <summary>
    /// Bridge for thread.
    /// </summary>
    internal sealed class ThreadBridge : Singleton<ThreadBridge>
    {
        #region Field and Property
        /// <summary>
        /// Queue for actions.
        /// </summary>
        private Queue queue = new Queue();
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private ThreadBridge() { }
        #endregion

        #region Public Method
        /// <summary>
        /// Enqueue action.
        /// </summary>
        /// <param name="action">Register action.</param>
        public void Enqueue(Action action)
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
        /// Dequeue actions.
        /// </summary>
        public void Dequeue()
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
        #endregion
    }
}