/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TFramesAnimation.cs
 *  Description  :  Animation base on frames textutes.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/20/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.TwoDAnimation
{
    /// <summary>
    /// Animation base on frames textutes.
    /// </summary>
    public abstract class TFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Frames texture of animation.
        /// </summary>
        [Tooltip("Frames texture of animation.")]
        [SerializeField]
        protected List<Texture> frames = new List<Texture>();
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
        public virtual void SetFrames(IEnumerable<Texture> frames)
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