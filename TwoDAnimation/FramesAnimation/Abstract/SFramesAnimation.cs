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

using MGS.Common.Logger;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.TwoDAnimation
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
        /// Refresh frames texture of animation.
        /// </summary>
        /// <param name="frames">Animation frames, type is IEnumerable of Sprite.</param>
        public override void Refresh(object frames)
        {
            if (frames is IEnumerable<Sprite> newFrames)
            {
                this.frames.Clear();
                this.frames.AddRange(newFrames);
                Rewind(0);
            }
            else
            {
                LogUtility.LogError(0, "Refresh animation error: The type of frames is not IEnumerable<Sprite>.");
            }
        }
        #endregion
    }
}