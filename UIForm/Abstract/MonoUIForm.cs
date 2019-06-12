/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUIForm.cs
 *  Description  :  Custom UI form base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using System;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom UI form base.
    /// </summary>
    [UIFormInfo(UIFromPattern.Single, "Default")]
    [RequireComponent(typeof(RectTransform))]
    public abstract class MonoUIForm : MonoBehaviour, IUIForm
    {
        #region Field and Property
        /// <summary>
        /// ID of form.
        /// </summary>
        public string ID { protected set; get; }

        /// <summary>
        /// Form is open?
        /// </summary>
        public bool IsOpen { protected set; get; }

        /// <summary>
        /// Form is disposed?
        /// </summary>
        public bool IsDisposed { protected set; get; }

        /// <summary>
        /// Event on open form.
        /// </summary>
        public event Action OnOpen
        {
            add { onOpen += value; }
            remove { onOpen -= value; }
        }

        /// <summary>
        /// Event on close form.
        /// </summary>
        public event Action OnClose
        {
            add { onClose += value; }
            remove { onClose -= value; }
        }

        /// <summary>
        /// Event on open form.
        /// </summary>
        protected Action onOpen = null;

        /// <summary>
        /// Event on close form.
        /// </summary>
        protected Action onClose = null;
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake form.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize form.
        /// </summary>
        public virtual void Initialize()
        {
            ID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Open form.
        /// </summary>
        /// <param name="data">Data of form to show.</param>
        public virtual void Open(object data = null)
        {
            if (data != null)
            {
                Refresh(data);
            }
            gameObject.SetActive(true);
            IsOpen = true;
            onOpen?.Invoke();
        }

        /// <summary>
        /// Refresh form.
        /// </summary>
        /// <param name="data">Data of form to show.</param>
        public abstract void Refresh(object data);

        /// <summary>
        /// Mirror form.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        public virtual void Mirror(MirrorMode mode) { }

        /// <summary>
        /// Set language of form.
        /// </summary>
        /// <param name="name">Language name.</param>
        public virtual void Language(string name) { }

        /// <summary>
        /// Close form.
        /// </summary>
        /// <param name="dispose">Dispose form on close?</param>
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
            onClose?.Invoke();
        }
        #endregion
    }
}