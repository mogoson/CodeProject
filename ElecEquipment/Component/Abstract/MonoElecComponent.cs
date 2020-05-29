/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoElecComponent.cs
 *  Description  :  Define MonoElecComponent.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.ElecEquipment
{
    /// <summary>
    /// Electronic component.
    /// </summary>
    public abstract class MonoElecComponent : MonoBehaviour, IElecComponent
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
    }
}