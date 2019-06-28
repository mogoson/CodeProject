/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMultilingual.cs
 *  Description  :  Interface for multilingual object.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UCommon.Generic
{
    /// <summary>
    /// Interface for multilingual object.
    /// </summary>
    public interface IMultilingual
    {
        #region Method
        /// <summary>
        /// Set language of object.
        /// </summary>
        /// <param name="name">Language name.</param>
        void Language(string name);
        #endregion
    }
}