/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIElement.cs
 *  Description  :  Base class for UI element.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/28/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;

namespace MGS.UGUI
{
    /// <summary>
    /// Base class for UI element.
    /// </summary>
    public abstract class UIElement : MonoUI, IUIElement
    {
        #region Public Method
        /// <summary>
        /// Mirror UI.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        public virtual void Mirror(MirrorMode mode) { }

        /// <summary>
        /// Set language of UI.
        /// </summary>
        /// <param name="name">Language name.</param>
        public virtual void SetLanguage(string name) { }
        #endregion
    }
}