/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CircleHose.cs
 *  Description  :  Render dynamic hose mesh base on circle curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/18/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Curve;
using UnityEngine;

namespace MGS.SkinnedMesh
{
    /// <summary>
    /// Render dynamic hose mesh base on circle curve.
    /// </summary>
    [AddComponentMenu("MGS/SkinnedMesh/CircleHose")]
    public class CircleHose : MonoCurveHose
    {
        #region Field and Property
        /// <summary>
        /// Extend radius of hose curve.
        /// </summary>
        [Tooltip("Extend radius of hose curve.")]
        public float extendRadius = 1.0f;

        /// <summary>
        /// Curve for hose.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of hose.
        /// </summary>
        protected EllipseCurve curve = new EllipseCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild the mesh of hose.
        /// </summary>
        public override void Rebuild()
        {
            curve.args.semiMinorAxis = extendRadius;
            curve.args.semiMajorAxis = extendRadius;
            base.Rebuild();
        }
        #endregion
    }
}