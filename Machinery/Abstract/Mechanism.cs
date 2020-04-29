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

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Base mechanism.
    /// </summary>
    public abstract class Mechanism : MonoBehaviour, IMechanism
    {
        #region Field And Property
        /// <summary>
        /// Mechanism is stuck?
        /// </summary>
        public virtual bool IsStuck { get { return CheckLimiters(); } }

        /// <summary>
        /// Limiters attached on mechanism.
        /// </summary>
        protected List<ILimiter> limiters = new List<ILimiter>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake mechanism.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }

        /// <summary>
        /// Check if one of limiters is triggered?
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckLimiters()
        {
            foreach (var limiter in limiters)
            {
                if (limiter.IsTriggered)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize mechanism.
        /// </summary>
        public virtual void Initialize()
        {
            limiters.AddRange(GetComponents<ILimiter>());
        }

        /// <summary>
        /// Drive mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public abstract void Drive(float velocity, DriveType type);
        #endregion
    }
}