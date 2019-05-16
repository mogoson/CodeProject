/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVFramesAnimationEditor.cs
 *  Description  :  Editor for UVFramesAnimation component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UAnimation;
using UnityEditor;
using UnityEngine;

namespace MGS.UAnimationEditor
{
    [CustomEditor(typeof(UVFramesAnimation), true)]
    [CanEditMultipleObjects]
    public class UVFramesAnimationEditor : Editor
    {
        #region Field and Property
        protected UVFramesAnimation Target { get { return target as UVFramesAnimation; } }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Apply UV Maps"))
            {
                Target.ApplyUVMaps();
            }
        }
        #endregion
    }
}