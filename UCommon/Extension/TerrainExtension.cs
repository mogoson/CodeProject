/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TerrainExtension.cs
 *  Description  :  Extension for UnityEngine.Terrain.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/29/2016
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.Extension
{
    /// <summary>
    /// Extension for UnityEngine.Terrain.
    /// </summary>
    public static class TerrainExtension
    {
        #region Public Method
        /// <summary>
        /// Normalize position relative to terrain.
        /// </summary>
        /// <param name="terrain">Base terrain.</param>
        /// <param name="woldPos">Position in wold space.</param>
        /// <returns>Normalize position.</returns>
        public static Vector3 NormalizeRelativePosition(this Terrain terrain, Vector3 woldPos)
        {
            var coord = woldPos - terrain.transform.position;
            return new Vector3(coord.x / terrain.terrainData.size.x, coord.y / terrain.terrainData.size.y, coord.z / terrain.terrainData.size.z);
        }

        /// <summary>
        /// Position relative to terrain map.
        /// </summary>
        /// <param name="terrain">Base terrain.</param>
        /// <param name="mapSize">Map size(x is width, z is height).</param>
        /// <param name="normalizePos">Normalize position relative to terrain.</param>
        /// <returns>Relative position.</returns>
        public static Vector3 MapRelativePosition(this Terrain terrain, Vector3 mapSize, Vector3 normalizePos)
        {
            return new Vector3(normalizePos.x * mapSize.x, 0, normalizePos.z * mapSize.z);
        }
        #endregion
    }
}