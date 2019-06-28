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

using MGS.UCommon.UI;

namespace MGS.UIForm
{
    /// <summary>
    /// Interface of custom UI form.
    /// </summary>
    public interface IUIForm : IUIElement
    {
        #region Property
        /// <summary>
        /// ID of form.
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Name of form.
        /// </summary>
        string Name { set; get; }

        /// <summary>
        /// Tittle of form.
        /// </summary>
        string Tittle { set; get; }
        #endregion
    }
}