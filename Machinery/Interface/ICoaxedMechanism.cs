/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICoaxedMechanism.cs
 *  Description  :  Interface for coaxed mechanism.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Machinery
{
    /// <summary>
    /// Mechanism can be coaxed to power mechanism.
    /// </summary>
    public interface ICoaxedMechanism : IMechanism
    {
        /// <summary>
        /// Coaxe this mechanism to power mechanism.
        /// </summary>
        /// <param name="coaxe">Power mechanism.</param>
        void CoaxeTo(ICoaxeMechanism coaxe);

        /// <summary>
        /// Break coaxed from power mechanism.
        /// </summary>
        void CoaxeBreak();
    }
}