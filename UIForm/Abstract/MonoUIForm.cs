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

using MGS.Common.Enum;
using System;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom UI form base.
    /// </summary>
    [UIFormInfo(UIFromPattern.Single, "Default")]
    public abstract class MonoUIForm : MonoBehaviour, IUIForm
    {
        #region Field and Property
        /// <summary>
        /// GUID of form.
        /// </summary>
        public virtual string GUID { protected set; get; }

        /// <summary>
        /// The form is opened?
        /// </summary>
        public virtual bool IsOpened
        {
            get { return gameObject.activeSelf; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake UIForm.
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
            GUID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Open form.
        /// </summary>
        /// <param name="data">Data of form to show.</param>
        public virtual void Open(object data = null)
        {
            Refresh(data);
            gameObject.SetActive(true);
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
        /// <param name="language">Language name.</param>
        public virtual void Language(string language) { }

        /// <summary>
        /// Close form.
        /// </summary>
        /// <param name="destroy">Destroy form on closed?</param>
        public virtual void Close(bool destroy = false)
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        #endregion
    }
}