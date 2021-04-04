/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandManager.cs
 *  Description  :  Interface for Command manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command manager.
    /// </summary>
    public interface ICommandManager
    {
        #region Property
        /// <summary>
        /// Command IO.
        /// </summary>
        ICommandIO CommandIO { set; get; }

        /// <summary>
        /// Command parser.
        /// </summary>
        ICommandParser CommandParser { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Enqueue Command to pending buffer.
        /// </summary>
        /// <param name="Command">Command to enqueue.</param>
        void EnqueueCommand(Command Command);

        /// <summary>
        /// Discard Command from pending buffer.
        /// </summary>
        /// <param name="Command">Command to discard.</param>
        void DiscardCommand(Command Command);

        /// <summary>
        /// Dequeue Commands from pending buffer.
        /// </summary>
        /// <returns>Current Commands.</returns>
        IEnumerable<Command> DequeueCommands();

        /// <summary>
        /// Respond Command to manager.
        /// </summary>
        /// <param name="Command">Command to respond.</param>
        void RespondCommand(Command Command);
        #endregion
    }
}