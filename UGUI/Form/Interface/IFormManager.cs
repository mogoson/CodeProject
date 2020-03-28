/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IFormManager.cs
 *  Description  :  Interface of manager for custom UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface of manager for custom UI form.
    /// </summary>
    public interface IFormManager
    {
        #region Property
        /// <summary>
        /// Canvas component.
        /// </summary>
        Canvas Canvas { get; }

        /// <summary>
        /// CanvasScaler component.
        /// </summary>
        CanvasScaler CanvasScaler { get; }

        /// <summary>
        /// GraphicRaycaster component.
        /// </summary>
        GraphicRaycaster GraphicRaycaster { get; }

        /// <summary>
        /// Layers for custom form.
        /// </summary>
        string[] Layers { get; }
        #endregion

        #region Method
        /// <summary>
        /// Open form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        T OpenForm<T>() where T : Component, IForm;

        /// <summary>
        /// Find form by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target form.</returns>
        T FindForm<T>() where T : IForm;

        /// <summary>
        /// Find all forms.
        /// </summary>
        /// <returns>All forms.</returns>
        IForm[] FindForms();

        /// <summary>
        /// Find forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <returns>Target forms.</returns>
        IForm[] FindForms(string layer);

        /// <summary>
        /// Find forms by filter options.
        /// </summary>
        /// <param name="form">Specified form.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <returns>Target forms.</returns>
        IForm[] FindForms(IForm form, FilterOptions options);

        /// <summary>
        /// Find forms by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target forms.</returns>
        T[] FindForms<T>() where T : IForm;

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        void MirrorForms(MirrorMode mode);

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="mode">Mode of mirror.</param>
        void MirrorForms(string layer, MirrorMode mode);

        /// <summary>
        /// Set language of forms.
        /// </summary>
        /// <param name="language">Language name.</param>
        void LanguageForms(string language);

        /// <summary>
        /// Close form by specified form.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForm(IForm form, bool dispose = false);

        /// <summary>
        /// Close form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForm<T>(bool dispose = false) where T : IForm;

        /// <summary>
        /// Close all the forms.
        /// </summary>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForms(bool dispose = false);

        /// <summary>
        /// Close forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForms(string layer, bool dispose = false);

        /// <summary>
        /// Close forms by filter options.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForms(IForm form, FilterOptions options, bool dispose = false);

        /// <summary>
        /// Close form by specified forms.
        /// </summary>
        /// <param name="forms">Specified form instances.</param>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForms(IEnumerable<IForm> forms, bool dispose = false);

        /// <summary>
        /// Close forms by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="dispose">Dispose form on close?</param>
        void CloseForms<T>(bool dispose = false) where T : IForm;
        #endregion
    }

    /// <summary>
    /// Options for filter forms.
    /// </summary>
    public enum FilterOptions
    {
        /// <summary>
        /// Forms those in front of the specified form.
        /// </summary>
        FrontForms = 0,

        /// <summary>
        /// Forms those in back of the specified form.
        /// </summary>
        BackForms = 1
    }
}