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
    [RequireComponent(typeof(ContentSizeFitter), typeof(LayoutGroup))]
    public class TextTooltipForm : TooltipForm
    {
        #region Field and Property
        /// <summary>
        /// Text component for tip content.
        /// </summary>
        [Tooltip("Text component for tip content.")]
        public Text tipContent;

        /// <summary>
        /// Max width of tip content.
        /// </summary>
        [Tooltip("Max width of tip content.")]
        public uint tipMaxWidth = 200;

        /// <summary>
        /// LayoutElement component for tip content.
        /// </summary>
        protected LayoutElement tipLayout;
        #endregion

        #region Protected Method
        /// <summary>
        /// Reset tip form.
        /// </summary>
        protected virtual void Reset()
        {
            var fitter = GetComponent<ContentSizeFitter>();
            fitter.horizontalFit = fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            tipContent = GetComponentInChildren<Text>();
        }

        /// <summary>
        /// Initialize tip form.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            tipLayout = tipContent.GetComponent<LayoutElement>();
            if (tipLayout == null)
            {
                tipLayout = tipContent.gameObject.AddComponent<LayoutElement>();
            }
        }

        /// <summary>
        /// Set content of tip form.
        /// </summary>
        /// <param name="content">Tip content.</param>
        protected virtual void SetTipContent(string content)
        {
            tipContent.text = content;
            tipLayout.preferredWidth = Mathf.Min(tipContent.preferredWidth, tipMaxWidth);

#if UNITY_5_3_OR_NEWER
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
#endif
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
                AlignFormToPointer();
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