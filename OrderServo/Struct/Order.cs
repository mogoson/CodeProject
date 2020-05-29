/*************************************************************************
 *  Copyright ? 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Order.cs
 *  Description  :  Define order content.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.OrderServo
{
    /// <summary>
    /// Order content.
    /// </summary>
    public struct Order
    {
        #region Field and Property
        /// <summary>
        /// Order unit code.
        /// </summary>
        public string code;

        /// <summary>
        /// Order args.
        /// </summary>
        public object args;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Order code.</param>
        /// <param name="args">Order args.</param>
        public Order(string code, object args)
        {
            this.code = code;
            this.args = args;
        }
        #endregion
    }
}