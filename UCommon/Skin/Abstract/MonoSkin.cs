/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSkin.cs
 *  Description  :  Define Skin to render dynamic mesh.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.Skin
{
    /// <summary>
    /// Render dynamic skinned mesh.
    /// </summary>
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public abstract class MonoSkin : MonoBehaviour, ISkin
    {
        #region Field and Property
        /// <summary>
        /// Skinned mesh renderer of skin.
        /// </summary>
        protected SkinnedMeshRenderer meshRenderer;

        /// <summary>
        /// Mesh collider of skin.
        /// </summary>
        protected MeshCollider meshCollider;

        /// <summary>
        /// Mesh of skin.
        /// </summary>
        protected Mesh mesh;

        /// <summary>
        /// Skinned mesh renderer of skin.
        /// </summary>
        public SkinnedMeshRenderer Renderer { get { return meshRenderer; } }

        /// <summary>
        /// Mesh collider of skin.
        /// </summary>
        public MeshCollider Collider { get { return meshCollider; } }
        #endregion

        #region Protected Method
        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            Initialize();
            Rebuild();
        }

        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize();
            Rebuild();
        }

        /// <summary>
        /// Initialize mono skin.
        /// </summary>
        protected virtual void Initialize()
        {
            //Find components.
            meshRenderer = GetComponent<SkinnedMeshRenderer>();
            meshCollider = GetComponent<MeshCollider>();

            //Create mesh if need.
            if (mesh == null)
            {
                mesh = new Mesh { name = "Skin" };
            }
        }

        /// <summary>
        /// Rebuild the mesh of skin.
        /// </summary>
        /// <param name="mesh">Mesh of skin.</param>
        protected abstract void RebuildMesh(Mesh mesh);
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild the mesh of skin.
        /// </summary>
        public virtual void Rebuild()
        {
            RebuildMesh(mesh);
            meshRenderer.sharedMesh = mesh;
            meshRenderer.localBounds = mesh.bounds;

            if (meshCollider)
            {
                meshCollider.sharedMesh = null;
                meshCollider.sharedMesh = mesh;
            }
        }

        /// <summary>
        /// Attach MeshCollider to skin.
        /// </summary>
        public void AttachCollider()
        {
            var meshCollider = GetComponent<MeshCollider>();
            if (meshCollider == null)
            {
                meshCollider = gameObject.AddComponent<MeshCollider>();
            }
        }

        /// <summary>
        /// Remove MeshCollider from skin.
        /// </summary>
        public void RemoveCollider()
        {
            if (meshCollider)
            {
                Destroy(meshCollider);
                meshCollider = null;
            }
        }
        #endregion
    }
}