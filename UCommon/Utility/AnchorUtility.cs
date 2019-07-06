/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AnchorUtility.cs
 *  Description  :  Utility for anchor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/5/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.Utility
{
    /// <summary>
    /// Utility for anchor.
    /// </summary>
    public static class AnchorUtility
    {
        /// <summary>
        /// Convert TextAnchor to Vector2.
        /// </summary>
        /// <param name="anchor">TextAnchor.</param>
        /// <returns>Vector2.</returns>
        public static Vector2 ToVector(TextAnchor anchor)
        {
            var vector = Vector2.zero;
            switch (anchor)
            {
                case TextAnchor.UpperLeft:
                    vector = new Vector2(0, 1);
                    break;

                case TextAnchor.UpperCenter:
                    vector = new Vector2(0.5f, 1);
                    break;

                case TextAnchor.UpperRight:
                    vector = new Vector2(1, 1);
                    break;

                case TextAnchor.MiddleLeft:
                    vector = new Vector2(0, 0.5f);
                    break;

                case TextAnchor.MiddleCenter:
                    vector = new Vector2(0.5f, 0.5f);
                    break;

                case TextAnchor.MiddleRight:
                    vector = new Vector2(1, 0.5f);
                    break;

                case TextAnchor.LowerLeft:
                    vector = new Vector2(0, 0);
                    break;

                case TextAnchor.LowerCenter:
                    vector = new Vector2(0.5f, 0);
                    break;

                case TextAnchor.LowerRight:
                    vector = new Vector2(1, 0);
                    break;
            }
            return vector;
        }
    }
}