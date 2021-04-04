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
        protected List<Command> CommandBuffer = new List<Command>();

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
        /// Enqueue Command to pending buffer.
        /// </summary>
        /// <param name="Command">Command to enqueue.</param>
        public void EnqueueCommand(Command Command)
        {
            if (CommandBuffer.Contains(Command))
            {
                return;
            }

            CommandBuffer.Add(Command);
        }

        /// <summary>
        /// Discard Command from pending buffer.
        /// </summary>
        /// <param name="Command">Command to discard.</param>
        public void DiscardCommand(Command Command)
        {
            CommandBuffer.Remove(Command);
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

            var CommandBytes = CommandIO.ReadBuffer();
            var ioCommands = CommandParser.ToCommands(CommandBytes);
            if (ioCommands != null)
            {
                CommandBuffer.AddRange(ioCommands);
            }

            var currentCommands = new List<Command>(CommandBuffer);
            CommandBuffer.Clear();
            return currentCommands;
        }

        /// <summary>
        /// Respond Command to manager.
        /// </summary>
        /// <param name="Command">Command to respond.</param>
        public virtual void RespondCommand(Command Command)
        {
            if (!IsSettingsValid)
            {
                return;
            }

            var CommandBytes = CommandParser.ToBuffer(Command);
            CommandIO.WriteBuffer(CommandBytes);
        }
        #endregion
    }
}