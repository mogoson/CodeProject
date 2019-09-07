/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NetworkListener.cs
 *  Description  :  Windows network listener.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using MGS.UCommon.DesignPattern;
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
        #endregion

        #region Private Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected override void SingleAwake()
        {
            base.SingleAwake();

            CurrentState = NetworkUtility.GetNetworkConnectState();
            lastState = CurrentState;
        }

        /// <summary>
        /// Update listener.
        /// </summary>
        private void Update()
        {
            CurrentState = NetworkUtility.GetNetworkConnectState();
            if (lastState != CurrentState)
            {
                lastState = CurrentState;
                OnStateChanged.Invoke(CurrentState);
            }
        }
        #endregion
    }
}