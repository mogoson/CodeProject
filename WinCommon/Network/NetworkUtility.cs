/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WinNetworkUtility.cs
 *  Description  :  Utility for windows network.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.WinLibrary;

namespace MGS.WinCommon.Network
{
    /// <summary>
    /// Utility for windows network.
    /// </summary>
    public static class NetworkUtility
    {
        #region Public Method
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <returns>The connected state of the local system.</returns>
        public static NetworkConnState GetNetworkConnectState()
        {
            if (Wininet.InternetGetConnectedState(out uint lpdwFlags, 0))
            {
                if ((lpdwFlags & InetFlags.INTERNET_CONNECTION_MODEM) != 0)
                {
                    return NetworkConnState.ONLINE_MODEM;
                }
                else if ((lpdwFlags & InetFlags.INTERNET_CONNECTION_LAN) != 0)
                {
                    return NetworkConnState.ONLINE_LAN;
                }
            }
            return NetworkConnState.OFFLINE;
        }
        #endregion
    }
}