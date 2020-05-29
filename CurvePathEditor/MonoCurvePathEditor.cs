/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurvePathEditor.cs
 *  DeTargetion  :  Editor for MonoCurvePath.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/28/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.CurvePath;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.CurvePathEditor
{
    [CustomEditor(typeof(MonoCurvePath), true)]
    public class MonoCurvePathEditor : BaseEditor
    {
        #region Field and Property
        protected MonoCurvePath Target { get { return target as MonoCurvePath; } }
        protected const float Delta = 0.05f;
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            if (!Application.isPlaying)
            {
                Target.Rebuild();
                Undo.undoRedoPerformed += Target.Rebuild;
            }
        }

        protected virtual void OnSceneGUI()
        {
            DrawPathCenterCurve();
        }

        protected virtual void OnDisable()
        {
            Undo.undoRedoPerformed -= Target.Rebuild;
        }

        protected virtual void DrawPathCenterCurve()
        {
            Handles.color = Blue;
            for (float t = 0; t < Target.MaxKey; t += Delta)
            {
                Handles.DrawLine(Target.GetPointAt(t), Target.GetPointAt(t + Delta));
            }
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck())
            {
                Target.Rebuild();
            }
        }
        #endregion
    }
}