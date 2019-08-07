/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoUI.cs
 *  Description  :  Interface for mono UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/24/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.UCommon.UI
{
    /// <summary>
    /// Interface for mono UI.
    /// </summary>
    public interface IMonoUI
    {
        #region Property
        /// <summary>
        /// RectTransform component of UI.
        /// </summary>
        RectTransform rectTransform { get; }

        /// <summary>
        /// UI is open?
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// UI is disposed?
        /// </summary>
        bool IsDisposed { get; }
        #endregion

        #region Event
        /// <summary>
        /// Event on open UI.
        /// </summary>
        GenericEvent OnOpen { get; }

        /// <summary>
        /// Event on close UI.
        /// </summary>
        GenericEvent OnClose { get; }
        #endregion

        #region Method
        /// <summary>
        /// Open UI.
        /// </summary>
        /// <param name="data">Data for UI.</param>
        void Open(object data = null);

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="data">Data for UI.</param>
        /// <returns>Succeed?</returns>
        bool Refresh(object data);

        /// <summary>
        /// Close UI.
        /// </summary>
        /// <param name="dispose">Dispose UI on close?</param>
        void Close(bool dispose = false);
        #endregion
    }
}