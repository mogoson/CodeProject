/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderServoProcessor.cs
 *  Description  :  Order servo processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.DesignPattern;

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

        /// <summary>
        /// The settings of processor is valid?
        /// </summary>
        private bool IsSettingsValid
        {
            get
            {
                if (OrderManager == null || orderUnitManager == null)
                {
                    LogUtility.LogError("Order servo processor settings error: " +
                        "The order manager or order unit manager does not set an instance.");
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Constructor.
        /// </summary>
        private OrderServoProcessor() { }

        /// <summary>
        /// On update.
        /// </summary>
        protected override void OnUpdate()
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var orders = OrderManager.ReadOrders();
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    orderUnitManager.Execute(order);
                }
            }
        }

        /// <summary>
        /// On unit respond.
        /// </summary>
        /// <param name="order">Respond order.</param>
        private void OnUnitRespond(Order order)
        {
            if (!IsSettingsValid)
            {
                return;
            }

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