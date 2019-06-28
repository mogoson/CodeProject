/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  InteractableUI.cs
 *  Description  :  Base class for interactable UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/29/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UCommon.UI
{
    /// <summary>
    /// Base class for interactable UI.
    /// </summary>
    public abstract class InteractableUI : UIElement, IInteractableUI
    {
        /// <summary>
        /// UI is interactable?
        /// </summary>
        public abstract bool Interactable { set; get; }
    }
}