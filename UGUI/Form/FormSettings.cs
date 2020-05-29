/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FormSettings.cs
 *  Description  :  Settings for UI form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Settings for UI form.
    /// </summary>
    public class FormSettings : ScriptableObject
    {
        #region Field and Property
        /// <summary>
        /// Layers for custom UI form.
        /// </summary>
        [Tooltip("Layers for custom UI form.")]
        public List<string> layers = new List<string>() { "Default" };
        #endregion
    }
}