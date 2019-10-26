/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoAnimation.cs
 *  Description  :  Define mono animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.UAnimation
{
    /// <summary>
    /// Mono animation.
    /// </summary>
    public abstract class MonoAnimation : MonoBehaviour, IAnimation
    {
        #region Field and Property
        /// <summary>
        /// Speed of animation.
        /// </summary>
        [Tooltip("Speed of animation.")]
        [SerializeField]
        protected float speed = 5;

        /// <summary>
        /// Loop mode of animation.
        /// </summary>
        [Tooltip("Loop mode of animation.")]
        [SerializeField]
        protected LoopMode loop = LoopMode.Once;

        /// <summary>
        /// Speed of animation.
        /// </summary>
        public virtual float Speed
        {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// Loop mode of animation.
        /// </summary>
        public virtual LoopMode LoopMode
        {
            set { loop = value; }
            get { return loop; }
        }

        /// <summary>
        /// Animation is playing?
        /// </summary>
        public virtual bool IsPlaying
        {
            protected set;
            get;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Play animation.
        /// </summary>
        /// <param name="data">Animation data.</param>
        public virtual void Play(object data = null)
        {
            if (data != null)
            {
                Refresh(data);
            }
            enabled = IsPlaying = true;
        }

        /// <summary>
        /// Refresh animation.
        /// </summary>
        /// <param name="data">Animation data.</param>
        /// <returns>Succeed?</returns>
        public abstract bool Refresh(object data);

        /// <summary>
        /// Pause animation.
        /// </summary>
        public virtual void Pause()
        {
            enabled = IsPlaying = false;
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="progress">Progress of animation in the range[0~1]</param>
        public abstract void Rewind(float progress = 0);

        /// <summary>
        /// Stop animation.
        /// </summary>
        public virtual void Stop()
        {
            enabled = IsPlaying = false;
            Rewind(0);
        }
        #endregion
    }
}