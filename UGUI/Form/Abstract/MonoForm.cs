/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoForm.cs
 *  Description  :  Custom UI form base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Custom UI form base.
    /// </summary>
    [FormInfo(UIFromPattern.Single, "Default")]
    public abstract class MonoForm : UIElement, IForm
    {
        #region Field and Property
        /// <summary>
        /// Margin of form base on parent.
        /// </summary>
        [Tooltip("Margin of form base on parent.")]
        [SerializeField]
        protected RectOffset margin;

        /// <summary>
        /// Alignment of form to align to target position.
        /// </summary>
        [Tooltip("Alignment of form to align to target position.")]
        [SerializeField]
        protected TextAnchor alignment;

        /// <summary>
        /// ID of form.
        /// </summary>
        public string ID { protected set; get; }

        /// <summary>
        /// Name of form.
        /// </summary>
        public virtual string Name { set; get; }

        /// <summary>
        /// Tittle of form.
        /// </summary>
        public virtual string Tittle { set; get; }

        /// <summary>
        /// Margin of form base on parent.
        /// </summary>
        public RectOffset Margin
        {
            set { margin = value; }
            get { return margin; }
        }

        /// <summary>
        /// Alignment of form to align to target position.
        /// </summary>
        public TextAnchor Alignment
        {
            set
            {
                alignment = value;
                RectTrans.pivot = Text.GetTextAnchorPivot(alignment);
            }
            get { return alignment; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake UI component.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            ID = Guid.NewGuid().ToString();
            Name = GetType().Name;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Set form anchored position.
        /// </summary>
        /// <param name="anchoredPosition">Target anchored position of form.</param>
        public virtual void SetPosition(Vector2 anchoredPosition)
        {
            var xPos = anchoredPosition.x;
            var xMin = margin.left + RectTrans.rect.width * RectTrans.pivot.x;
            if (xPos <= xMin)
            {
                xPos = xMin;
            }
            else
            {
                var xMax = ParentTrans.rect.width - margin.right - RectTrans.rect.width * (1 - RectTrans.pivot.x);
                if (xPos > xMax)
                {
                    xPos = xMax;
                }
            }

            var yPos = anchoredPosition.y;
            var yMin = margin.bottom + RectTrans.rect.height * RectTrans.pivot.y;
            if (yPos <= yMin)
            {
                yPos = yMin;
            }
            else
            {
                var yMax = ParentTrans.rect.height - margin.top - RectTrans.rect.height * (1 - RectTrans.pivot.y);
                if (yPos > yMax)
                {
                    yPos = yMax;
                }
            }

            RectTrans.anchoredPosition = new Vector2(xPos, yPos);
        }
        #endregion
    }
}