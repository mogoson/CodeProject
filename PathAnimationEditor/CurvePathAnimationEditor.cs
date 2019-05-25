/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CurvePathAnimationEditor.cs
 *  DeTargetion  :  Editor for CurvePathAnimation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/28/2018
 *  DeTargetion  :  Initial development version.
 *************************************************************************/

using MGS.PathAnimation;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.PathAnimationEditor
{
    [CustomEditor(typeof(CurvePathAnimation), true)]
    [CanEditMultipleObjects]
    public class CurvePathAnimationEditor : BaseEditor
    {
        #region Field and Property
        protected CurvePathAnimation Target { get { return target as CurvePathAnimation; } }

        protected SerializedProperty keepUp;
        protected SerializedProperty reference;
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            keepUp = serializedObject.FindProperty("keepUp");
            reference = serializedObject.FindProperty("reference");
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(keepUp);
            if (Target.keepUp == KeepUpMode.ReferenceForward || Target.keepUp == KeepUpMode.ReferenceForwardAsNormal)
            {
                EditorGUILayout.PropertyField(reference);
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Align To Path"))
            {
                Target.Path.Rebuild();
                Target.Initialize();
                Target.Rewind();

                MarkSceneDirty();
            }
        }
        #endregion
    }
}