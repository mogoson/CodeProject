/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectPool.cs
 *  Description  :  Define GameObjectPool.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using UnityEngine;

namespace MGS.ObjectPool
{
    /// <summary>
    /// Pool of gameobject.
    /// </summary>
    public class GameObjectPool
    {
        #region Field and Property
        /// <summary>
        /// Parent of gameobjects.
        /// </summary>
        public Transform root;

        /// <summary>
        /// Prefab to create clone.
        /// </summary>
        public GameObject prefab;

        /// <summary>
        /// Max count limit of gameobjects in pool.
        /// </summary>
        public int MaxCount
        {
            set { pool.MaxCount = value; }
            get { return pool.MaxCount; }
        }

        /// <summary>
        /// Current count of gameobjects in pool.
        /// </summary>
        public int CurrentCount { get { return pool.CurrentCount; } }

        /// <summary>
        /// Pool of gameobjects.
        /// </summary>
        protected ObjectPool<GameObject> pool;
        #endregion

        #region Protected Method
        /// <summary>
        /// Create new clone gameobject.
        /// </summary>
        /// <returns>Clone gameobject.</returns>
        protected virtual GameObject Create()
        {
            var clone = Object.Instantiate(prefab);
            clone.transform.parent = root;
            return clone;
        }

        /// <summary>
        /// Reset gameobject to recycle state.
        /// </summary>
        /// <param name="obj">GameObject to reset.</param>
        protected virtual void Reset(GameObject obj)
        {
            obj.tag = prefab.tag;
            obj.layer = prefab.layer;

            obj.transform.position = prefab.transform.position;
            obj.transform.rotation = prefab.transform.rotation;

            obj.transform.parent = null;
            obj.transform.localScale = prefab.transform.localScale;
            obj.transform.parent = root;
        }

        /// <summary>
        /// Destroy gameobject.
        /// </summary>
        /// <param name="obj">Gameobject to destroy.</param>
        protected virtual void Dispose(GameObject obj)
        {
            Object.Destroy(obj);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Create and initialize GameObjectPool.
        /// </summary>
        public GameObjectPool()
        {
            pool = new ObjectPool<GameObject>(Create, Reset, Dispose);
        }

        /// <summary>
        /// Create and initialize GameObjectPool.
        /// </summary>
        /// <param name="root">Parent of gameobjects.</param>
        /// <param name="prefab">Prefab to create clone.</param>
        /// <param name="maxCount">Max count limit of gameobjects in pool.</param>
        public GameObjectPool(Transform root, GameObject prefab, int maxCount = 100)
        {
            this.root = root;
            this.prefab = prefab;
            pool = new ObjectPool<GameObject>(Create, Reset, Dispose, maxCount);
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <returns>A gameobject.</returns>
        public virtual GameObject Take()
        {
            var obj = pool.Take();
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <param name="position">Position of new gameobject.</param>
        /// <param name="rotation">Rotation of new gameobject.</param>
        /// <returns>A gameobject.</returns>
        public virtual GameObject Take(Vector3 position, Quaternion rotation)
        {
            var obj = pool.Take();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Take a gameobject from pool.
        /// </summary>
        /// <param name="parent">Parent of new gameobject.</param>
        /// <param name="localPosition">Local position of new gameobject.</param>
        /// <param name="localRotation">Local rotation of new gameobject.</param>
        /// <returns>A gameobject.</returns>
        public virtual GameObject Take(Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            var obj = pool.Take();
            obj.transform.parent = parent;
            obj.transform.localPosition = localPosition;
            obj.transform.localRotation = localRotation;
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Recycle gameobject to pool.
        /// </summary>
        /// <param name="obj">GameObject to recycle.</param>
        public virtual void Recycle(GameObject obj)
        {
            obj.SetActive(false);
            pool.Recycle(obj);
        }

        /// <summary>
        /// Clear the gameobjects.
        /// </summary>
        public virtual void Clear()
        {
            pool.Clear();
        }
        #endregion
    }
}