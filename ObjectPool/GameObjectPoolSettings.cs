/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPoolSettings.cs
 *  Description  :  Settings of GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.ObjectPool
{
    /// <summary>
    /// Settings of GameObjectPool.
    /// </summary>
    [Serializable]
    public struct GameObjectPoolSettings
    {
        #region Field and Property
        /// <summary>
        /// Name of pool.
        /// </summary>
        public string name;

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        public GameObject prefab;

        /// <summary>
        /// Max count limit of gameobjects in pool.
        /// </summary>
        public int maxCount;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of pool.</param>
        /// <param name="prefab">Prefab to create clone.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        public GameObjectPoolSettings(string name, GameObject prefab, int maxCount = 100)
        {
            this.name = name;
            this.prefab = prefab;
            this.maxCount = maxCount;
        }
        #endregion
    }
}