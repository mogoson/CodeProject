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

using MGS.Common.Logger;
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
        /// Refresh frames texture of animation.
        /// </summary>
        /// <param name="frames">Animation frames, type is IEnumerable of Texture or Texture2D.</param>
        public override void Refresh(object frames)
        {
            if (frames is IEnumerable<Texture> newFrames) { }
            else if (frames is IEnumerable<Texture2D> frames2D)
            {
                var framesList = new List<Texture>();
                foreach (var frame in frames2D)
                {
                    framesList.Add(frame);
                }
                newFrames = framesList;
            }
            else
            {
                LogUtility.LogWarning(0, "Refresh animation failed: The type of frames is not IEnumerable<Texture> or IEnumerable<Texture2D>.");
                return;
            }

            this.frames.Clear();
            this.frames.AddRange(newFrames);
            Rewind(0);
        }
        #endregion
    }
}