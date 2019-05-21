/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FramesAnimation.cs
 *  Description  :  Define FramesAnimation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.UAnimation;
using System;
using UnityEngine;

namespace MGS.TwoDAnimation
{
    /// <summary>
    /// Animation base on key frames.
    /// </summary>
    public abstract class FramesAnimation : MonoAnimation
    {
        #region Field and Property
        /// <summary>
        /// Event of animation play on last frame.
        /// </summary>
        public event Action OnLastFrame;

        /// <summary>
        /// Index of current frame.
        /// </summary>
        protected float index = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Update animation.
        /// </summary>
        protected virtual void Update()
        {
            index += speed * Time.deltaTime;
            if (index < 0 || index >= GetFramesCount())
            {
                switch (loop)
                {
                    case LoopMode.Once:
                        enabled = false;
                        index = 0;
                        break;

                    case LoopMode.Loop:
                        index -= GetFramesCount() * (index < 0 ? -1 : 1);
                        break;

                    case LoopMode.PingPong:
                        speed = -speed;
                        index = Mathf.Clamp(index, 1, GetFramesCount() - 1);
                        break;
                }

                if (OnLastFrame != null)
                {
                    OnLastFrame.Invoke();
                }
            }
            else
            {
                SetFrame((int)index);
            }
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected abstract int GetFramesCount();

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected abstract void SetFrame(int frameIndex);
        #endregion

        #region Public Method
        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="progress">Progress of animation in the range[0~1]</param>
        public override void Rewind(float progress = 0)
        {
            progress = Mathf.Clamp01(progress);
            index = progress * (GetFramesCount() - 1);
            SetFrame((int)index);
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="frameIndex">Index of rewind frame.</param>
        public void Rewind(int frameIndex)
        {
            index = Mathf.Clamp(frameIndex, 0, GetFramesCount() - 1);
            SetFrame((int)index);
        }
        #endregion
    }
}