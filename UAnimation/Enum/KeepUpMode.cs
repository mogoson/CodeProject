/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeepUpMode.cs
 *  Description  :  Define Keep up mode of animation base on curve path.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UAnimation
{
    /// <summary>
    /// Keep up mode of animation base on curve path.
    /// </summary>
    public enum KeepUpMode
    {
        /// <summary>
        /// Keep up as world up.
        /// </summary>
        WorldUp = 0,

        /// <summary>
        /// Keep up as transform up.
        /// </summary>
        TransformUp = 1,

        /// <summary>
        /// Keep up as reference forward.
        /// </summary>
        ReferenceForward = 2,

        /// <summary>
        /// Keep up as the cross of tangent and reference forward.
        /// </summary>
        ReferenceForwardAsNormal = 3
    }
}