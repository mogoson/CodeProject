/*************************************************************************
 *  Copyright (c) 2017-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTrigger.cs
 *  Description  :  Trigger of context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.Utility;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Trigger of context menu.
    /// </summary>
    [AddComponentMenu("MGS/UGUI/ContextMenuTrigger")]
    [RequireComponent(typeof(Camera))]
    public class ContextMenuTrigger : MonoBehaviour, IContextMenuTrigger
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
        /// Handler of contex menu trigger.
        /// </summary>
        [Tooltip("Handler of contex menu trigger.")]
        [SerializeField]
        private ContextMenuTriggerHandler handler = null;

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
        /// Handler of contex menu trigger.
        /// </summary>
        public IContextMenuTriggerHandler Handler { set; get; }

        /// <summary>
        /// Context menu form of trigger.
        /// </summary>
        private IContextMenuForm menuForm;
        #endregion

        #region Private Method
        /// <summary>
        /// Awake component.
        /// </summary>
        private void Awake()
        {
            RayCamera = GetComponent<Camera>();
            Handler = handler;
        }

        /// <summary>
        /// Update component.
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (menuForm == null || menuForm.IsDisposed)
                {
                    return;
                }

                if (EventSystemUtility.CheckPointerOverGameObject(menuForm.RectTrans.gameObject))
                {
                    return;
                }
                OnMenuTriggerExit();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (menuForm != null && !menuForm.IsDisposed)
                {
                    if (EventSystemUtility.CheckPointerOverGameObject(menuForm.RectTrans.gameObject))
                    {
                        return;
                    }
                    OnMenuTriggerExit();
                }

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
            if (Handler == null)
            {
                LogUtility.LogWarning("Do nothing on menu trigger enter: The handler of menu trigger is null.");
                return;
            }
            menuForm = Handler.OnMenuTriggerEnter(hitInfo);
        }

        /// <summary>
        /// On context menu trigger exit.
        /// </summary>
        /// <returns></returns>
        private void OnMenuTriggerExit()
        {
            if (Handler == null)
            {
                LogUtility.LogWarning("Do nothing on menu trigger exit: The handler of menu trigger is null.");
                return;
            }
            Handler.OnMenuTriggerExit(menuForm);
            menuForm = null;
        }
        #endregion
    }
}