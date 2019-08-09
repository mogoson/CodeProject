/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WinNetworkListener.cs
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

namespace MGS.WinUCommon.WinNetwork
{
    /// <summary>
    /// Windows network listener.
    /// </summary>
    [AddComponentMenu("MGS/WinUCommon/WinNetwork/WinNetworkListener")]
    public sealed class WinNetworkListener : SingleMonoBehaviour<WinNetworkListener>
    {
        #region Field and Property
        /// <summary>
        /// Current state of windows network.
        /// </summary>
        public WinNetworkConnState CurrentState { private set; get; }

        /// <summary>
        /// Event on network state changed.
        /// </summary>
        public GenericEvent<WinNetworkConnState> OnStateChanged { get; } = new GenericEvent<WinNetworkConnState>();

        /// <summary>
        /// Last state of windows network.
        /// </summary>
        private WinNetworkConnState lastState;
        #endregion

        #region Private Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected override void SingleAwake()
        {
            base.SingleAwake();

            CurrentState = WinNetworkUtility.GetNetworkConnectState();
            lastState = CurrentState;
        }

        /// <summary>
        /// Update listener.
        /// </summary>
        private void Update()
        {
            CurrentState = WinNetworkUtility.GetNetworkConnectState();
            if (lastState != CurrentState)
            {
                lastState = CurrentState;
                OnStateChanged.Invoke(CurrentState);
            }
        }
        #endregion
    }
}