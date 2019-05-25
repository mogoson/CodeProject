/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ImgFramesAnimation.cs
 *  Description  :  Define sequence frames animation base Image.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.TwoDAnimation
{
    /// <summary>
    /// Sequence frames animation base on Image.
    /// </summary>
    [AddComponentMenu("MGS/TwoDAnimation/IFramesAnimation")]
    [RequireComponent(typeof(Image))]
    public class ImgFramesAnimation : SFramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Image image;
        #endregion

        #region Protected Method
        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            image.sprite = frames[frameIndex];
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize animation.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            image = GetComponent<Image>();
        }
        #endregion
    }
}