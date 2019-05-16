/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FrameTextureData.cs
 *  Description  :  Define data of frame texture.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UAnimation
{
    /// <summary>
    /// Data of frame texture.
    /// </summary>
    public class FrameTextureData
    {
        /// <summary>
        /// Frames texture.
        /// </summary>
        public Texture frames;

        /// <summary>
        /// Row of frames.
        /// </summary>
        public int row;

        /// <summary>
        /// Column of frames.
        /// </summary>
        public int column;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="frames">Frames texture.</param>
        /// <param name="row">Row of frames.</param>
        /// <param name="column">Column of frames.</param>
        public FrameTextureData(Texture frames, int row, int column)
        {
            this.frames = frames;
            this.row = row;
            this.column = column;
        }
    }
}