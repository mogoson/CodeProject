/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandIO.cs
 *  Description  :  Interface for Command IO.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.CommandServo
{
    /// <summary>
    /// Interface for Command IO.
    /// </summary>
    public interface ICommandIO
    {
        #region Method
        /// <summary>
        /// Read buffer from IO.
        /// </summary>
        /// <returns>Buffer from IO.</returns>
        byte[] ReadBuffer();

        /// <summary>
        /// Write buffer to IO.
        /// </summary>
        /// <param name="buffer">Buffer to IO.</param>
        void WriteBuffer(byte[] buffer);
        #endregion
    }
}