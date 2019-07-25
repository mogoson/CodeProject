/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTrigger.cs
 *  Description  :  Trigger of context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.DesignPattern;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.ContextMenu
{
    /// <summary>
    /// Trigger of context menu.
    /// </summary>
    [AddComponentMenu("MGS/ContextMenu/ContextMenuTrigger")]
    [RequireComponent(typeof(Camera))]
    public sealed class ContextMenuTrigger : SingleMonoBehaviour<ContextMenuTrigger>, IContextMenuTrigger
    {
        #region Field and Property
        /// <summary>
        /// LayerMask of raycast.
        /// </summary>
        [Tooltip("LayerMask of raycast.")]
        [SerializeField]
        private LayerMask layerMask = 1;

        /// <summary>
        /// Max distance of raycast.
        /// </summary>
        [Tooltip("Max distance of raycast.")]
        [SerializeField]
        private float maxDistance = 100;

        /// <summary>
        /// Handler of contex menu.
        /// </summary>
        [Tooltip("Handler of contex menu.")]
        [SerializeField]
        private ContextMenuHandler menuHandler = null;

        /// <summary>
        /// Camera to raycast.
        /// </summary>
        public Camera RayCamera { private set; get; }

        /// <summary>
        /// LayerMask of raycast.
        /// </summary>
        public LayerMask LayerMask
        {
            set { layerMask = value; }
            get { return layerMask; }
        }

        /// <summary>
        /// Max distance of raycast.
        /// </summary>
        public float MaxDistance
        {
            set { maxDistance = value; }
            get { return maxDistance; }
        }

        /// <summary>
        /// Handler of contex menu.
        /// </summary>
        public IContextMenuHandler MenuHandler { set; get; }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake component.
        /// </summary>
        protected override void SingleAwake()
        {
            base.SingleAwake();

            RayCamera = GetComponent<Camera>();
            MenuHandler = menuHandler;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Update component.
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                OnMenuTriggerExit();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                OnMenuTriggerExit();

                var ray = RayCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask))
                {
                    OnMenuTriggerEnter(hitInfo);
                }
            }
        }

        /// <summary>
        /// On context menu trigger enter.
        /// </summary>
        /// <param name="hitInfo">Raycast hit info of target.</param>
        private void OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            if (MenuHandler == null)
            {
                LogUtility.LogWarning(0, "Do nothing on context menu trigger enter: The handler of trigger is null.");
                return;
            }

            MenuHandler.OnMenuTriggerEnter(hitInfo);
        }

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        private void OnMenuTriggerExit()
        {
            if (MenuHandler == null)
            {
                LogUtility.LogWarning(0, "Do nothing on context menu trigger exit: The handler of trigger is null.");
                return;
            }

            MenuHandler.OnMenuTriggerExit();
        }
        #endregion
    }
}