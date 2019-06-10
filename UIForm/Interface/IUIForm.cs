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
    public interface IUIForm
    {
        #region Property
        /// <summary>
        /// GUID of form.
        /// </summary>
        string GUID { get; }

        /// <summary>
        /// Form is opened?
        /// </summary>
        bool IsOpened { get; }
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
        /// Mirror form.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        void Mirror(MirrorMode mode);

        /// <summary>
        /// Set language of form.
        /// </summary>
        /// <param name="name">Language name.</param>
        void Language(string name);

        /// <summary>
        /// Close form.
        /// </summary>
        /// <param name="destroy">Destroy form on closed?</param>
        void Close(bool destroy = false);
        #endregion
    }
}