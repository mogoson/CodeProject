/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SinPath.cs
 *  Description  :  Define path base on sin curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Curve;
using UnityEngine;

namespace MGS.CurvePath
{
    /// <summary>
    /// Path base on sin curve.
    /// </summary>
    [AddComponentMenu("MGS/CurvePath/SinPath")]
    public class SinPath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Args of sin curve.
        /// </summary>
        [Tooltip("Args of sin curve.")]
        public SinArgs args = new SinArgs(1, 1, 0, 0);

        /// <summary>
        /// Max key of sin curve.
        /// </summary>
        [Tooltip("Max key of sin curve.")]
        public float maxKey = 2;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected SinCurve curve = new SinCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.args = args;
            curve.MaxKey = maxKey * Mathf.PI;
            base.Rebuild();
        }
        #endregion
    }
}