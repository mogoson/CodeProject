/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandUnit.cs
 *  Description  :  Mono Command unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using UnityEngine;

namespace MGS.CommandServo
{
    /// <summary>
    /// Mono Command unit.
    /// </summary>
    public abstract class MonoCommandUnit : MonoBehaviour, ICommandUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of Command unit.
        /// </summary>
        [Tooltip("Code of Command unit.")]
        [SerializeField]
        protected string code;

        /// <summary>
        /// Code of Command unit.
        /// </summary>
        public string Code
        {
            set { code = value; }
            get { return code; }
        }

        /// <summary>
        /// On Command unit respond.
        /// </summary>
        public GenericEvent<string, object[]> OnRespond { get; } = new GenericEvent<string, object[]>();
        #endregion

        #region Public Method
        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="args">Command args.</param>
        public abstract void Execute(params object[] args);
        #endregion
    }
}