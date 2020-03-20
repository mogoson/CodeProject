/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IEngagedMechanism.cs
 *  Description  :  Interface for engaged mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism can be engaged to power mechanism.
    /// </summary>
    public interface IEngagedMechanism : IMechanism
    {
        /// <summary>
        /// Engage this mechanism to power mechanism.
        /// </summary>
        /// <param name="engage">Power mechanism.</param>
        void EngageTo(IEngageMechanism engage);

        /// <summary>
        /// Break engage from power mechanism.
        /// </summary>
        void EngageBreak();
    }
}