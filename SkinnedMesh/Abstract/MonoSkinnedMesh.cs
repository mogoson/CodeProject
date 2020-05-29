/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSkinnedMesh.cs
 *  Description  :  Define Skin to render dynamic mesh.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.SkinnedMesh
{
    /// <summary>
    /// Render dynamic skinned mesh.
    /// </summary>
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public abstract class MonoSkinnedMesh : MonoBehaviour, ISkinnedMesh
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
        /// Skin is initialized?
        /// </summary>
        protected bool isInitialized = false;

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
            Rebuild();
        }

        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
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

            //Create mesh.
            mesh = new Mesh { name = "Skin" };
            isInitialized = true;
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
            if (!isInitialized)
            {
                Initialize();
            }

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