/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoUpdater.cs
 *  Description  :  Interface for mono updater.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  04/11/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.DesignPattern
{
    /// <summary>
    /// Interface for mono updater.
    /// </summary>
    public interface IMonoUpdater
    {
        #region Property
        /// <summary>
        /// Updater is turn on?
        /// </summary>
        bool IsTurnOn { get; }

        /// <summary>
        /// Yield instruction.
        /// </summary>
        object YieldInstruction { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Turn on updater.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Turn off updater.
        /// </summary>
        void TurnOff();
        #endregion
    }
}