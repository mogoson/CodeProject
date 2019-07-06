/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVAnimation.cs
 *  Description  :  Define UV offset animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.UAnimation;
using UnityEngine;

namespace MGS.TwoDAnimation
{
    /// <summary>
    /// Animation base on UV offset.
    /// </summary>
    [AddComponentMenu("MGS/TwoDAnimation/UVAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class UVAnimation : MonoAnimation
    {
        #region Field and Property
        /// <summary>
        /// Speed coefficient of move uv map.
        /// </summary>
        [Tooltip("Speed coefficient of move uv map.")]
        public Vector2 coefficient = Vector2.one;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Private Method
        /// <summary>
        /// Component update.
        /// </summary>
        protected virtual void Update()
        {
            mRenderer.material.mainTextureOffset += speed * coefficient * Time.deltaTime;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize animation.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            mRenderer = GetComponent<Renderer>();
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        public override void Rewind(float progress = 0)
        {
            progress = Mathf.Clamp01(progress);
            Rewind(Vector2.one * progress);
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="uvOffset">UV map offset.</param>
        public void Rewind(Vector2 uvOffset)
        {
            mRenderer.material.mainTextureOffset = uvOffset;
        }

        /// <summary>
        /// Refresh frames sprite of animation.
        /// </summary>
        /// <param name="frames">Animation frames, type is Texture.</param>
        public override void Refresh(object frames)
        {
            if (frames is Texture newFrames)
            {
                mRenderer.material.mainTexture = newFrames;
            }
            else
            {
                LogUtility.LogWarning(0, "Refresh animation failed: The type of frames is not Texture.");
            }
        }
        #endregion
    }
}