/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFormSettings.cs
 *  Description  :  Settings of UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Settings of UI form.
    /// </summary>
    public class UIFormSettings : ScriptableObject
    {
        #region Field and Property
        /// <summary>
        /// Layers of custom UI form.
        /// </summary>
        [SerializeField]
        protected List<string> layers = new List<string>() { "Default" };

        /// <summary>
        /// Layers of custom UI form.
        /// </summary>
        public List<string> Layers { get { return layers; } }
        #endregion
    }
}