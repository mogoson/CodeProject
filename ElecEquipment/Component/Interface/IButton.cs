/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IButton.cs
 *  Description  :  Interface for button.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;

namespace MGS.ElecEquipment
{
    /// <summary>
    /// Interface for button.
    /// </summary>
    public interface IButton : IElecComponent
    {
        #region Property
        /// <summary>
        /// Switch down offset.
        /// </summary>
        float DownOffset { set; get; }

        /// <summary>
        /// Self lock on button down?
        /// </summary>
        bool SelfLock { set; get; }

        /// <summary>
        /// Self lock offset percent.
        /// </summary>
        float LockPercent { set; get; }

        /// <summary>
        /// Toggle LED on toggle button?
        /// </summary>
        bool UseLED { set; get; }

        /// <summary>
        /// LED of button.
        /// </summary>
        ILED LED { set; get; }

        /// <summary>
        /// Button is down?
        /// </summary>
        bool IsDown { get; }
        #endregion

        #region Event
        /// <summary>
        /// Button up event.
        /// </summary>
        GenericEvent OnUp { get; }

        /// <summary>
        /// Button down event.
        /// </summary>
        GenericEvent OnDown { get; }

        /// <summary>
        /// Button lock event.
        /// </summary>
        GenericEvent OnLock { get; }
        #endregion
    }
}