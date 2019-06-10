/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RectUtility.cs
 *  Description  :  Utility for RectTransform.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Generic;
using UnityEngine;

namespace MGS.UCommon.Utility
{
    /// <summary>
    /// Utility for RectTransform.
    /// </summary>
    public static class RectUtility
    {
        /// <summary>
        /// Mirror RectTransform.
        /// </summary>
        /// <param name="rect">Target RectTransform.</param>
        /// <param name="mode">Mode of mirror.</param>
        public static void Mirror(RectTransform rect, MirrorMode mode)
        {
            var anchorPos = rect.anchoredPosition;
            var minX = rect.anchorMin.x;
            var minY = rect.anchorMin.y;
            var maxX = rect.anchorMax.x;
            var maxY = rect.anchorMax.y;

            var pivotX = rect.pivot.x;
            var pivotY = rect.pivot.y;

            var h = 1;
            var v = 1;
            switch (mode)
            {
                case MirrorMode.Horizontal:
                    minX = 1 - minX;
                    maxX = 1 - maxX;
                    pivotX = 1 - pivotX;
                    h = -1;
                    break;

                case MirrorMode.Vertical:
                    minY = 1 - minY;
                    maxY = 1 - maxY;
                    pivotY = 1 - pivotY;
                    v = -1;
                    break;

                case MirrorMode.Both:
                    minX = 1 - minX;
                    minY = 1 - minY;
                    maxX = 1 - maxX;
                    maxY = 1 - maxY;

                    pivotX = 1 - pivotX;
                    pivotY = 1 - pivotY;

                    h = v = -1;
                    break;
            }

            rect.anchorMin = new Vector2(minX, minY);
            rect.anchorMax = new Vector2(maxX, maxY);
            rect.pivot = new Vector2(pivotX, pivotY);
            anchorPos = new Vector2(anchorPos.x * h, anchorPos.y * v);
            rect.anchoredPosition = anchorPos;
        }
    }
}