/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandIO.cs
 *  Description  :  Mono Command IO.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.CommandServo
{
    /// <summary>
    /// Mono Command IO.
    /// </summary>
    public abstract class MonoCommandIO : MonoBehaviour, ICommandIO
    {
        #region Public Method
        /// <summary>
        /// Read buffer from IO.
        /// </summary>
        /// <returns>Buffer from IO.</returns>
        public abstract byte[] ReadBuffer();

        /// <summary>
        /// Write buffer to IO.
        /// </summary>
        /// <param name="buffer">Buffer to IO.</param>
        public abstract void WriteBuffer(byte[] buffer);
        #endregion
    }
}