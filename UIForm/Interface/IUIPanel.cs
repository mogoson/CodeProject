/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIPanel.cs
 *  Description  :  Interface of custom UI panel.
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
    /// Interface of custom UI panel.
    /// </summary>
    public interface IUIPanel : IMirrorable, IMultilingual
    {
        #region Property
        /// <summary>
        /// Panel is open?
        /// </summary>
        bool IsOpen { get; }
        #endregion

        #region Method
        /// <summary>
        /// Open panel.
        /// </summary>
        void Open();

        /// <summary>
        /// Close panel.
        /// </summary>
        void Close();
        #endregion
    }
}