/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FormManager.cs
 *  Description  :  Custom UI form manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.DesignPattern;
using MGS.UCommon.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Custom UI form manager.
    /// </summary>
    [AddComponentMenu("MGS/UIForm/UIFormManager")]
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster))]
    public sealed class FormManager : SingleMonoBehaviour<FormManager>, IFormManager
    {
        #region Field and Property
        /// <summary>
        /// Path of settings file under the Resources folder.
        /// </summary>
        public const string SETTINGS_PATH = "UIForm/Settings/UIFormSettings";

        /// <summary>
        /// Format of form prefab path under the Resources folder (param 0 is layer name of form, param 1 is class name of form).
        /// </summary>
        public const string PREFAB_PATH_FORMAT = "UIForm/Prefabs/{0}/{1}";

        /// <summary>
        /// Canvas component.
        /// </summary>
        public Canvas Canvas { private set; get; }

        /// <summary>
        /// CanvasScaler component.
        /// </summary>
        public CanvasScaler CanvasScaler { private set; get; }

        /// <summary>
        /// GraphicRaycaster component.
        /// </summary>
        public GraphicRaycaster GraphicRaycaster { private set; get; }

        /// <summary>
        /// Layers for custom form.
        /// </summary>
        public string[] Layers { private set; get; }

        /// <summary>
        /// Info of layers and forms.
        /// </summary>
        private Dictionary<string, List<IForm>> layerForms = new Dictionary<string, List<IForm>>();
        #endregion

        #region Public Method
        /// <summary>
        /// Open form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        public T OpenForm<T>() where T : Component, IForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                LogUtility.LogError("Open form error: The form layer \"{0}\" is not defined.", info.Layer);
                return null;
            }

            if (info.Pattern == UIFromPattern.Single)
            {
                var singleForm = FindForm<T>();
                if (singleForm != null)
                {
                    singleForm.Open();
                    return singleForm;
                }
            }

            var prefabPath = string.Format(PREFAB_PATH_FORMAT, info.Layer, typeof(T).Name);
            var formPrefab = Resources.Load<T>(prefabPath);
            if (formPrefab == null)
            {
                LogUtility.LogError("Open form error: Can not load prefab of form at path Assets/Resources/{0}.prefab.", prefabPath);
                return null;
            }

            var newForm = Instantiate(formPrefab);
            var layerRoot = transform.FindChild(info.Layer);
            newForm.transform.SetParent(layerRoot, false);
            newForm.transform.SetAsLastSibling();

            layerForms[info.Layer].Add(newForm);
            newForm.Open();
            return newForm;
        }

        /// <summary>
        /// Find form by specified type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <returns>Target form.</returns>
        public T FindForm<T>() where T : IForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                return default(T);
            }

            foreach (var form in layerForms[info.Layer])
            {
                if (form.GetType() == typeof(T))
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
        public IForm[] FindForms()
        {
            var allForms = new List<IForm>();
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
        public IForm[] FindForms(string layer)
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
        public IForm[] FindForms(IForm form, FilterOptions options)
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

            var frontForms = new List<IForm>();
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
        public T[] FindForms<T>() where T : IForm
        {
            var info = GetFormInfo<T>();
            if (!layerForms.ContainsKey(info.Layer))
            {
                return null;
            }

            var forms = new List<T>();
            foreach (var form in layerForms[info.Layer])
            {
                if (form.GetType() == typeof(T))
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
                LogUtility.LogWarning("Mirror forms error: Can not find any form in the \"{0}\" layer.", layer);
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
                    form.SetLanguage(language);
                }
            }
        }

        /// <summary>
        /// Close form by specified form.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForm(IForm form, bool dispose = false)
        {
            if (form == null)
            {
                return;
            }

            if (dispose)
            {
                var info = GetFormInfo(form);
                if (layerForms.ContainsKey(info.Layer))
                {
                    layerForms[info.Layer].Remove(form);
                }
            }
            form.Close(dispose);
        }

        /// <summary>
        /// Close form by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForm<T>(bool dispose = false) where T : IForm
        {
            var form = FindForm<T>();
            if (form == null)
            {
                return;
            }

            if (dispose)
            {
                var info = GetFormInfo<T>();
                layerForms[info.Layer].Remove(form);
            }
            form.Close(dispose);
        }

        /// <summary>
        /// Close all the forms.
        /// </summary>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForms(bool dispose = false)
        {
            if (dispose)
            {
                foreach (var forms in layerForms.Values)
                {
                    foreach (var form in forms)
                    {
                        form.Close(dispose);
                    }
                    forms.Clear();
                }
            }
            else
            {
                foreach (var forms in layerForms.Values)
                {
                    foreach (var form in forms)
                    {
                        form.Close(dispose);
                    }
                }
            }
        }

        /// <summary>
        /// Close forms by layer.
        /// </summary>
        /// <param name="layer">Target layer.</param>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForms(string layer, bool dispose = false)
        {
            if (!layerForms.ContainsKey(layer))
            {
                return;
            }

            foreach (var form in layerForms[layer])
            {
                form.Close(dispose);
            }

            if (dispose)
            {
                layerForms[layer].Clear();
            }
        }

        /// <summary>
        /// Close forms by filter options.
        /// </summary>
        /// <param name="form">Specified form instance.</param>
        /// <param name="options">Options for filter forms.</param>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForms(IForm form, FilterOptions options, bool dispose = false)
        {
            var forms = FindForms(form, options);
            if (forms == null || forms.Length == 0)
            {
                return;
            }

            foreach (var frontForm in forms)
            {
                CloseForm(frontForm, dispose);
            }
        }

        /// <summary>
        /// Close form by specified forms.
        /// </summary>
        /// <param name="forms">Specified form instances.</param>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForms(IEnumerable<IForm> forms, bool dispose = false)
        {
            if (forms == null)
            {
                return;
            }

            if (dispose)
            {
                foreach (var form in forms)
                {
                    var info = GetFormInfo(form);
                    if (layerForms.ContainsKey(info.Layer))
                    {
                        layerForms[info.Layer].Remove(form);
                    }
                    form.Close(dispose);
                }
            }
            else
            {
                foreach (var form in forms)
                {
                    form.Close(dispose);
                }
            }
        }

        /// <summary>
        /// Close forms by specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="dispose">Dispose form on close?</param>
        public void CloseForms<T>(bool dispose = false) where T : IForm
        {
            var forms = FindForms<T>();
            if (forms == null || forms.Length == 0)
            {
                return;
            }

            if (dispose)
            {
                var info = GetFormInfo<T>();
                foreach (var form in forms)
                {
                    layerForms[info.Layer].Remove(form);
                    form.Close(dispose);
                }
            }
            else
            {
                foreach (var form in forms)
                {
                    form.Close(dispose);
                }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Awake manager.
        /// </summary>
        private void Awake()
        {
            gameObject.name = typeof(Canvas).Name;
            gameObject.layer = 5;

            Canvas = GetComponent<Canvas>();
            Canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            CanvasScaler = GetComponent<CanvasScaler>();
            GraphicRaycaster = GetComponent<GraphicRaycaster>();

            var settings = ReadSettings();
            Layers = settings.layers.ToArray();
            CreateLayerRoots(Layers);
        }

        /// <summary>
        /// Read settings from local file.
        /// </summary>
        /// <returns>Settings of UI form.</returns>
        private FormSettings ReadSettings()
        {
            var settings = Resources.Load<FormSettings>(SETTINGS_PATH);
            if (settings == null)
            {
                LogUtility.LogError("Read settings error: Can not load settings from file at path Assets/Resources/{0}.asset.", SETTINGS_PATH);
                settings = ScriptableObject.CreateInstance<FormSettings>();
            }
            return settings;
        }

        /// <summary>
        /// Create root for layers.
        /// </summary>
        /// <param name="layers">UI form layers.</param>
        private void CreateLayerRoots(string[] layers)
        {
            foreach (var layer in layers)
            {
                if (string.IsNullOrEmpty(layer))
                {
                    LogUtility.LogError("Create layer root error: The name of layer is null or empty.");
                    continue;
                }

                if (layerForms.ContainsKey(layer))
                {
                    LogUtility.LogWarning("Create layer root cancelled: The layer root named \"{0}\" is exist.");
                    continue;
                }

                var layerRoot = new GameObject(layer);
                var layerRect = layerRoot.AddComponent<RectTransform>();

                layerRoot.layer = gameObject.layer;
                layerRect.SetParent(transform, false);

                layerRect.anchorMin = Vector2.zero;
                layerRect.anchorMax = Vector2.one;
                layerRect.offsetMin = Vector2.zero;
                layerRect.offsetMax = Vector2.zero;
                layerRect.localScale = Vector3.one;

                layerForms.Add(layer, new List<IForm>());
            }
        }

        /// <summary>
        /// Get the UIFormInfo attribute of specified form type.
        /// </summary>
        /// <typeparam name="T">Specified form type.</typeparam>
        /// <param name="form">Specified form instance.</param>
        /// <returns>The UIFormInfo attribute of specified form type.</returns>
        private FormInfoAttribute GetFormInfo<T>(T form = default(T))
        {
            var infos = typeof(T).GetCustomAttributes(typeof(FormInfoAttribute), true);
            if (infos.Length == 0)
            {
                LogUtility.LogWarning("Get form attribute info failed: Can not find the FormInfoAttribute on the type {0}.", typeof(T).Name);
                return new FormInfoAttribute(UIFromPattern.Single, "Default");
            }
            return infos[0] as FormInfoAttribute;
        }
        #endregion
    }
}