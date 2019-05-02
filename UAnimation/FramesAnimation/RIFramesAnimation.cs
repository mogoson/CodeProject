/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RIFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on RawImage.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UAnimation
{
    /// <summary>
    /// Sequence frames animation base on RawImage.
    /// </summary>
    [AddComponentMenu("MGS/UAnimation/RIFramesAnimation")]
    [RequireComponent(typeof(RawImage))]
    public class RIFramesAnimation : TFramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected RawImage rawImage;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rawImage = GetComponent<RawImage>();
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            rawImage.texture = frames[frameIndex];
        }
        #endregion
    }
}