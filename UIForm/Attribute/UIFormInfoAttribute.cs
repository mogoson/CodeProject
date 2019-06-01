/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFormInfoAttribute.cs
 *  Description  :  Custom attribute info for UIForm.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/15/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom attribute info for UIForm.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UIFormInfoAttribute : Attribute
    {
        #region Field and Property
        /// <summary>
        /// Pattern of UIForm.
        /// </summary>
        public UIFromPattern Pattern { protected set; get; }

        /// <summary>
        /// Layer of UIForm to display.
        /// </summary>
        public string Layer { protected set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pattern">Pattern of UIForm.</param>
        /// <param name="layer">Layer of UIForm to display.</param>
        public UIFormInfoAttribute(UIFromPattern pattern, string layer)
        {
            Pattern = pattern;
            Layer = layer;
        }
        #endregion
    }

    /// <summary>
    /// Pattern of UIForm.
    /// </summary>
    public enum UIFromPattern
    {
        /// <summary>
        /// UIForm can be created a single instance only.
        /// </summary>
        Single = 0,

        /// <summary>
        /// UIForm can be created multiple instances.
        /// </summary>
        Multiple = 1
    }
}