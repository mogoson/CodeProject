/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on UV offset.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using UnityEngine;

namespace MGS.TwoDAnimation
{
    /// <summary>
    /// Sequence frames animation base on UV offset.
    /// </summary>
    [AddComponentMenu("MGS/TwoDAnimation/UVFramesAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class UVFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Row of frames.
        /// </summary>
        [Tooltip("Row of frames.")]
        [SerializeField]
        protected int row = 2;

        /// <summary>
        /// Column of frames.
        /// </summary>
        [Tooltip("Column of frames.")]
        [SerializeField]
        protected int column = 5;

        /// <summary>
        /// Row of frames.
        /// </summary>
        public int Row { get { return row; } }

        /// <summary>
        /// Column of frames.
        /// </summary>
        public int Column { get { return column; } }

        /// <summary>
        /// Count of image frames.
        /// </summary>
        protected int framesCount;

        /// <summary>
        /// Width of a frame.
        /// </summary>
        protected float frameWidth;

        /// <summary>
        /// Height of a frame.
        /// </summary>
        protected float frameHeight;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Protected Method
        /// <summary>
        /// Initialize animation.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            mRenderer = GetComponent<Renderer>();
            framesCount = row * column;
            ApplyUVMaps();
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected override int GetFramesCount()
        {
            return framesCount;
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            mRenderer.material.mainTextureOffset = new Vector2(frameIndex % column * frameWidth, frameIndex / column * frameHeight);
        }

        /// <summary>
        /// Apply main textute uv maps.
        /// </summary>
        protected void ApplyUVMaps()
        {
            frameWidth = 1.0f / column;
            frameHeight = 1.0f / row;

            var material = mRenderer.material;
            material.mainTextureOffset = Vector2.zero;
            material.mainTextureScale = new Vector2(frameWidth, frameHeight);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh frames texture of animation.
        /// </summary>
        /// <param name="frames">Animation frames, type is FrameTextureData.</param>
        /// <returns>Succeed?</returns>
        public override bool Refresh(object frames)
        {
            if (frames is FrameTextureData newFrames)
            {
                SetSourceFrames(newFrames.frames, newFrames.row, newFrames.column);
            }
            else
            {
                LogUtility.LogWarning(0, "Refresh animation failed: The type of frames is not FrameTextureData.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set source frames of animation.
        /// </summary>
        /// <param name="frames">Frames texture.</param>
        /// <param name="row">Row of frames.</param>
        /// <param name="column">Column of frames.</param>
        public void SetSourceFrames(Texture frames, int row, int column)
        {
            this.row = row;
            this.column = column;
            framesCount = row * column;
            mRenderer.material.mainTexture = frames;
            ApplyUVMaps();
        }
        #endregion
    }
}