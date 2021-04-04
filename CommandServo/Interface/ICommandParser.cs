/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandParser.cs
 *  Description  :  Interface for Command parser.
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
    /// Interface for Command parser.
    /// </summary>
    public interface ICommandParser
    {
        #region Method
        /// <summary>
        /// Parser byte buffer to Commands.
        /// </summary>
        /// <param name="buffer">Buffer to parse.</param>
        /// <returns>Commands from buffer.</returns>
        IEnumerable<Command> ToCommands(byte[] buffer);

        /// <summary>
        /// Parser Command to byte buffer.
        /// </summary>
        /// <param name="Command">Command to parse.</param>
        /// <returns>Buffer from Command.</returns>
        byte[] ToBuffer(Command Command);
        #endregion
    }
}