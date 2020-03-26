/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RockerLinkMechanism.cs
 *  Description  :  Mechanism with link rockers.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism with link rockers.
    /// </summary>
    public abstract class RockerLinkMechanism : Mechanism
    {
        #region Field and Property
        /// <summary>
        /// Rockers that link with this mechanism. 
        /// </summary>
        [Tooltip("Rockers that link with this mechanism. ")]
        public List<RockerMechanism> rockers = new List<RockerMechanism>();

        /// <summary>
        /// Triggers attached on link rockers.
        /// </summary>
        protected List<TriggerMechanism> triggers = new List<TriggerMechanism>();

        /// <summary>
        /// Record value on trigger is triggered.
        /// </summary>
        protected float triggerRecord = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Check trigger is triggered.
        /// </summary>
        /// <returns>Return true if one of the triggers is triggered.</returns>
        protected bool CheckTriggers()
        {
            foreach (var trigger in triggers)
            {
                if (trigger.IsTriggerEnter)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Drive the rockers that join at this mechanism.
        /// </summary>
        protected void DriveRockers()
        {
            foreach (var rocker in rockers)
            {
                rocker.Drive(0, DriveType.Ignore);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize mechanism.
        /// </summary>
        public override void Initialize()
        {
            triggers.Clear();
            foreach (var rocker in rockers)
            {
                var trigger = rocker.GetComponent<TriggerMechanism>();
                if (trigger)
                {
                    triggers.Add(trigger);
                }
            }
        }
        #endregion
    }
}