/*************************************************************************
 *  Copyright ? 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICurve.cs
 *  Description  :  Define curve interface.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve
{
    /// <summary>
    /// Interface of curve.
    /// </summary>
    public interface ICurve
    {
        #region Property
        /// <summary>
        /// Length of curve.
        /// </summary>
        float Length { get; }

        /// <summary>
        /// Max key of curve.
        /// </summary>
        float MaxKey { get; }
        #endregion

        #region Method
        /// <summary>
        /// Get point on curve at key.
        /// </summary>
        /// <param name="key">Key of curve.</param>
        /// <returns>The point on curve at key.</returns>
        Vector3 GetPointAt(float key);
        #endregion
    }
}