/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on Renderer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UAnimation
{
    /// <summary>
    /// Sequence frames animation base on Renderer.
    /// </summary>
    [AddComponentMenu("MGS/Animation/RFramesAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class RFramesAnimation : TFramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake animation.
        /// </summary>
        protected virtual void Awake()
        {
            mRenderer = GetComponent<Renderer>();
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            mRenderer.material.mainTexture = frames[frameIndex];
        }
        #endregion
    }
}