/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMirrorableUI.cs
 *  Description  :  Interface for mirrorable UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for mirrorable UI.
    /// </summary>
    public interface IMirrorableUI
    {
        #region Method
        /// <summary>
        /// Mirror UI.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        void Mirror(MirrorMode mode);
        #endregion
    }
}