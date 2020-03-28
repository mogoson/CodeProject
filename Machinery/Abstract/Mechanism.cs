/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Mechanism.cs
 *  Description  :  Define abstract mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/25/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Base mechanism.
    /// </summary>
    public abstract class Mechanism : MonoBehaviour, IMechanism
    {
        #region Protected Method
        /// <summary>
        /// Awake mechanism.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize mechanism.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Drive mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public abstract void Drive(float velocity, DriveType type);
        #endregion
    }
}