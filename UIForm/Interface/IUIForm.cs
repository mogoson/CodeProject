/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIForm.cs
 *  Description  :  Interface of custom UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using System;

namespace MGS.UIForm
{
    /// <summary>
    /// Interface of custom UI form.
    /// </summary>
    public interface IUIForm : IMirrorable, IMultilingual
    {
        #region Property
        /// <summary>
        /// ID of form.
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Form is open?
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Form is disposed?
        /// </summary>
        bool IsDisposed { get; }
        #endregion

        #region Event
        /// <summary>
        /// Event on open form.
        /// </summary>
        event Action OnOpen;

        /// <summary>
        /// Event on close form.
        /// </summary>
        event Action OnClose;
        #endregion

        #region Method
        /// <summary>
        /// Open form.
        /// </summary>
        /// <param name="data">Data of form to show.</param>
        void Open(object data = null);

        /// <summary>
        /// Refresh form.
        /// </summary>
        /// <param name="data">Data of form to show.</param>
        void Refresh(object data);

        /// <summary>
        /// Close form.
        /// </summary>
        /// <param name="dispose">Dispose form on close?</param>
        void Close(bool dispose = false);
        #endregion
    }
}