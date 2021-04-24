/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Command.cs
 *  Description  :  Define Command content.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.CommandServo
{
    /// <summary>
    /// Command content.
    /// </summary>
    public struct Command
    {
        #region Field and Property
        /// <summary>
        /// Command unit code.
        /// </summary>
        public string code;

        /// <summary>
        /// Command args.
        /// </summary>
        public object[] args;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Command code.</param>
        /// <param name="args">Command args.</param>
        public Command(string code, params object[] args)
        {
            this.code = code;
            this.args = args;
        }
        #endregion
    }
}