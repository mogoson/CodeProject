/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KnobEditor.cs
 *  DeTargetion  :  Editor for Knob component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.ElecEquipment;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.ElecEquipmentEditor
{
    [CustomEditor(typeof(Knob), true)]
    [CanEditMultipleObjects]
    public class KnobEditor : BaseEditor
    {
        #region Field and Property 
        protected Knob Target { get { return target as Knob; } }

        protected Vector3 ZeroAxis
        {
            get
            {
                if (Application.isPlaying)
                {
                    var axis = Quaternion.Euler(Target.StartAngles) * Vector3.up;
                    if (Target.transform.parent)
                    {
                        axis = Target.transform.parent.rotation * axis;
                    }
                    return axis;
                }
                return Target.transform.up;
            }
        }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            Handles.color = Blue;
            DrawAdaptiveSphereCap(Target.transform.position, Quaternion.identity, NodeSize);
            DrawAdaptiveCircleCap(Target.transform.position, Target.transform.rotation, AreaRadius);
            DrawAdaptiveSphereArrow(Target.transform.position, Target.transform.forward, ArrowLength, NodeSize, "Axis");

            DrawAdaptiveSphereArrow(Target.transform.position, ZeroAxis, ArrowLength, NodeSize, "Zero");
            DrawAdaptiveSphereArrow(Target.transform.position, Target.transform.up, AreaRadius, NodeSize);

            Handles.color = TransparentBlue;
            if (Target.RotateLimit)
            {
                var fromAxis = Quaternion.AngleAxis(Target.AngleRange.min, Target.transform.forward) * ZeroAxis;
                DrawAdaptiveSolidArc(Target.transform.position, Target.transform.forward, fromAxis, Target.AngleRange.max - Target.AngleRange.min, AreaRadius);
            }
            else
            {
                DrawAdaptiveSolidDisc(Target.transform.position, Target.transform.forward, AreaRadius);
            }

            if (Target.Adsorbent)
            {
                Handles.color = Blue;
                foreach (var adsorbent in Target.AdsorbableAngles)
                {
                    var adsorbentAxis = Quaternion.AngleAxis(adsorbent, Target.transform.forward) * ZeroAxis;
                    var adaptiveScale = HandleUtility.GetHandleSize(Target.transform.position);
                    var adsorbentPosition = Target.transform.position + adsorbentAxis.normalized * AreaRadius * adaptiveScale;
                    DrawAdaptiveSphereCap(adsorbentPosition, Quaternion.identity, NodeSize);
                }
            }
        }
        #endregion
    }
}