/*************************************************************************
 *  Copyright ? 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SinHose.cs
 *  Description  :  Render dynamic hose mesh base on sin curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/31/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCurve;
using UnityEngine;

namespace MGS.SkinnedMesh
{
    /// <summary>
    /// Render dynamic hose mesh base on sin curve.
    /// </summary>
    [AddComponentMenu("MGS/SkinnedMesh/SinHose")]
    public class SinHose : MonoCurveHose
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
        /// Curve for hose.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of hose.
        /// </summary>
        protected SinCurve curve = new SinCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild hose.
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