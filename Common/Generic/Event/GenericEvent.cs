/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GenericEvent.cs
 *  Description  :  Generic event.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
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
    /// <typeparam name="T">Specified type of event arg.</typeparam>
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
        /// <param name="arg">Arg of event.</param>
        public void Invoke(T arg)
        {
            callback?.Invoke(arg);
        }
        #endregion
    }

    /// <summary>
    /// Generic event.
    /// </summary>
    /// <typeparam name="T1">Specified type of event arg1.</typeparam>
    /// <typeparam name="T2">Specified type of event arg2.</typeparam>
    public class GenericEvent<T1, T2>
    {
        #region Field and Property
        /// <summary>
        /// Event callback.
        /// </summary>
        protected Action<T1, T2> callback;
        #endregion

        #region Public Method
        /// <summary>
        /// Add event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void AddListener(Action<T1, T2> callback)
        {
            this.callback += callback;
        }

        /// <summary>
        /// Remove event listener.
        /// </summary>
        /// <param name="callback">Event callback.</param>
        public void RemoveListener(Action<T1, T2> callback)
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
        /// <param name="arg1">Arg1 of event.</param>
        /// <param name="arg2">Arg2 of event.</param>
        public void Invoke(T1 arg1, T2 arg2)
        {
            callback?.Invoke(arg1, arg2);
        }
        #endregion
    }
}