/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoLED.cs
 *  Description  :  Define LED component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// LED component.
    /// </summary>
    public abstract class MonoLED : MonoElectronicComponent, ILED
    {
        #region Public Method
        /// <summary>
        /// Open LED.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// Close LED.
        /// </summary>
        public abstract void Close();
        #endregion
    }
}