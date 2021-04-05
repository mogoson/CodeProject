/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandManager.cs
 *  Description  :  Manager of Commands.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Logger;
using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Manager of Commands.
    /// </summary>
    public class CommandManager : ICommandManager
    {
        #region Field and Property
        /// <summary>
        /// Command IO.
        /// </summary>
        public ICommandIO CommandIO { set; get; }

        /// <summary>
        /// Command parser.
        /// </summary>
        public ICommandParser CommandParser { set; get; }

        /// <summary>
        /// Command pending buffer.
        /// </summary>
        protected List<Command> commandBuffer = new List<Command>();

        /// <summary>
        /// The settings of manager is valid?
        /// </summary>
        protected bool IsSettingsValid
        {
            get
            {
                if (CommandIO == null || CommandParser == null)
                {
                    LogUtility.LogError("CommandManager settings error: " +
                        "The Command IO or Command parser does not set an instance.");
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="commandIO">Command IO.</param>
        /// <param name="commandParser">Command parser.</param>
        public CommandManager(ICommandIO commandIO, ICommandParser commandParser)
        {
            CommandIO = commandIO;
            CommandParser = commandParser;
        }

        /// <summary>
        /// Enqueue Command to pending buffer.
        /// </summary>
        /// <param name="command">Command to enqueue.</param>
        public void EnqueueCommand(Command command)
        {
            if (commandBuffer.Contains(command))
            {
                return;
            }

            commandBuffer.Add(command);
        }

        /// <summary>
        /// Discard Command from pending buffer.
        /// </summary>
        /// <param name="command">Command to discard.</param>
        public void DiscardCommand(Command command)
        {
            commandBuffer.Remove(command);
        }

        /// <summary>
        /// Dequeue Commands from pending buffer.
        /// </summary>
        /// <returns>Current Commands.</returns>
        public virtual IEnumerable<Command> DequeueCommands()
        {
            if (!IsSettingsValid)
            {
                return null;
            }

            var commandBytes = CommandIO.ReadBuffer();
            var ioCommands = CommandParser.ToCommands(commandBytes);
            if (ioCommands != null)
            {
                commandBuffer.AddRange(ioCommands);
            }

            var currentCommands = new List<Command>(commandBuffer);
            commandBuffer.Clear();
            return currentCommands;
        }

        /// <summary>
        /// Respond Command to manager.
        /// </summary>
        /// <param name="command">Command to respond.</param>
        public virtual void RespondCommand(Command command)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var commandBytes = CommandParser.ToBuffer(command);
            CommandIO.WriteBuffer(commandBytes);
        }
        #endregion
    }
}