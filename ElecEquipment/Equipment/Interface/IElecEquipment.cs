/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IElecEquipment.cs
 *  Description  :  Interface for electronic equipment.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  03/26/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ElecEquipment
{
    /// <summary>
    /// Interface for electronic equipment.
    /// </summary>
    public interface IElecEquipment
    {
        #region Method
        /// <summary>
        /// Turn on equipment.
        /// </summary>
        void TurnOn();

        /// <summary>
        /// Turn off equipment.
        /// </summary>
        void TurnOff();
        #endregion
    }
}