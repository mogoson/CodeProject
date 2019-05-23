/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PointerMeterEditor.cs
 *  Description  :  Editor for PointerMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Meter;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.MeterEditor
{
    [CustomEditor(typeof(PointerMeter), true)]
    [CanEditMultipleObjects]
    public class PointerMeterEditor : BaseEditor
    {
        #region Field and Property
        protected PointerMeter Target { get { return target as PointerMeter; } }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            foreach (var pointer in Target.pointers)
            {
                DrawPointer(pointer.pointerTrans);
            }
        }

        protected void DrawPointer(Transform pointer)
        {
            if (pointer)
            {
                Handles.color = TransparentBlue;
                DrawAdaptiveSolidDisc(pointer.position, pointer.forward, AreaRadius);

                Handles.color = Blue;
                DrawAdaptiveSphereCap(pointer.position, Quaternion.identity, NodeSize);
                DrawAdaptiveCircleCap(pointer.position, pointer.rotation, AreaRadius);

                DrawAdaptiveSphereArrow(pointer.position, -pointer.forward, ArrowLength, NodeSize, "Axis");
                DrawAdaptiveSphereArrow(pointer.position, pointer.up, AreaRadius, NodeSize);
            }
        }
        #endregion
    }
}