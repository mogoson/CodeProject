/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuForm.cs
 *  Description  :  Interface of custom context menu form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Interface of custom context menu form.
    /// </summary>
    public interface IContextMenuForm : IUIForm
    {
        #region Property
        /// <summary>
        /// Margin of menu form base on screen.
        /// </summary>
        RectOffset Margin { set; get; }

        /// <summary>
        /// Handler of contex menu form.
        /// </summary>
        IContextMenuFormHandler Handler { set; get; }
        #endregion
    }
}