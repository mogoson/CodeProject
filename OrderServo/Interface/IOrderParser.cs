/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderParser.cs
 *  Description  :  Interface for order parser.
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
    /// Interface for order parser.
    /// </summary>
    public interface IOrderParser
    {
        #region Method
        /// <summary>
        /// Parser byte buffer to orders.
        /// </summary>
        /// <param name="buffer">Buffer to parse.</param>
        /// <returns>Orders from buffer.</returns>
        IEnumerable<Order> ToOrders(byte[] buffer);

        /// <summary>
        /// Parser order to byte buffer.
        /// </summary>
        /// <param name="order">Order to parse.</param>
        /// <returns>Buffer from order.</returns>
        byte[] ToBuffer(Order order);
        #endregion
    }
}