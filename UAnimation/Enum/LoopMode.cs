/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoopMode.cs
 *  Description  :  Loop mode of animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  03/25/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UAnimation
{
    /// <summary>
    /// Loop mode of animation.
    /// </summary>
    public enum LoopMode
    {
        /// <summary>
        /// Animation just play once.
        /// </summary>
        Once = 0,

        /// <summary>
        /// Animation loop play.
        /// </summary>
        Loop = 1,

        /// <summary>
        /// Animation play like ping pong.
        /// </summary>
        PingPong = 2,
    }
}