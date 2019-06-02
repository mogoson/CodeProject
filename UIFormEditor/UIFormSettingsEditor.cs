/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFormSettingsEditor.cs
 *  Description  :  Editor for UI form settings.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using System.Collections.Generic;
using UnityEditor;

namespace MGS.UIFormEditor
{
    [CustomEditor(typeof(UIFormSettings), true)]
    [CanEditMultipleObjects]
    public class UIFormSettingsEditor : Editor
    {
        #region Field and Property
        protected const string SETTINGS_PATH = "Assets/Resources/UIForm/Settings/UIFormSettings.asset";

        protected UIFormSettings Target { get { return target as UIFormSettings; } }
        #endregion

        #region Protected Method
        [MenuItem("Tool/UI Form Settings &F")]
        protected static void FocusSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath(SETTINGS_PATH, typeof(UIFormSettings)) as UIFormSettings;
            if (settings == null)
            {
                settings = CreateInstance<UIFormSettings>();
                AssetDatabase.CreateAsset(settings, SETTINGS_PATH);
            }
            Selection.activeObject = settings;
        }

        protected bool CheckRepeated<T>(List<T> list)
        {
            var hashSet = new HashSet<T>(list);
            return list.Count != hashSet.Count;
        }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (CheckRepeated(Target.Layers))
            {
                EditorGUILayout.HelpBox("The elements in the Layers can not be repeated.", MessageType.Error, true);
            }
        }
        #endregion
    }
}