/*************************************************************************
 *  Copyright © 2016-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LerpPointerMeterEditor.cs
 *  Description  :  Editor for LerpPointerMeter component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/9/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Meter;
using UnityEditor;

namespace MGS.MeterEditor
{
    [CustomEditor(typeof(LerpPointerMeter), true)]
    [CanEditMultipleObjects]
    public class LerpPointerMeterEditor : PointerMeterEditor
    {
        #region Field and Property
        protected new LerpPointerMeter Target { get { return target as LerpPointerMeter; } }

        protected SerializedProperty lerpMode = null;
        protected SerializedProperty mainSpeed = null;
        protected SerializedProperty minSpeed = null;
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            lerpMode = serializedObject.FindProperty("lerpMode");
            mainSpeed = serializedObject.FindProperty("mainSpeed");
            minSpeed = serializedObject.FindProperty("minSpeed");
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(lerpMode);
            EditorGUILayout.PropertyField(mainSpeed);
            if (Target.lerpMode == LerpMode.Lerp)
            {
                EditorGUILayout.PropertyField(minSpeed);
            }

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
        #endregion
    }
}