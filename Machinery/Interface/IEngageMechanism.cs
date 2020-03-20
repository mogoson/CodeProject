/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IEngageMechanism.cs
 *  Description  :  Interface for engage mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism with engaged mechanisms.
    /// </summary>
    public interface IEngageMechanism : IMechanism
    {
        /// <summary>
        /// Build engage for mechanism.
        /// </summary>
        /// <param name="engage">Engage mechanism.</param>
        void BuildEngage(IEngagedMechanism engage);

        /// <summary>
        /// Break engage.
        /// </summary>
        /// <param name="engage">Engage mechanism.</param>
        void BreakEngage(IEngagedMechanism engage);
    }
}