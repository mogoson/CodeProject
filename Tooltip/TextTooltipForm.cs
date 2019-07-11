/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TextTooltipForm.cs
 *  Description  :  Define text tooltip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.Tooltip
{
    /// <summary>
    /// Text tooltip form.
    /// </summary>
    [AddComponentMenu("MGS/Tooltip/TextTooltipForm")]
    public class TextTooltipForm : TooltipForm
    {
        #region Field and Property
        /// <summary>
        /// Max width of tip form.
        /// </summary>
        [Tooltip("Max width of tip form.")]
        public int tipMaxWidth = 200;

        /// <summary>
        /// Text component of tip content.
        /// </summary>
        [Tooltip("Text component of tip content.")]
        public Text tipContent;
        #endregion

        #region Protected Method
        /// <summary>
        /// Set content of tip form.
        /// </summary>
        /// <param name="content">Tip content.</param>
        protected virtual void SetTipContent(string content)
        {
            tipContent.text = content;

            var preferredWidth = LayoutUtility.GetPreferredWidth(rectTransform);
            if (preferredWidth > tipMaxWidth)
            {
                preferredWidth = tipMaxWidth;
            }
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredWidth);

            var preferredHeight = LayoutUtility.GetPreferredHeight(rectTransform);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh tip form.
        /// </summary>
        /// <param name="data">Data of tip form, type is string or TextTooltipFormData.</param>
        public override void Refresh(object data)
        {
            if (data is string content)
            {
                AutoFollowPointer = true;
                SetTipContent(content);
            }
            else if (data is TextTooltipFormData tipData)
            {
                AutoFollowPointer = false;
                SetTipContent(tipData.tipContent);
                SetFormPosition(tipData.tipPosition);
            }
            else
            {
                LogUtility.LogWarning(0, "Refresh tip form failed: The type of data is not string or TextTooltipFormData.");
            }
        }
        #endregion
    }

    /// <summary>
    /// Data of text tooltip form.
    /// </summary>
    public class TextTooltipFormData
    {
        /// <summary>
        /// Tip content text.
        /// </summary>
        public string tipContent;

        /// <summary>
        /// Screen position of tip form.
        /// </summary>
        public Vector2 tipPosition;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tipContent">Tip content text.</param>
        /// <param name="tipPosition">Screen position of tip form.</param>
        public TextTooltipFormData(string tipContent, Vector2 tipPosition)
        {
            this.tipContent = tipContent;
            this.tipPosition = tipPosition;
        }
    }
}