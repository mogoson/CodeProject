/*************************************************************************
 *  Copyright (c) 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveHoseEditor.cs
 *  Description  :  Editor for MonoCurveHose component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.SkinnedMesh;
using UnityEditor;

namespace MGS.SkinnedMeshEditor
{
    [CustomEditor(typeof(MonoCurveHose), true)]
    public class MonoCurveHoseEditor : MonoSkinEditor
    {
        #region Field and Property
        protected new MonoCurveHose Target { get { return target as MonoCurveHose; } }
        protected const float Delta = 0.05f;
        #endregion

        #region Protected Method
        protected virtual void OnSceneGUI()
        {
            DrawHoseCenterCurve();
        }

        protected virtual void DrawHoseCenterCurve()
        {
            Handles.color = Blue;
            for (float t = 0; t < Target.MaxKey; t += Delta)
            {
                Handles.DrawLine(Target.GetPointAt(t), Target.GetPointAt(t + Delta));
            }
        }
        #endregion
    }
}