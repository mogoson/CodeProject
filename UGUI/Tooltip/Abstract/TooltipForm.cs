/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipForm.cs
 *  Description  :  Define tooltip form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/2/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Tooltip form.
    /// </summary>
    [FormInfo(UIFromPattern.Single, "Tooltip")]
    public abstract class TooltipForm : MonoForm, ITooltipForm
    {
        #region Field and Property
        /// <summary>
        /// Offset for tip form to align to mouse pointer.
        /// </summary>
        [Tooltip("Offset for tip form to align to mouse pointer.")]
        [SerializeField]
        protected Vector2 offset;

        /// <summary>
        /// Tip form auto follow mouse pointer?
        /// </summary>
        public virtual bool AutoFollowPointer
        {
            set { enabled = value; }
            get { return enabled; }
        }

        /// <summary>
        /// Offset for tip form to align to mouse pointer.
        /// </summary>
        public Vector2 Offset
        {
            set { offset = value; }
            get { return offset; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// Initialize tip form.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            RectTrans.anchorMin = RectTrans.anchorMax = Vector2.zero;
            RectTrans.pivot = Text.GetTextAnchorPivot(alignment);
        }

        /// <summary>
        /// Tip update.
        /// </summary>
        protected virtual void Update()
        {
            AlignFormToPointer();
        }

        /// <summary>
        /// Align tip form to mouse pointer.
        /// </summary>
        protected void AlignFormToPointer()
        {
            SetPosition((Vector2)Input.mousePosition + offset);
        }
        #endregion
    }
}