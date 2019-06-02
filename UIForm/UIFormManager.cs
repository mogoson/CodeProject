/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFormManager.cs
 *  Description  :  Custom UI form manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Enum;
using MGS.Common.Logger;
using MGS.UCommon.DesignPattern;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.UIForm
{
    /// <summary>
    /// Custom UI form manager.
    /// </summary>
    [AddComponentMenu("MGS/UIForm/UIFormManager")]
    [RequireComponent(typeof(Canvas))]
    public sealed class UIFormManager : SingleMonoBehaviour<UIFormManager>, IUIFormManager
    {
        #region Field and Property
        /// <summary>
        /// Info of layers and forms.
        /// </summary>
        private Dictionary<string, List<IUIForm>> layerForms = new Dictionary<string, List<IUIForm>>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake manager.
        /// </summary>
        protected override void SingleAwake()
        {
            base.SingleAwake();

            var settings = ReadSettings();
            CreateLayerRoots(settings.Layers);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Open form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="data">Data of form to show.</param>
        public T OpenForm<T>(object data = null) where T : Component, IUIForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                LogUtility.LogError(0, "Open form is error: The form layer {0} is not defined.", info.Layer);
                return null;
            }

            if (info.Pattern == UIFromPattern.Single)
            {
                var form = FindForm<T>();
                if (form != null)
                {
                    form.Open(data);
                    return form;
                }
            }

            try
            {
                var prefabPath = string.Format("UIForm/Prefabs/{0}/{1}", info.Layer, typeof(T).Name);
                var formPrefab = Resources.Load<T>(prefabPath);
                var form = Instantiate(formPrefab);

                var layerRoot = transform.FindChild(info.Layer);
                form.transform.parent = layerRoot;
                layerForms[info.Layer].Add(form);

                form.Open(data);
                return form;
            }
            catch (Exception ex)
            {
                LogUtility.LogError(0, "Open form is error: {0}", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Find form by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target form.</returns>
        public T FindForm<T>() where T : IUIForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                return default(T);
            }

            foreach (var form in layerForms[info.Layer])
            {
                if (form is T)
                {
                    return (T)form;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Find all forms.
        /// </summary>
        /// <returns>All forms.</returns>
        public IUIForm[] FindForms()
        {
            var allForms = new List<IUIForm>();
            foreach (var forms in layerForms.Values)
            {
                allForms.AddRange(forms);
            }
            return allForms.ToArray();
        }

        /// <summary>
        /// Find forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <returns>Target forms.</returns>
        public IUIForm[] FindForms(string layer)
        {
            if (!layerForms.ContainsKey(layer))
            {
                return null;
            }
            return layerForms[layer].ToArray();
        }

        /// <summary>
        /// Find forms by filter options.
        /// </summary>
        /// <param name="form">Specified form.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <returns>Target forms.</returns>
        public IUIForm[] FindForms(IUIForm form, FilterOptions options)
        {
            if (form == null || !(form is Component))
            {
                return null;
            }

            var info = GetFormInfo(form);
            if (!layerForms.ContainsKey(info.Layer))
            {
                return null;
            }

            var layers = new List<string>(layerForms.Keys);
            var layerIndex = layers.IndexOf(info.Layer);

            var start = layerIndex;
            var count = layers.Count;
            var isFront = true;
            if (options == FilterOptions.BackForms)
            {
                start = 0;
                count = layerIndex;
                isFront = false;
            }

            var frontForms = new List<IUIForm>();
            for (int i = start; i < count; i++)
            {
                frontForms.AddRange(layerForms[layers[i]]);
            }

            var formIndex = (form as Component).transform.GetSiblingIndex();
            foreach (var siblingForm in layerForms[info.Layer])
            {
                if (isFront & (siblingForm as Component).transform.GetSiblingIndex() > formIndex)
                {
                    frontForms.Add(siblingForm);
                }
            }
            return frontForms.ToArray();
        }

        /// <summary>
        /// Find forms by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target forms.</returns>
        public T[] FindForms<T>() where T : IUIForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                return null;
            }

            var forms = new List<T>();
            foreach (var form in layerForms[info.Layer])
            {
                if (form is T)
                {
                    forms.Add((T)form);
                }
            }
            return forms.ToArray();
        }

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="mode">Mode of mirror.</param>
        public void MirrorForms(MirrorMode mode)
        {
            foreach (var forms in layerForms.Values)
            {
                foreach (var form in forms)
                {
                    form.Mirror(mode);
                }
            }
        }

        /// <summary>
        /// Mirror forms.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="mode">Mode of mirror.</param>
        public void MirrorForms(string layer, MirrorMode mode)
        {
            if (!layerForms.ContainsKey(layer))
            {
                LogUtility.LogWarning(0, "Can not find any form in the layer {0}.", layer);
                return;
            }

            foreach (var form in layerForms[layer])
            {
                form.Mirror(mode);
            }
        }

        /// <summary>
        /// Set language of forms.
        /// </summary>
        /// <param name="language">Language name.</param>
        public void LanguageForms(string language)
        {
            foreach (var forms in layerForms.Values)
            {
                foreach (var form in forms)
                {
                    form.Language(language);
                }
            }
        }

        /// <summary>
        /// Close form by specified form.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForm(IUIForm form, bool destroy = false)
        {
            if (form == null)
            {
                return;
            }

            if (destroy)
            {
                var info = GetFormInfo(form);
                if (layerForms.ContainsKey(info.Layer))
                {
                    layerForms[info.Layer].Remove(form);
                }
            }
            form.Close(destroy);
        }

        /// <summary>
        /// Close form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForm<T>(bool destroy = false) where T : IUIForm
        {
            var form = FindForm<T>();
            if (form == null)
            {
                return;
            }

            if (destroy)
            {
                var info = GetFormInfo<T>();
                layerForms[info.Layer].Remove(form);
            }
            form.Close(destroy);
        }

        /// <summary>
        /// Close all the forms.
        /// </summary>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForms(bool destroy = false)
        {
            foreach (var forms in layerForms.Values)
            {
                foreach (var form in forms)
                {
                    form.Close(destroy);
                }
            }

            if (destroy)
            {
                foreach (var forms in layerForms.Values)
                {
                    forms.Clear();
                }
            }
        }

        /// <summary>
        /// Close forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForms(string layer, bool destroy = false)
        {
            if (!layerForms.ContainsKey(layer))
            {
                return;
            }

            foreach (var form in layerForms[layer])
            {
                form.Close(destroy);
            }

            if (destroy)
            {
                layerForms[layer].Clear();
            }
        }

        /// <summary>
        /// Close forms by filter options.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForms(IUIForm form, FilterOptions options, bool destroy = false)
        {
            var forms = FindForms(form, options);
            if (forms == null || forms.Length == 0)
            {
                return;
            }

            foreach (var frontForm in forms)
            {
                CloseForm(frontForm, destroy);
            }
        }

        /// <summary>
        /// Close forms by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="destroy">Destroy form on closed?</param>
        public void CloseForms<T>(bool destroy = false) where T : IUIForm
        {
            var forms = FindForms<T>();
            if (forms == null || forms.Length == 0)
            {
                return;
            }

            if (destroy)
            {
                var info = GetFormInfo<T>();
                foreach (var form in forms)
                {
                    layerForms[info.Layer].Remove(form);
                }
            }

            foreach (var form in forms)
            {
                form.Close(destroy);
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Read settings from local file.
        /// </summary>
        /// <returns>Settings of UI form.</returns>
        private UIFormSettings ReadSettings()
        {
            try
            {
                return Resources.Load<UIFormSettings>("UIForm/Settings/UIFormSettings");
            }
            catch (Exception ex)
            {
                LogUtility.LogError(0, "Read settings from local file error: {0}", ex.Message);
                return ScriptableObject.CreateInstance<UIFormSettings>();
            }
        }

        /// <summary>
        /// Create root for layers.
        /// </summary>
        /// <param name="layers">UI form layers.</param>
        private void CreateLayerRoots(List<string> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                var layer = layers[i];
                var layerRoot = new GameObject(layer);
                var layerRect = layerRoot.AddComponent<RectTransform>();

                layerRoot.layer = gameObject.layer;
                layerRect.SetParent(transform);
                layerRect.SetSiblingIndex(i);

                layerRect.anchorMin = Vector2.zero;
                layerRect.anchorMax = Vector2.one;
                layerRect.offsetMin = Vector2.zero;
                layerRect.offsetMax = Vector2.zero;
                layerRect.localScale = Vector3.one;

                layerForms.Add(layer, new List<IUIForm>());
            }
        }

        /// <summary>
        /// Get the UIFormInfo attribute of specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="form">Specified form instance.</param>
        /// <returns>The UIFormInfo attribute of specified form type.</returns>
        private UIFormInfoAttribute GetFormInfo<T>(T form = default(T))
        {
            var infos = typeof(T).GetCustomAttributes(typeof(UIFormInfoAttribute), true);
            if (infos.Length == 0)
            {
                LogUtility.LogWarning(0, "Can not find the UIFormInfoAttribute on the type {0}.", typeof(T).Name);
                return new UIFormInfoAttribute(UIFromPattern.Single, "Default");
            }
            return infos[0] as UIFormInfoAttribute;
        }
        #endregion
    }
}