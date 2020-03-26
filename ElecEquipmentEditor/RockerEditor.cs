/*************************************************************************
 *  Copyright © 2016-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RockerEditor.cs
 *  Description  :  Editor for Rocker component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  6/22/2018
 *  Description  :  Optimize display of node and area.
 *************************************************************************/

using MGS.ElecEquipment;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.ElecEquipmentEditor
{
    [CustomEditor(typeof(Rocker), true)]
    [CanEditMultipleObjects]
    public class RockerEditor : BaseEditor
    {
        #region Field and Property 
        protected Rocker Target { get { return target as Rocker; } }

        protected Vector3 ZeroAxis
        {
            get
            {
                if (Application.isPlaying)
                {
                    var axis = Quaternion.Euler(Target.StartAngles) * Vector3.back;
                    if (Target.transform.parent)
                    {
                        axis = Target.transform.parent.rotation * axis;
                    }
                    return axis;
                }
                return -Target.transform.forward;
            }
        }

        protected Vector3 CrossAxis { get { return Vector3.Cross(ZeroAxis, new Vector3(ZeroAxis.z, ZeroAxis.y, ZeroAxis.x)); } }
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            Handles.color = Blue;
            DrawAdaptiveSphereCap(Target.transform.position, Quaternion.identity, NodeSize);
            DrawAdaptiveSphereArrow(Target.transform.position, -Target.transform.forward, ArrowLength, NodeSize);

            var fromAxis = Quaternion.AngleAxis(Target.RadiusAngle, CrossAxis) * ZeroAxis;
            DrawAdaptiveWireArc(Target.transform.position, ZeroAxis, fromAxis, 360, AreaRadius);

            Handles.color = TransparentBlue;
            DrawAdaptiveSolidArc(Target.transform.position, ZeroAxis, fromAxis, 360, AreaRadius);
        }
        #endregion
    }
}