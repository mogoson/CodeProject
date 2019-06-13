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

namespace MGS.UIForm
{
    /// <summary>
    /// Interface of custom UI form.
    /// </summary>
    public interface IUIForm : IMirrorable, IMultilingual
    {
        #region Property
        /// <summary>
        /// GUID of form.
        /// </summary>
        string GUID { get; }

        /// <summary>
        /// Form is open?
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Form is disposed?
        /// </summary>
        bool IsDisposed { get; }
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