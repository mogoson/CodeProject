/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderUnit.cs
 *  Description  :  Order unit.
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
    /// Order unit.
    /// </summary>
    public abstract class OrderUnit : IOrderUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of order unit.
        /// </summary>
        public virtual string Code { set; get; }

        /// <summary>
        /// On order unit respond.
        /// </summary>
        public GenericEvent<string, object> OnRespond { get; } = new GenericEvent<string, object>();
        #endregion

        #region Public Method
        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="args">Order args.</param>
        public abstract void Execute(object args);
        #endregion
    }
}