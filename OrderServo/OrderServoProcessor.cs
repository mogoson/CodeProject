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

using MGS.UCommon.DesignPattern;
using System.Collections;
using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Order servo processor.
    /// </summary>
    public sealed class OrderServoProcessor : SingleUpdater<OrderServoProcessor>, IOrderServoProcessor
    {
        #region Field and Property
        /// <summary>
        /// Manager of orders.
        /// </summary>
        public IOrderManager OrderManager { set; get; }

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
        /// Manager of order units.
        /// </summary>
        private IOrderUnitManager orderUnitManager;
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private OrderServoProcessor() { }

        /// <summary>
        /// Processor update.
        /// </summary>
        protected override IEnumerator Update()
        {
            while (IsTurnOn)
            {
                var orders = OrderManager.ReadOrders();
                if (orders != null)
                {
                    foreach (var order in orders)
                    {
                        orderUnitManager.Execute(order);
                    }
                }

                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// On unit respond.
        /// </summary>
        /// <param name="order">Respond order.</param>
        private void OnUnitRespond(Order order)
        {
            OrderManager.RespondOrder(order);
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
        #endregion
    }
}