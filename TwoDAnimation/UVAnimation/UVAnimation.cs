/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
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
using MGS.Common.UAnimation;
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
        public Vector2 coefficient = Vector2.one;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Private Method
        /// <summary>
        /// Component awake.
        /// </summary>
        protected virtual void Awake()
        {
            mRenderer = GetComponent<Renderer>();
        }

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
            var newFrames = frames as Texture;
            if (newFrames == null)
            {
                LogUtility.LogError(0, "Refresh animation error: The type of frames is not Texture.");
            }
            else
            {
                mRenderer.material.mainTexture = newFrames;
            }
        }
        #endregion
    }
}