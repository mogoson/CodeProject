/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUIPanel.cs
 *  Description  :  Custom UI panel base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.UCommon.Utility;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom UI panel base.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public abstract class MonoUIPanel : MonoBehaviour, IUIPanel
    {
        #region Field and Property
        /// <summary>
        /// Panel is open?
        /// </summary>
        public virtual bool IsOpen
        {
            get { return gameObject.activeSelf; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake panel.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize panel.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Open panel.
        /// </summary>
        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Mirror panel.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        public virtual void Mirror(MirrorMode mode)
        {
            RectUtility.Mirror(transform as RectTransform, mode);
        }

        /// <summary>
        /// Set language of panel.
        /// </summary>
        /// <param name="name">Language name.</param>
        public virtual void Language(string name) { }

        /// <summary>
        /// Close panel.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}