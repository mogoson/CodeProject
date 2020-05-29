/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderUnitManager.cs
 *  Description  :  Manager of order units.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.Common.Logger;
using System.Collections.Generic;

namespace MGS.OrderServo
{
    /// <summary>
    /// Manager of order units.
    /// </summary>
    public class OrderUnitManager : IOrderUnitManager
    {
        #region Field and Property
        /// <summary>
        /// On order respond.
        /// </summary>
        public GenericEvent<Order> OnRespond { get; } = new GenericEvent<Order>();

        /// <summary>
        /// units managed by this manager.
        /// </summary>
        protected Dictionary<string, IOrderUnit> units = new Dictionary<string, IOrderUnit>();
        #endregion

        #region Private Method
        /// <summary>
        /// On order unit respond.
        /// </summary>
        /// <param name="code">Order code.</param>
        /// <param name="args">Order args.</param>
        protected void OnUnitRespond(string code, object args)
        {
            if (string.IsNullOrEmpty(code))
            {
                LogUtility.LogError("Unit respond error: The code is null or empty.");
                return;
            }

            OnRespond.Invoke(new Order(code, args));
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add order unit.
        /// </summary>
        /// <param name="unit">Order unit.</param>
        public void AddUnit(IOrderUnit unit)
        {
            if (unit == null || string.IsNullOrEmpty(unit.Code))
            {
                LogUtility.LogError("Add unit to manager error: The unit or code of unit is null or empty.");
                return;
            }

            unit.OnRespond.AddListener(OnUnitRespond);
            units.Add(unit.Code, unit);
        }

        /// <summary>
        /// Remove order unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        public void RemoveUnit(string code)
        {
            if (units.ContainsKey(code))
            {
                units[code].OnRespond.RemoveListener(OnUnitRespond);
                units.Remove(code);
            }
        }

        /// <summary>
        /// Clear order units.
        /// </summary>
        public void ClearUnits()
        {
            foreach (var unit in units.Values)
            {
                unit.OnRespond.RemoveListener(OnUnitRespond);
            }
            units.Clear();
        }

        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="order">Order to execute.</param>
        public void Execute(Order order)
        {
            if (units.ContainsKey(order.code))
            {
                units[order.code].Execute(order.args);
            }
        }
        #endregion
    }
}