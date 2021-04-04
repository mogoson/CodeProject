/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandUnitManager.cs
 *  Description  :  Interface for Command units manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command units manager.
    /// </summary>
    public interface ICommandUnitManager
    {
        #region Property
        /// <summary>
        /// On Command respond.
        /// </summary>
        GenericEvent<Command> OnRespond { get; }
        #endregion

        #region Method
        /// <summary>
        /// Register Command unit.
        /// </summary>
        /// <param name="unit">Command unit.</param>
        void RegisterUnit(ICommandUnit unit);

        /// <summary>
        /// Unregister Command unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        void UnregisterUnit(string code);

        /// <summary>
        /// Unregister Command units.
        /// </summary>
        void UnregisterUnits();

        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="Command">Command to execute.</param>
        void Execute(Command Command);
        #endregion
    }
}