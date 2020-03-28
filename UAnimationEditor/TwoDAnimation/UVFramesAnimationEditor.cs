/*************************************************************************
 *  Copyright © 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVFramesAnimationEditor.cs
 *  Description  :  Editor for UVFramesAnimation component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UAnimation;
using UnityEditor;
using UnityEngine;

namespace MGS.TwoDAnimationEditor
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
                ApplyUVMaps();
            }
        }
        #endregion

        #region Protected Method
        protected void ApplyUVMaps()
        {
            var frameWidth = 1.0f / Target.Column;
            var frameHeight = 1.0f / Target.Row;

            var mRenderer = Target.GetComponent<Renderer>();
            var material = mRenderer.sharedMaterial;
            material.mainTextureOffset = Vector2.zero;
            material.mainTextureScale = new Vector2(frameWidth, frameHeight);
        }
        #endregion
    }
}