/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NetworkListener.cs
 *  Description  :  Windows network listener.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.UCommon.DesignPattern;
using System.Threading;
using UnityEngine;

namespace MGS.WinCommon.Network
{
    /// <summary>
    /// Windows network listener.
    /// </summary>
    [AddComponentMenu("MGS/WinCommon/Network/NetworkListener")]
    public sealed class NetworkListener : SingleMonoBehaviour<NetworkListener>
    {
        #region Field and Property
        /// <summary>
        /// Listener refresh rate(milliseconds).
        /// </summary>
        public int RefreshRate { set; get; } = 250;

        /// <summary>
        /// Current state of windows network.
        /// </summary>
        public NetworkConnState CurrentState { private set; get; }

        /// <summary>
        /// Event on network state changed.
        /// </summary>
        public GenericEvent<NetworkConnState> OnStateChanged { get; } = new GenericEvent<NetworkConnState>();

        /// <summary>
        /// Last state of windows network.
        /// </summary>
        private NetworkConnState lastState;

        /// <summary>
        /// Thread for refresh network state.
        /// </summary>
        private Thread refreshThread;
        #endregion

        #region Private Method
        /// <summary>
        /// Update listener.
        /// </summary>
        private void Update()
        {
            //Check state change and notify event.
            if (lastState != CurrentState)
            {
                lastState = CurrentState;
                OnStateChanged.Invoke(CurrentState);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on listener.
        /// </summary>
        public void TurnOn()
        {
            //Thread can not restart after abort.
            if (refreshThread == null || !refreshThread.IsAlive)
            {
                refreshThread = new Thread(() =>
                {
                    lastState = CurrentState = NetworkUtility.GetNetworkConnectState();
                    Thread.Sleep(RefreshRate);

                    while (true)
                    {
                        CurrentState = NetworkUtility.GetNetworkConnectState();
                        Thread.Sleep(RefreshRate);
                    }
                })
                { IsBackground = true };

                refreshThread.Start();
            }
            enabled = true;
        }

        /// <summary>
        /// Turn off listener.
        /// </summary>
        public void TurnOff()
        {
            enabled = false;
            lastState = CurrentState;

            if (refreshThread == null)
            {
                return;
            }

            if (refreshThread.IsAlive)
            {
                refreshThread.Abort();
            }
            refreshThread = null;
        }
        #endregion
    }
}