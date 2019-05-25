/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IRocker.cs
 *  Description  :  Interface for rocker.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/22/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.ElectronicComponent
{
    /// <summary>
    /// Interface for rocker.
    /// </summary>
    public interface IRocker : IElectronicComponent
    {
        #region Property
        /// <summary>
        /// Radius angle.
        /// </summary>
        float RadiusAngle { set; get; }

        /// <summary>
        /// Rocker rotate speed.
        /// </summary>
        float RotateSpeed { set; get; }

        /// <summary>
        /// Revert speed.
        /// </summary>
        float RevertSpeed { set; get; }

        /// <summary>
        /// Rocker current angles normalized vector.
        /// </summary>
        Vector2 Vector { get; }
        #endregion

        #region Event
        /// <summary>
        /// Rocker drag event.
        /// </summary>
        event Action OnDrag;

        /// <summary>
        /// Rocker Release event.
        /// </summary>
        event Action OnRelease;

        /// <summary>
        /// Rocker revert event.
        /// </summary>
        event Action OnRevert;
        #endregion
    }
}