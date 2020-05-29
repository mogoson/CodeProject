/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EventSystemUtility.cs
 *  Description  :  Utility for EventSystem.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/4/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UCommon.Utility
{
    /// <summary>
    /// Utility for EventSystem.
    /// </summary>
    public sealed class EventSystemUtility
    {
        #region Public Method
        /// <summary>
        /// Check mouse pointer is over target gameobject?
        /// </summary>
        /// <param name="target">Target gameobject.</param>
        /// <returns>Pointer is over target gameobject?</returns>
        public static bool CheckPointerOverGameObject(GameObject target)
        {
            if (EventSystem.current == null)
            {
                return false;
            }

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                return false;
            }

            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);
            foreach (var result in raycastResults)
            {
                if (result.gameObject == target)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}