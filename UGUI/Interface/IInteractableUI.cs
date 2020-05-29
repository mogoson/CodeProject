/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IInteractableUI.cs
 *  Description  :  Interface for interactable UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/28/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for interactable UI.
    /// </summary>
    public interface IInteractableUI : IUIElement
    {
        #region Property
        /// <summary>
        /// UI is interactable?
        /// </summary>
        bool Interactable { set; get; }
        #endregion
    }
}