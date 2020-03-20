/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICoaxeMechanism.cs
 *  Description  :  Interface for coaxe mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism with coaxed mechanisms.
    /// </summary>
    public interface ICoaxeMechanism : IMechanism
    {
        /// <summary>
        /// Build coaxe for mechanism.
        /// </summary>
        /// <param name="coaxe">Coaxe mechanism.</param>
        void BuildCoaxed(ICoaxedMechanism coaxe);

        /// <summary>
        /// Break coaxed.
        /// </summary>
        /// <param name="coaxe">Coaxe mechanism.</param>
        void BreakCoaxed(ICoaxedMechanism coaxe);
    }
}