/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IElectronicComponent.cs
 *  Description  :  Interface for electronic component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Interface for electronic component.
    /// </summary>
    public interface IElectronicComponent
    {
        #region Property
        /// <summary>
        /// The component is enabled to control?
        /// </summary>
        bool Enabled { set; get; }
        #endregion
    }
}