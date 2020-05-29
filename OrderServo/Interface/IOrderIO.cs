/*************************************************************************
 *  Copyright (c) 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IOrderIO.cs
 *  Description  :  Interface for order IO.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.OrderServo
{
    /// <summary>
    /// Interface for order IO.
    /// </summary>
    public interface IOrderIO
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