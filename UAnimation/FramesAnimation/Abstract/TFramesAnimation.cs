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

namespace MGS.UAnimation
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
        /// <param name="frames">Animation frames, type is IEnumerable<Texture> or IEnumerable<Texture2D>.</param>
        public override void Refresh(object frames)
        {
            IEnumerable<Texture> newFrames = null;
            if (frames is IEnumerable<Texture>)
            {
                newFrames = frames as IEnumerable<Texture>;
            }
            else if (frames is IEnumerable<Texture2D>)
            {
                var frames2D = frames as IEnumerable<Texture2D>;
                var framesList = new List<Texture>();
                foreach (var frame in frames2D)
                {
                    framesList.Add(frame);
                }
                newFrames = framesList;
            }
            else
            {
                LogUtility.LogError("[TFramesAnimation] Refresh error: the type of frames is not IEnumerable<Texture> or IEnumerable<Texture2D>.");
                return;
            }

            this.frames.Clear();
            this.frames.AddRange(newFrames);
            Rewind(0);
        }
        #endregion
    }
}