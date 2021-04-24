/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipsePath.cs
 *  Description  :  Define path base on ellipse curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCurve;
using UnityEngine;

namespace MGS.CurvePath
{
    /// <summary>
    /// Path base on ellipse curve.
    /// </summary>
    [AddComponentMenu("MGS/CurvePath/EllipsePath")]
    public class EllipsePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        [Tooltip("Semi minor axis of ellipse.")]
        public float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        [Tooltip("Semi major axis of ellipse.")]
        public float semiMajorAxis = 1.5f;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected EllipseCurve curve = new EllipseCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.args.semiMinorAxis = semiMinorAxis;
            curve.args.semiMajorAxis = semiMajorAxis;
            base.Rebuild();
        }
        #endregion
    }
}