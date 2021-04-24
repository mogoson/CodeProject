﻿/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVAnimation.cs
 *  Description  :  Define UV offset animation.
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
    /// Animation base on UV offset.
    /// </summary>
    [AddComponentMenu("MGS/Animation/UVAnimation")]
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
        /// Awake animation.
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
        /// Set main texture of animation.
        /// </summary>
        /// <param name="mainTexture">Animation main texture.</param>
        public virtual void SetTexture(Texture mainTexture)
        {
            mRenderer.material.mainTexture = mainTexture;
        }
        #endregion
    }
}