/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderServoProcessorSocket.cs
 *  Description  :  Socket of order servo processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Socket of order servo processor.
    /// </summary>
    [AddComponentMenu("MGS/OrderServo/OrderServoProcessorSocket")]
    [RequireComponent(typeof(IOrderServoProcessor))]
    public class OrderServoProcessorSocket : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Manager of orders.
        /// </summary>
        [Tooltip("Manager of orders.")]
        [SerializeField]
        protected OrderManager orderManager;

        /// <summary>
        /// Manager of order units.
        /// </summary>
        [Tooltip("Manager of order units.")]
        [SerializeField]
        protected OrderUnitManager unitManager;
        #endregion

        #region Private Method
        /// <summary>
        /// Awake collector.
        /// </summary>
        protected virtual void Awake()
        {
            GetComponent<IOrderServoProcessor>().Initialize(orderManager, unitManager);
            Destroy(this);
        }
        #endregion
    }
}