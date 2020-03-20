/*************************************************************************
 *  Copyright © 2015-2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMechanism.cs
 *  Description  :  Define interface for mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/17/2018
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  5/24/2018
 *  Description  :  Modify mechanism interface.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.2
 *  Date         :  6/3/2018
 *  Description  :  Add interface for mechanism.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.2
 *  Date         :  3/20/2020
 *  Description  :  Migrate Code.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism interface.
    /// </summary>
    public interface IMechanism
    {
        #region Method
        /// <summary>
        /// Initialize mechanism.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Drive mechanism by velocity.
        /// </summary>
        /// <param name="velocity">Velocity of drive.</param>
        /// <param name="type">Type of drive.</param>
        void Drive(float velocity, DriveType type);
        #endregion
    }

    /// <summary>
    /// Type of mechanism drive.
    /// </summary>
    public enum DriveType
    {
        /// <summary>
        /// Ignore drive type.
        /// </summary>
        Ignore = 0,

        /// <summary>
        /// Linear drive.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Angular drive.
        /// </summary>
        Angular = 2
    }
}