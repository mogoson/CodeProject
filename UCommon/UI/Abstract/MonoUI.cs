/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUI.cs
 *  Description  :  Base class for mono UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/24/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.UCommon.UI
{
    /// <summary>
    /// Base class for mono UI.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public abstract class MonoUI : MonoBehaviour, IMonoUI
    {
        #region Field and Property
        /// <summary>
        /// UI is open?
        /// </summary>
        public bool IsOpen { protected set; get; }

        /// <summary>
        /// UI is disposed?
        /// </summary>
        public bool IsDisposed { protected set; get; }

        /// <summary>
        /// Event on open UI.
        /// </summary>
        public GenericEvent OnOpen { get; } = new GenericEvent();

        /// <summary>
        /// Event on close UI.
        /// </summary>
        public GenericEvent OnClose { get; } = new GenericEvent();

        /// <summary>
        /// RectTransform component of UI.
        /// </summary>
        public RectTransform rectTransform
        {
            get { return transform as RectTransform; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake UI.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize UI.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Open UI.
        /// </summary>
        /// <param name="data">Data for UI.</param>
        public virtual void Open(object data = null)
        {
            if (data != null)
            {
                Refresh(data);
            }
            gameObject.SetActive(true);
            IsOpen = true;
            OnOpen.Invoke();
        }

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="data">Data for UI.</param>
        public abstract void Refresh(object data);

        /// <summary>
        /// Close UI.
        /// </summary>
        /// <param name="dispose">Dispose UI on close?</param>
        public virtual void Close(bool dispose = false)
        {
            if (dispose)
            {
                Destroy(gameObject);
                IsDisposed = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
            IsOpen = false;
            OnClose.Invoke();
        }
        #endregion
    }
}