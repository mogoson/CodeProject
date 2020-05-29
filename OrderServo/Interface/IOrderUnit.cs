/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderUnit.cs
 *  Description  :  Interface for order Unit.
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
    /// Interface for order Unit.
    /// </summary>
    public interface IOrderUnit
    {
        #region Property
        /// <summary>
        /// Order unit code.
        /// </summary>
        string Code { set; get; }

        /// <summary>
        /// On order unit respond.
        /// </summary>
        GenericEvent<string, object> OnRespond { get; }
        #endregion

        #region Method
        /// <summary>
        /// Execute order.
        /// </summary>
        /// <param name="args">Order args.</param>
        void Execute(object args);
        #endregion
    }
}