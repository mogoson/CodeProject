/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMirrorable.cs
 *  Description  :  Interface for mirrorable object.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UCommon.Generic
{
    /// <summary>
    /// Interface for mirrorable object.
    /// </summary>
    public interface IMirrorable
    {
        #region Method
        /// <summary>
        /// Mirror object.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        void Mirror(MirrorMode mode);
        #endregion
    }
}