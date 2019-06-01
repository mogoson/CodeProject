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
using UnityEditor;
using UnityEngine;

namespace MGS.UIFormEditor
{
    public class UIFormSettingsEditor
    {
        #region Field and Property
        private const string SETTINGS_PATH = "Assets/Resources/UIForm/Settings/UIFormSettings.asset";
        #endregion

        #region Private Method
        [MenuItem("Tool/UI Form Settings &F")]
        private static void FocusSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath(SETTINGS_PATH, typeof(UIFormSettings)) as UIFormSettings;
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<UIFormSettings>();
                AssetDatabase.CreateAsset(settings, SETTINGS_PATH);
            }
            Selection.activeObject = settings;
        }
        #endregion
    }
}