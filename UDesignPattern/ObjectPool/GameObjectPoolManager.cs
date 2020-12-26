/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPoolManager.cs
 *  Description  :  Manager of gameobject pool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using MGS.Logger;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Manager of gameobject pool.
    /// </summary>
    public sealed class GameObjectPoolManager : Singleton<GameObjectPoolManager>
    {
        #region Field and Property
        /// <summary>
        /// Dictionary store pools info(name and pool).
        /// </summary>
        private Dictionary<string, GameObjectPool> poolsInfo = new Dictionary<string, GameObjectPool>();

        /// <summary>
        /// Root transform for pools.
        /// </summary>
        private Transform poolRoot;
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private GameObjectPoolManager()
        {
            //Create root for pools.
            poolRoot = new GameObject("GameObjectPool").transform;
            Object.DontDestroyOnLoad(poolRoot);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Create a pool in this manager.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <param name="prefab">Prefab of GameObjectPool.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        /// <returns>Pool created base on parameters.</returns>
        public GameObjectPool CreatePool(string name, GameObject prefab, int maxCount = 100)
        {
            if (string.IsNullOrEmpty(name))
            {
                LogUtility.LogError("Create pool error: The pool name can not be null or empty.");
                return null;
            }

            if (poolsInfo.ContainsKey(name))
            {
                LogUtility.LogWarning("Create pool cancelled: The pool that name is \"{0}\" already exist in this manager.", name);
                return poolsInfo[name];
            }

            if (prefab == null)
            {
                LogUtility.LogError("Create pool error: The prefab of pool can not be null.");
                return null;
            }

            //Create new gameobject for pool.
            var poolTrans = new GameObject(name).transform;
            poolTrans.parent = poolRoot;

            //Create new pool.
            var newPool = new GameObjectPool(poolTrans, prefab, maxCount);
            poolsInfo.Add(name, newPool);
            return newPool;
        }

        /// <summary>
        /// Find GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        /// <returns>Name match GameObjectPool.</returns>
        public GameObjectPool FindPool(string name)
        {
            if (poolsInfo.ContainsKey(name))
            {
                return poolsInfo[name];
            }
            else
            {
                LogUtility.LogWarning("Find pool error: The pool that name is \"{0}\" does not exist in this manager.", name);
                return null;
            }
        }

        /// <summary>
        /// Delete GameObjectPool by name.
        /// </summary>
        /// <param name="name">Name of GameObjectPool.</param>
        public void DeletePool(string name)
        {
            if (poolsInfo.ContainsKey(name))
            {
                Object.Destroy(poolsInfo[name].root.gameObject);
                poolsInfo.Remove(name);
            }
            else
            {
                LogUtility.LogWarning("Delete pool error: The pool that name is \"{0}\" does not exist in this manager.", name);
            }
        }
        #endregion
    }
}