/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacEditor.cs
 *  Description  :  Editor for AutofacConfig.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Autofac.Editor
{
    public class AutofacEditor : AssetPostprocessor
    {
        static readonly string CONFIGURATOR_FILE_PATH = string.Format("{0}/Scripts/Autofac/AutofacConfigurator.cs", Application.dataPath);
        const string INFO_CODES = "/*INFOCODES*/";

        [MenuItem("Tool/Autofac Editor/Update Configurator")]
        static void UpdateConfigurator()
        {
            var infoCodes = INFO_CODES;
            var infos = SearchRegisterInfos();
            if (infos.Count > 0)
            {
                infoCodes = BuidInfoCodes(infos);
            }

            var configuratorTempCodes = Properties.Resources.AutofacConfigurator;
            var configuratorCodes = configuratorTempCodes.Replace(INFO_CODES, infoCodes);

            File.WriteAllText(CONFIGURATOR_FILE_PATH, configuratorCodes);
            AssetDatabase.Refresh();
        }

        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnDidReloadScripts()
        {
            UpdateConfigurator();
        }

        static IDictionary<string, ICollection<string>> SearchRegisterInfos()
        {
            var infos = new Dictionary<string, ICollection<string>>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = new List<string>();
                foreach (var type in assembly.GetTypes())
                {
                    if (Attribute.IsDefined(type, typeof(AutofacRegisterAttribute)))
                    {
                        types.Add(string.Format("{0}", type.FullName));
                    }
                }

                if (types.Count > 0)
                {
                    infos[assembly.FullName] = types;
                }
            }
            return infos;
        }

        static string BuidInfoCodes(IDictionary<string, ICollection<string>> infos)
        {
            var infoCodes = string.Empty;
            foreach (var assemblyName in infos.Keys)
            {
                var types = infos[assemblyName];
                var typeCodeLines = string.Empty;
                foreach (var typeName in types)
                {
                    typeCodeLines += string.Format("\r\n                \"{0}\",", typeName);
                }

                var typeListCodes = string.Format("new List<string>(){{{0}}}", typeCodeLines);
                infoCodes += string.Format("            {{\"{0}\", {1} \r\n            }},\r\n", assemblyName, typeListCodes);
            }
            return infoCodes;
        }
    }
}