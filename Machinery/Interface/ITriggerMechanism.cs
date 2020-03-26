/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITriggerMechanism.cs
 *  Description  :  Interface for trigger mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Trigger mechanism.
    /// </summary>
    public interface ITriggerMechanism : IMechanism
    {
        #region Property
        /// <summary>
        /// Trigger is enter?
        /// </summary>
        bool IsTriggerEnter { get; }
        #endregion
    }
}