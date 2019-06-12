/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFormSettings.cs
 *  Description  :  Settings for UI form.
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
    /// Settings for UI form.
    /// </summary>
    public class UIFormSettings : ScriptableObject
    {
        #region Field and Property
        /// <summary>
        /// Layers for custom UI form.
        /// </summary>
        public List<string> layers = new List<string>() { "Default" };
        #endregion
    }
}