/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderManager.cs
 *  Description  :  Interface for order manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.OrderServo
{
    /// <summary>
    /// Interface for order manager.
    /// </summary>
    public interface IOrderManager
    {
        #region Method
        /// <summary>
        /// Read orders from pending buffer.
        /// </summary>
        /// <returns>Current orders.</returns>
        IEnumerable<Order> ReadOrders();

        /// <summary>
        /// Add order to pending buffer.
        /// </summary>
        /// <param name="order">Order to add.</param>
        void AddOrder(Order order);

        /// <summary>
        /// Remove order from pending buffer.
        /// </summary>
        /// <param name="order">Order to remove.</param>
        void RemoveOrder(Order order);

        /// <summary>
        /// Send order to remote.
        /// </summary>
        /// <param name="order">Order to send.</param>
        void SendOrder(Order order);
        #endregion
    }
}