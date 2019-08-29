/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericEvent.cs
 *  Description  :  Generic event.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/28/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Common.Generic
{
    /// <summary>
    /// Generic event.
    /// </summary>
    public class GenericEvent
    {
        #region Field and Property
        /// <summary>
        /// Event callback.
        /// </summary>
        protected Action callback;
        #endregion

        #region Public Method
        /// <summary>
        /// Add event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void AddListener(Action callback)
        {
            this.callback += callback;
        }

        /// <summary>
        /// Remove event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void RemoveListener(Action callback)
        {
            this.callback -= callback;
        }

        /// <summary>
        /// Remove all event listeners.
        /// </summary>
        public void RemoveListeners()
        {
            callback = null;
        }

        /// <summary>
        /// Invoke event.
        /// </summary>
        public void Invoke()
        {
            callback?.Invoke();
        }
        #endregion
    }

    /// <summary>
    /// Generic event.
    /// </summary>
    /// <typeparam name="T">Specified type of event data.</typeparam>
    public class GenericEvent<T>
    {
        #region Field and Property
        /// <summary>
        /// Event callback.
        /// </summary>
        protected Action<T> callback;
        #endregion

        #region Public Method
        /// <summary>
        /// Add event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void AddListener(Action<T> callback)
        {
            this.callback += callback;
        }

        /// <summary>
        /// Remove event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void RemoveListener(Action<T> callback)
        {
            this.callback -= callback;
        }

        /// <summary>
        /// Remove all event listeners.
        /// </summary>
        public void RemoveListeners()
        {
            callback = null;
        }

        /// <summary>
        /// Invoke event.
        /// </summary>
        /// <param name="data">Data of event.</param>
        public void Invoke(T data)
        {
            callback?.Invoke(data);
        }
        #endregion
    }
}