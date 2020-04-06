/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderServoProcessor.cs
 *  Description  :  Interface for order servo processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.OrderServo
{
    /// <summary>
    /// Interface for order servo processor.
    /// </summary>
    public interface IOrderServoProcessor
    {
        #region Property
        /// <summary>
        /// Manager of orders.
        /// </summary>
        IOrderManager OrderManager { set; get; }

        /// <summary>
        /// Manager of order units.
        /// </summary>
        IOrderUnitManager OrderUnitManager { set; get; }

        /// <summary>
        /// Processor is turn on?
        /// </summary>
        bool IsTurnOn { get; }
        #endregion

        #region Method
        /// <summary>
        /// Initialize processor.
        /// </summary>
        /// <param name="orderManager">Manager of orders.</param>
        /// <param name="unitManager">Manager of order units.</param>
        void Initialize(IOrderManager orderManager, IOrderUnitManager unitManager);

        /// <summary>
        /// Turn on processor.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Turn off processor.
        /// </summary>
        void TurnOff();
        #endregion
    }
}