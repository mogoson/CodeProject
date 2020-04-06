/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderManager.cs
 *  Description  :  Manager of orders.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Manager of orders.
    /// </summary>
    public abstract class OrderManager : MonoBehaviour, IOrderManager
    {
        #region Field and Property
        /// <summary>
        /// Order pending buffer.
        /// </summary>
        protected List<Order> orderBuffer = new List<Order>();
        #endregion

        #region Public Method
        /// <summary>
        /// Read orders from pending buffer.
        /// </summary>
        /// <returns>Current orders.</returns>
        public virtual IEnumerable<Order> ReadOrders()
        {
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
        /// Send order to remote.
        /// </summary>
        /// <param name="order">Order to send.</param>
        public abstract void SendOrder(Order order);
        #endregion
    }
}