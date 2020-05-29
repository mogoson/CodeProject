/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUI.cs
 *  Description  :  Base class for mono UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/24/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Base class for mono UI.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public abstract class MonoUI : MonoBehaviour, IMonoUI
    {
        #region Field and Property
        /// <summary>
        /// RectTransform component of UI.
        /// </summary>
        public RectTransform RectTrans { private set; get; }

        /// <summary>
        /// RectTransform component of parent UI.
        /// </summary>
        public RectTransform ParentTrans { get { return transform.parent as RectTransform; } }

        /// <summary>
        /// UI is open?
        /// </summary>
        public virtual bool IsOpen { get { return gameObject.activeSelf; } }

        /// <summary>
        /// UI is disposed?
        /// </summary>
        public virtual bool IsDisposed { private set; get; }

        /// <summary>
        /// Event on open UI.
        /// </summary>
        public GenericEvent OnOpen { get; } = new GenericEvent();

        /// <summary>
        /// Event on close UI.
        /// </summary>
        public GenericEvent OnClose { get; } = new GenericEvent();
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake UI component.
        /// </summary>
        protected virtual void Awake()
        {
            RectTrans = transform as RectTransform;
        }

        /// <summary>
        /// On destroy UI.
        /// </summary>
        protected virtual void OnDestroy()
        {
            IsDisposed = true;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Open UI.
        /// </summary>
        public virtual void Open()
        {
            gameObject.SetActive(true);
            OnOpen.Invoke();
        }

        /// <summary>
        /// Close UI.
        /// </summary>
        /// <param name="dispose">Dispose UI on close?</param>
        public virtual void Close(bool dispose = false)
        {
            if (dispose)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
            OnClose.Invoke();
        }
        #endregion
    }
}