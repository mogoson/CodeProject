/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderManager.cs
 *  Description  :  Manager of orders.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using System.Collections.Generic;

namespace MGS.OrderServo
{
    /// <summary>
    /// Manager of orders.
    /// </summary>
    public class OrderManager : IOrderManager
    {
        #region Field and Property
        /// <summary>
        /// Order IO.
        /// </summary>
        public IOrderIO OrderIO { set; get; }

        /// <summary>
        /// Order parser.
        /// </summary>
        public IOrderParser OrderParser { set; get; }

        /// <summary>
        /// Order pending buffer.
        /// </summary>
        protected List<Order> orderBuffer = new List<Order>();

        /// <summary>
        /// The settings of manager is valid?
        /// </summary>
        protected bool IsSettingsValid
        {
            get
            {
                if (OrderIO == null || OrderParser == null)
                {
                    LogUtility.LogError("OrderManager settings error: " +
                        "The order IO or order parser does not set an instance.");
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Read orders from pending buffer.
        /// </summary>
        /// <returns>Current orders.</returns>
        public virtual IEnumerable<Order> ReadOrders()
        {
            if (!IsSettingsValid)
            {
                return null;
            }

            var orderBytes = OrderIO.ReadBuffer();
            var ioOrders = OrderParser.ToOrders(orderBytes);
            if (ioOrders != null)
            {
                orderBuffer.AddRange(ioOrders);
            }

            var currentOrders = new List<Order>(orderBuffer);
            orderBuffer.Clear();
            return currentOrders;
        }

        /// <summary>
        /// Add order to pending buffer.
        /// </summary>
        /// <param name="order">Order to add.</param>
        public void AddOrder(Order order)
        {
            if (orderBuffer.Contains(order))
            {
                return;
            }

            orderBuffer.Add(order);
        }

        /// <summary>
        /// Remove order from pending buffer.
        /// </summary>
        /// <param name="order">Order to remove.</param>
        public void RemoveOrder(Order order)
        {
            orderBuffer.Remove(order);
        }

        /// <summary>
        /// Respond order to manager.
        /// </summary>
        /// <param name="order">Order to respond.</param>
        public virtual void RespondOrder(Order order)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var orderBytes = OrderParser.ToBuffer(order);
            OrderIO.WriteBuffer(orderBytes);
        }
        #endregion
    }
}