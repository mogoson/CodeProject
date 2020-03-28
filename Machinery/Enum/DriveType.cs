/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DriveType.cs
 *  Description  :  Type of mechanism drive.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
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