/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IDisplayable.cs
 *  Description  :  Interface for displayable object.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/24/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.UCommon.Generic
{
    /// <summary>
    /// Interface for displayable object.
    /// </summary>
    public interface IDisplayable
    {
        #region Property
        /// <summary>
        /// Object is open?
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Object is disposed?
        /// </summary>
        bool IsDisposed { get; }
        #endregion

        #region Event
        /// <summary>
        /// Event on open object.
        /// </summary>
        event Action OnOpen;

        /// <summary>
        /// Event on close object.
        /// </summary>
        event Action OnClose;
        #endregion

        #region Method
        /// <summary>
        /// Open object.
        /// </summary>
        /// <param name="data">Data for object.</param>
        void Open(object data = null);

        /// <summary>
        /// Refresh object.
        /// </summary>
        /// <param name="data">Data for object.</param>
        void Refresh(object data);

        /// <summary>
        /// Close object.
        /// </summary>
        /// <param name="dispose">Dispose object on close?</param>
        void Close(bool dispose = false);
        #endregion
    }
}