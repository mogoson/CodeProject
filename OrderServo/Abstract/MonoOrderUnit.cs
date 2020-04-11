/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoOrderUnit.cs
 *  Description  :  Mono order unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Mono order unit.
    /// </summary>
    public abstract class MonoOrderUnit : MonoBehaviour, IOrderUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of order unit.
        /// </summary>
        [Tooltip("Code of order unit.")]
        [SerializeField]
        protected string code;

        /// <summary>
        /// Code of order unit.
        /// </summary>
        public string Code
        {
            set { code = value; }
            get { return code; }
        }

        /// <summary>
        /// On order unit respond.
        /// </summary>
        public GenericEvent<string, object> OnRespond { get; } = new GenericEvent<string, object>();
        #endregion

        #region Public Method
        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="args">Order args.</param>
        public abstract void Execute(object args);
        #endregion
    }
}