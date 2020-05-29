/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Wininet.cs
 *  Description  :  API of wininet dll.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace MGS.WinLibrary
{
    /// <summary>
    /// API of wininet dll.
    /// </summary>
    public sealed class Wininet
    {
        #region Method
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <param name="lpdwFlags">Pointer to a variable that receives the connection description.</param>
        /// <param name="dwReserved">This parameter is reserved and must be 0.</param>
        /// <returns>Returns TRUE if there is an active modem or a LAN Internet connection,
        /// or FALSE if there is no Internet connection,
        /// or if all possible Internet connections are not currently active. </returns>
        [DllImport("wininet.dll")]
        public static extern Boolean InternetGetConnectedState(out UInt32 lpdwFlags, Int32 dwReserved);
        #endregion
    }

    /// <summary>
    /// Flags of internet connected state of the local system.
    /// </summary>
    public sealed class InetFlags
    {
        #region Field
        /// <summary>
        /// Local system has a valid connection to the Internet, but it might or might not be currently connected. 
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_CONFIGURED = 0x40;

        /// <summary>
        /// Local system uses a local area network to connect to the Internet.
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_LAN = 0x02;

        /// <summary>
        /// Local system uses a modem to connect to the Internet.
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_MODEM = 0x01;

        /// <summary>
        /// No longer used.
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_MODEM_BUSY = 0x08;

        /// <summary>
        /// Local system is in offline mode.
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_OFFLINE = 0x20;

        /// <summary>
        /// Local system uses a proxy server to connect to the Internet.
        /// </summary>
        public const UInt32 INTERNET_CONNECTION_PROXY = 0x04;

        /// <summary>
        /// Local system has RAS installed.
        /// </summary>
        public const UInt32 INTERNET_RAS_INSTALLED = 0x10;
        #endregion
    }
}