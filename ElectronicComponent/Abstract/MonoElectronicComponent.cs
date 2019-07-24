/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoElectronicComponent.cs
 *  Description  :  Define MonoElectronicComponent.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Electronic component.
    /// </summary>
    public abstract class MonoElectronicComponent : MonoBehaviour, IElectronicComponent
    {
        #region Field and Property
        /// <summary>
        /// The component is enabled to control?
        /// </summary>
        [Tooltip("The component is enabled to control?")]
        [SerializeField]
        protected bool isEnabled = true;

        /// <summary>
        /// The component is enabled to control?
        /// </summary>
        public virtual bool Enabled
        {
            set { isEnabled = value; }
            get { return isEnabled; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize component.
        /// </summary>
        protected virtual void Initialize() { }
        #endregion
    }
}