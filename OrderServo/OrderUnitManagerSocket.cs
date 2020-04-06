/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderUnitManagerSocket.cs
 *  Description  :  Socket of order units manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/6/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.OrderServo
{
    /// <summary>
    /// Socket of order units manager.
    /// </summary>
    [AddComponentMenu("MGS/OrderServo/OrderUnitManagerSocket")]
    [RequireComponent(typeof(IOrderUnitManager))]
    public class OrderUnitManagerSocket : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Units managed by this manager.
        /// </summary>
        [Tooltip("Units managed by this manager.")]
        [SerializeField]
        protected List<OrderUnit> units;
        #endregion

        #region Private Method
        /// <summary>
        /// Awake collector.
        /// </summary>
        protected virtual void Awake()
        {
            var unitMr = GetComponent<IOrderUnitManager>();
            foreach (var unit in units)
            {
                unitMr.AddUnit(unit);
            }
            Destroy(this);
        }
        #endregion
    }
}