﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AxleEditor.cs
 *  Description  :  Custom editor for Axle.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  6/13/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.Machinery
{
    [CustomEditor(typeof(Axle), true)]
    [CanEditMultipleObjects]
    public class AxleEditor : BaseEditor
    {
        #region Field and Property
        protected Axle Target { get { return target as Axle; } }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            Handles.color = Blue;
            DrawAdaptiveSphereCap(Target.transform.position, Quaternion.identity, NodeSize);
            DrawAdaptiveCircleCap(Target.transform.position, Target.transform.rotation, NodeSize * 2);
            DrawAdaptiveSphereArrow(Target.transform.position, Target.transform.forward, ArrowLength, NodeSize, "Axis");
        }
        #endregion
    }
}