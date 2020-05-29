/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
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
        #region Property
        /// <summary>
        /// Order IO.
        /// </summary>
        IOrderIO OrderIO { set; get; }

        /// <summary>
        /// Order parser.
        /// </summary>
        IOrderParser OrderParser { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Read orders from manager.
        /// </summary>
        /// <returns>Current orders.</returns>
        IEnumerable<Order> ReadOrders();

        /// <summary>
        /// Add order to manager.
        /// </summary>
        /// <param name="order">Order to add.</param>
        void AddOrder(Order order);

        /// <summary>
        /// Remove order from manager.
        /// </summary>
        /// <param name="order">Order to remove.</param>
        void RemoveOrder(Order order);

        /// <summary>
        /// Respond order to manager.
        /// </summary>
        /// <param name="order">Order to respond.</param>
        void RespondOrder(Order order);
        #endregion
    }
}