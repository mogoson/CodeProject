/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CrankLinkMechanism.cs
 *  Description  :  Crank mechanism with link joints.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Mathematics;
using UnityEngine;

namespace MGS.Machinery
{
    /// <summary>
    /// Crank mechanism with link joints.
    /// </summary>
	public abstract class CrankLinkMechanism : Mechanism
    {
        #region Field and Property
        /// <summary>
        /// Power crank.
        /// </summary>
        [Tooltip("Power crank.")]
        public CrankMechanism crank;

        /// <summary>
        /// Link rocker.
        /// </summary>
        [Tooltip("Link rocker.")]
        public RockerMechanism link;

        /// <summary>
        /// Edit mode of Hinge Editor.
        /// </summary>
        [HideInInspector]
        public EditMode editMode = EditMode.Lock;

        /// <summary>
        /// This mechanism is initialized?
        /// </summary>
        [HideInInspector]
        public bool isInitialized = false;

        /// <summary>
        /// All the joints of this mechanism are set intact.
        /// </summary>
        public abstract bool IsIntact { get; }

        /// <summary>
        /// Is dead lock?
        /// </summary>
        public bool IsLock { protected set; get; }

        /// <summary>
        /// Drive speed is positive?
        /// </summary>
        private bool isPositive = false;
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake mechanism.
        /// </summary>
        protected override void Awake()
        {
            if (IsIntact)
            {
                Initialize();
            }
        }

        /// <summary>
        /// Update mechanism.
        /// </summary>
        protected virtual void Update()
        {
            if (Application.isPlaying)
            {
                return;
            }

            if (IsIntact)
            {
                if (!isInitialized)
                {
                    Initialize();
                    isInitialized = true;
                }
                DriveLinkJoints();
            }
            else
            {
                isInitialized = false;
            }
        }

        /// <summary>
        /// Get local position of link rocker base on this transform.
        /// </summary>
        /// <returns>Local position of link rocker.</returns>
        protected virtual Vector3 GetLinkPosition()
        {
            return transform.InverseTransformPoint(link.transform.position);
        }

        /// <summary>
        /// Correct position to project point.
        /// </summary>
        /// <param name="position">Local position.</param>
        /// <returns>Correct point.</returns>
        protected Vector CorrectPoint(Vector3 position)
        {
            return new Vector(position.x, position.y);
        }

        /// <summary>
        /// Clear angles x and y.
        /// </summary>
        /// <param name="angles">Local euler angles.</param>
        /// <returns>Correct angles.</returns>
        protected Vector3 CorrectAngles(Vector3 angles)
        {
            return new Vector3(0, 0, angles.z);
        }

        /// <summary>
        /// Clear position Z.
        /// </summary>
        /// <param name="position">Local position.</param>
        /// <returns>Correct position.</returns>
        protected Vector3 CorrectPosition(Vector3 position)
        {
            return new Vector3(position.x, position.y);
        }

        /// <summary>
        /// Drive joints those link with this mechanism.
        /// </summary>
        protected abstract void DriveLinkJoints();
        #endregion

        #region Public Method
        /// <summary>
        /// Drive crank link mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        public override void Drive(float velocity, DriveType type)
        {
            if (velocity >= 0)
            {
                if (IsLock && isPositive)
                {
                    return;
                }
                isPositive = true;
            }
            else
            {
                if (IsLock && !isPositive)
                {
                    return;
                }
                isPositive = false;
            }
            crank.Drive(velocity, type);
            DriveLinkJoints();
        }
        #endregion
    }
}