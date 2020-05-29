/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  VectorUtility.cs
 *  Description  :  Utility for unity vector.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/1/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.Utility
{
    /// <summary>
    /// Utility for unity vector.
    /// </summary>
    public sealed class VectorUtility
    {
        #region Public Method
        /// <summary>
        /// Calculate project angle of two vectors in the range(0~360).
        /// </summary>
        /// <param name="from">Start vector.</param>
        /// <param name="to">End vector.</param>
        /// <param name="normal">Normal of plane to project.</param>
        /// <returns>Project angle of two vectors.</returns>
        public static float ProjectAngle(Vector3 from, Vector3 to, Vector3 normal)
        {
            //Project.
            from = Vector3.ProjectOnPlane(from, normal);
            to = Vector3.ProjectOnPlane(to, normal);

            //Project is Vector3.zero.
            if (from == Vector3.zero || to == Vector3.zero)
            {
                return 0;
            }

            //Calculate reference.
            var ftCross = Vector3.Cross(from, to);
            var toCross = Vector3.Cross(from, ftCross);
            var tcDot = Vector3.Dot(to, toCross);
            var ncDot = Vector3.Dot(normal, ftCross);

            //Convert to rotate angle.
            var angle = Vector3.Angle(from, to);
            if ((ncDot > 0 && tcDot >= 0) || (ncDot < 0 && tcDot <= 0))
            {
                angle = 360 - angle;
            }
            return angle;
        }
        #endregion
    }
}