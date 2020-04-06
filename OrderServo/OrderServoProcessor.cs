/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderServoProcessor.cs
 *  Description  :  Order servo processor.
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
    /// Order servo processor.
    /// </summary>
    [AddComponentMenu("MGS/OrderServo/OrderServoProcessor")]
    public abstract class OrderServoProcessor : MonoBehaviour, IOrderServoProcessor
    {
        #region Field and Property
        /// <summary>
        /// Manager of orders.
        /// </summary>
        public IOrderManager OrderManager
        {
            set { orderManager = value; }
            get { return orderManager; }
        }

        /// <summary>
        /// Manager of order units.
        /// </summary>
        public IOrderUnitManager OrderUnitManager
        {
            set
            {
                if (orderUnitManager != null)
                {
                    orderUnitManager.OnRespond.RemoveListener(OnUnitRespond);
                }

                if (value != null)
                {
                    value.OnRespond.AddListener(OnUnitRespond);
                }
                orderUnitManager = value;
            }
            get { return orderUnitManager; }
        }

        /// <summary>
        /// Processor is turn on?
        /// </summary>
        public bool IsTurnOn { get { return enabled; } }

        /// <summary>
        /// Manager of orders.
        /// </summary>
        protected IOrderManager orderManager;

        /// <summary>
        /// Manager of order units.
        /// </summary>
        protected IOrderUnitManager orderUnitManager;
        #endregion

        #region Private Method
        /// <summary>
        /// Processor update.
        /// </summary>
        protected virtual void Update()
        {
            var orders = orderManager.ReadOrders();
            if (orders == null)
            {
                return;
            }

            foreach (var order in orders)
            {
                orderUnitManager.Execute(order);
            }
        }

        /// <summary>
        /// On unit respond.
        /// </summary>
        /// <param name="order">Respond order.</param>
        protected virtual void OnUnitRespond(Order order)
        {
            orderManager.SendOrder(order);
        }
        #endregion

        #region Method
        /// <summary>
        /// Initialize processor.
        /// </summary>
        /// <param name="orderManager">Manager of orders.</param>
        /// <param name="unitManager">Manager of order units.</param>
        public void Initialize(IOrderManager orderManager, IOrderUnitManager unitManager)
        {
            OrderManager = orderManager;
            OrderUnitManager = unitManager;
        }

        /// <summary>
        /// Turn on processor.
        /// </summary>
        public void TurnOn()
        {
            enabled = true;
        }

        /// <summary>
        /// Turn off processor.
        /// </summary>
        public void TurnOff()
        {
            enabled = false;
        }
        #endregion
    }
}