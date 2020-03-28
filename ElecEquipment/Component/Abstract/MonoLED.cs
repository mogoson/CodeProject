/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoLED.cs
 *  Description  :  Define LED component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ElecEquipment
{
    /// <summary>
    /// LED component.
    /// </summary>
    public abstract class MonoLED : MonoElecComponent, ILED
    {
        #region Public Method
        /// <summary>
        /// Open LED.
        /// </summary>
        public abstract void TurnOn();

        /// <summary>
        /// Close LED.
        /// </summary>
        public abstract void TurnOff();
        #endregion
    }
}