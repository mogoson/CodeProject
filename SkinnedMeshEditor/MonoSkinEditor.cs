/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSkinEditor.cs
 *  Description  :  Editor for MonoSkin component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.SkinnedMesh;
using MGS.UCommonEditor;
using UnityEditor;
using UnityEngine;

namespace MGS.SkinnedMeshEditor
{
    [CustomEditor(typeof(MonoSkinnedMesh), true)]
    public class MonoSkinEditor : BaseEditor
    {
        #region Field and Property
        protected MonoSkinnedMesh Target { get { return target as MonoSkinnedMesh; } }
        #endregion

        #region Protected Method
        protected virtual void OnEnable()
        {
            if (!Application.isPlaying)
            {
                InvokeMethod(Target, "Initialize");
                Target.Rebuild();

                Undo.undoRedoPerformed += Target.Rebuild;
            }
        }

        protected virtual void OnDisable()
        {
            EditorUtility.UnloadUnusedAssetsImmediate(false);
            Undo.undoRedoPerformed -= Target.Rebuild;
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