/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderUnitManager.cs
 *  Description  :  Interface for order units manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;

namespace MGS.OrderServo
{
    /// <summary>
    /// Interface for order units manager.
    /// </summary>
    public interface IOrderUnitManager
    {
        #region Property
        /// <summary>
        /// On order respond.
        /// </summary>
        GenericEvent<Order> OnRespond { get; }
        #endregion

        #region Method
        /// <summary>
        /// Add order unit.
        /// </summary>
        /// <param name="unit">Order unit.</param>
        void AddUnit(IOrderUnit unit);

        /// <summary>
        /// Remove order unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        void RemoveUnit(string code);

        /// <summary>
        /// Clear order units.
        /// </summary>
        void ClearUnits();

        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="order">Order to execute.</param>
        void Execute(Order order);
        #endregion
    }
}