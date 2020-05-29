/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
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
using MGS.Common.Threading;
using MGS.UCommon.DesignPattern;
using System.Threading;

namespace MGS.WinCommon.Network
{
    /// <summary>
    /// Windows network listener.
    /// </summary>
    public sealed class NetworkListener : SingleUpdater<NetworkListener>
    {
        #region Field and Property
        /// <summary>
        /// Listener refresh cycle(ms).
        /// </summary>
        public int RefreshCycle { set; get; } = 250;

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
        /// Constructor.
        /// </summary>
        private NetworkListener() { }

        /// <summary>
        /// On update.
        /// </summary>
        protected override void OnUpdate()
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
        public override void TurnOn()
        {
            //Thread can not restart after abort.
            if (refreshThread == null || !refreshThread.IsAlive)
            {
                base.TurnOn();

                refreshThread = ThreadUtility.RunAsync(() =>
                {
                    lastState = CurrentState = NetworkUtility.GetNetworkConnectState();
                    Thread.Sleep(RefreshCycle);

                    while (IsTurnOn)
                    {
                        CurrentState = NetworkUtility.GetNetworkConnectState();
                        Thread.Sleep(RefreshCycle);
                    }
                });
            }
        }

        /// <summary>
        /// Turn off listener.
        /// </summary>
        public override void TurnOff()
        {
            base.TurnOff();

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