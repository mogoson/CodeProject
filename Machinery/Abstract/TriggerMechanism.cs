/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TriggerMechanism.cs
 *  Description  :  Trigger for mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Trigger for mechanism.
    /// </summary>
    public abstract class TriggerMechanism : Mechanism, ITriggerMechanism
    {
        #region Field and Property
        /// <summary>
        /// Trigger is triggered?
        /// </summary>
        public abstract bool IsTriggered { get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Drive trigger by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity = 0, DriveType type = DriveType.Ignore) { }
        #endregion
    }
}