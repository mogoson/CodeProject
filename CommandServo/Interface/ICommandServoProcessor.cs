/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandServoProcessor.cs
 *  Description  :  Interface for Command servo processor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.DesignPattern;

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command servo processor.
    /// </summary>
    public interface ICommandServoProcessor : IMonoUpdater
    {
        #region Property
        /// <summary>
        /// Manager of Commands.
        /// </summary>
        ICommandManager CommandManager { set; get; }

        /// <summary>
        /// Manager of Command units.
        /// </summary>
        ICommandUnitManager CommandUnitManager { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Initialize processor.
        /// </summary>
        /// <param name="CommandManager">Manager of Commands.</param>
        /// <param name="unitManager">Manager of Command units.</param>
        void Initialize(ICommandManager CommandManager, ICommandUnitManager unitManager);
        #endregion
    }
}