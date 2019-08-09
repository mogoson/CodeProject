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

namespace MGS.WinUCommon.WinNetwork
{
    /// <summary>
    /// Utility for windows network.
    /// </summary>
    public static class WinNetworkUtility
    {
        #region Public Method
        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <returns>The connected state of the local system.</returns>
        public static WinNetworkConnState GetNetworkConnectState()
        {
            if (WinInet.InternetGetConnectedState(out int lpdwFlags, 0))
            {
                if ((lpdwFlags & WinInet.INTERNET_CONNECTION_MODEM) != 0)
                {
                    return WinNetworkConnState.MODEM;
                }
                else if ((lpdwFlags & WinInet.INTERNET_CONNECTION_LAN) != 0)
                {
                    return WinNetworkConnState.LAN;
                }
            }
            return WinNetworkConnState.OFFLINE;
        }
        #endregion
    }
}