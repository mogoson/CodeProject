/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoUIForm.cs
 *  Description  :  Custom UI form base.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.UI;
using System;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom UI form base.
    /// </summary>
    [UIFormInfo(UIFromPattern.Single, "Default")]
    public abstract class MonoUIForm : UIElement, IUIForm
    {
        #region Field and Property
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
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize form.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            ID = Guid.NewGuid().ToString();
            Name = GetType().Name;
        }
        #endregion
    }
}