/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IForm.cs
 *  Description  :  Interface of custom UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface of custom UI form.
    /// </summary>
    public interface IForm : IUIElement
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

        /// <summary>
        /// Margin of form base on parent.
        /// </summary>
        RectOffset Margin { set; get; }

        /// <summary>
        /// Alignment of form to align to target position.
        /// </summary>
        TextAnchor Alignment { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Set form anchored position.
        /// </summary>
        /// <param name="anchoredPosition">Target anchored position of form.</param>
        void SetPosition(Vector2 anchoredPosition);
        #endregion
    }
}