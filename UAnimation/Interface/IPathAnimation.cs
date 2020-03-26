/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IPathAnimation.cs
 *  Description  :  Define interface for path animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.CurvePath;

namespace MGS.UAnimation
{
    /// <summary>
    /// Interface for path animation.
    /// </summary>
    public interface IPathAnimation : IAnimation
    {
        #region Property
        /// <summary>
        /// Path for animation base on.
        /// </summary>
        ICurvePath Path { set; get; }
        #endregion
    }
}