/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TextTooltipForm.cs
 *  Description  :  Define text tooltip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Text tooltip form.
    /// </summary>
    [AddComponentMenu("MGS/UGUI/TextTooltipForm")]
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
        protected override void Awake()
        {
            base.Awake();

            tipLayout = tipContent.GetComponent<LayoutElement>();
            if (tipLayout == null)
            {
                tipLayout = tipContent.gameObject.AddComponent<LayoutElement>();
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Set content of tip form.
        /// </summary>
        /// <param name="content">Tip content.</param>
        public virtual void SetTipContent(string content)
        {
            tipContent.text = content;
            tipLayout.preferredWidth = Mathf.Min(tipContent.preferredWidth, tipMaxWidth);

#if UNITY_5_3_OR_NEWER
            LayoutRebuilder.ForceRebuildLayoutImmediate(RectTrans);
#endif
            if (AutoFollowPointer)
            {
                AlignFormToPointer();
            }
        }
        #endregion
    }
}