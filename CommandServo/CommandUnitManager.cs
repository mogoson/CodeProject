/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnitManager.cs
 *  Description  :  Manager of Command units.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.Logger;
using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Manager of Command units.
    /// </summary>
    public class CommandUnitManager : ICommandUnitManager
    {
        #region Field and Property
        /// <summary>
        /// On Command respond.
        /// </summary>
        public GenericEvent<Command> OnRespond { get; } = new GenericEvent<Command>();

        /// <summary>
        /// units managed by this manager.
        /// </summary>
        protected Dictionary<string, ICommandUnit> units = new Dictionary<string, ICommandUnit>();
        #endregion

        #region Private Method
        /// <summary>
        /// On Command unit respond.
        /// </summary>
        /// <param name="code">Command code.</param>
        /// <param name="args">Command args.</param>
        protected void OnUnitRespond(string code, params object[] args)
        {
            if (string.IsNullOrEmpty(code))
            {
                LogUtility.LogError("Unit respond error: The code is null or empty.");
                return;
            }

            OnRespond.Invoke(new Command(code, args));
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Register Command unit.
        /// </summary>
        /// <param name="unit">Command unit.</param>
        public void RegisterUnit(ICommandUnit unit)
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
        /// Unregister Command unit.
        /// </summary>
        /// <param name="code">Unit code.</param>
        public void UnregisterUnit(string code)
        {
            if (units.ContainsKey(code))
            {
                units[code].OnRespond.RemoveListener(OnUnitRespond);
                units.Remove(code);
            }
        }

        /// <summary>
        /// Unregister Command units.
        /// </summary>
        public void UnregisterUnits()
        {
            foreach (var unit in units.Values)
            {
                unit.OnRespond.RemoveListener(OnUnitRespond);
            }
            units.Clear();
        }

        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="Command">Command to execute.</param>
        public void Execute(Command Command)
        {
            if (units.ContainsKey(Command.code))
            {
                units[Command.code].Execute(Command.args);
            }
        }
        #endregion
    }
}