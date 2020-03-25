/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SFramesAnimation.cs
 *  Description  :  Animation base on frames sprites.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/20/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UAnimation
{
    /// <summary>
    /// Animation base on frames sprites.
    /// </summary>
    public abstract class SFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Frames sprite of animation.
        /// </summary>
        [Tooltip("Frames sprite of animation.")]
        [SerializeField]
        protected List<Sprite> frames = new List<Sprite>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Get frames count.
        /// </summary>
        /// <returns>Frames count.</returns>
        protected override int GetFramesCount()
        {
            return frames.Count;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Set frames texture of animation.
        /// </summary>
        /// <param name="frames">Animation frames.</param>
        public virtual void SetFrames(IEnumerable<Sprite> frames)
        {
            if (frames == null)
            {
                return;
            }

            this.frames.Clear();
            this.frames.AddRange(frames);
        }
        #endregion
    }
}