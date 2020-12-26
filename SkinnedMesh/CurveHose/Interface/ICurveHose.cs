/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICurveHose.cs
 *  Description  :  Define interface of curve hose.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCurve;

namespace MGS.SkinnedMesh
{
    /// <summary>
    /// Interface of curve hose.
    /// </summary>
    public interface ICurveHose : ICurve, ISkinnedMesh
    {
        #region Property
        /// <summary>
        /// Polygon of hose cross section.
        /// </summary>
        int Polygon { set; get; }

        /// <summary>
        /// Segment length of subdivide hose.
        /// </summary>
        float Segment { set; get; }

        /// <summary>
        /// Radius of hose mesh.
        /// </summary>
        float Radius { set; get; }

        /// <summary>
        /// Is seal at both ends of hose?
        /// </summary>
        bool Seal { set; get; }
        #endregion
    }
}