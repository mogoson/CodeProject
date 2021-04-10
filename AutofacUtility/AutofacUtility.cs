/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacUtility.cs
 *  Description  :  Utility for autofac.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Autofac
{
    /// <summary>
    /// Utility for Autofac.
    /// </summary>
    public sealed class AutofacUtility
    {
        #region Field And Property
        /// <summary>
        /// Autofac container.
        /// </summary>
        public static IContainer Container { private set; get; }

        /// <summary>
        /// Container builder.
        /// </summary>
        private static readonly ContainerBuilder builder = new ContainerBuilder();
        #endregion

        #region Private Method
        /// <summary>
        /// Build container.
        /// </summary>
        /// <param name="types">Register types.</param>
        /// <returns>Container.</returns>
        private static IContainer BuildContainer(IEnumerable<Type> types)
        {
            RegisterTypes(builder, types);
            Container = builder.Build(Builder.ContainerBuildOptions.None);
            return Container;
        }

        /// <summary>
        /// Register types to builder.
        /// </summary>
        /// <param name="builder">Container builder.</param>
        /// <param name="types">Register types.</param>
        private static void RegisterTypes(ContainerBuilder builder, IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (!Attribute.IsDefined(type, typeof(AutofacRegisterAttribute)))
                {
                    continue;
                }

                var irBuilder = builder.RegisterType(type).AsImplementedInterfaces().AsSelf();
                var attribute = (AutofacRegisterAttribute)Attribute.GetCustomAttribute(type, typeof(AutofacRegisterAttribute));
                if (attribute.Singleton)
                {
                    irBuilder.SingleInstance();
                }

                if (attribute.ServiceKey == null || attribute.ServiceType == null)
                {
                    continue;
                }

                irBuilder.Keyed(attribute.ServiceKey, attribute.ServiceType);
            }
        }

        /// <summary>
        /// Resolve register types.
        /// </summary>
        /// <param name="infos">Register infos(assemblyName, typeNames).</param>
        private static IEnumerable<Type> ResolveTypes(IDictionary<string, ICollection<string>> infos)
        {
            if (infos == null || infos.Count <= 0)
            {
                return null;
            }

            var types = new List<Type>();
            foreach (var assemblyName in infos.Keys)
            {
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                if (assembly == null)
                {
                    continue;
                }

                var typeNames = infos[assemblyName];
                if (typeNames == null || typeNames.Count <= 0)
                {
                    continue;
                }

                foreach (var typeName in typeNames)
                {
                    var type = assembly.GetType(typeName);
                    if (type == null)
                    {
                        continue;
                    }
                    types.Add(type);
                }
            }
            return types;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Register types of current domain assemblies.
        /// </summary>
        /// <returns>IContainer.</returns>
        public static IContainer Register()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return Register(assemblies);
        }

        /// <summary>
        /// Register types of target assemblies.
        /// </summary>
        /// <param name="assemblies">Target assemblies.</param>
        /// <returns>IContainer.</returns>
        public static IContainer Register(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null)
            {
                return null;
            }

            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.GetTypes());
            }
            return Register(types);
        }

        /// <summary>
        /// Register target types.
        /// </summary>
        /// <param name="types">Target types.</param>
        /// <returns>IContainer.</returns>
        public static IContainer Register(IEnumerable<Type> types)
        {
            if (types == null)
            {
                return null;
            }

            return BuildContainer(types);
        }

        /// <summary>
        /// Register types of assemblies.
        /// </summary>
        /// <param name="infos">Register infos(assemblyName, typeNames).</param>
        /// <returns>IContainer.</returns>
        public static IContainer Register(IDictionary<string, ICollection<string>> infos)
        {
            var types = ResolveTypes(infos);
            return Register(types);
        }

        /// <summary>
        /// Resolve TService.
        /// </summary>
        /// <typeparam name="TService">TService type.</typeparam>
        /// <returns>TService</returns>
        public static TService Resolve<TService>()
        {
            if (Container == null)
            {
                return default(TService);
            }
            return Container.Resolve<TService>();
        }

        /// <summary>
        /// Resolve TService.
        /// </summary>
        /// <typeparam name="TService">TService type.</typeparam>
        /// <param name="parameters">Parameters for Resolve.</param>
        /// <returns>TService</returns>
        public static TService Resolve<TService>(params Parameter[] parameters)
        {
            if (Container == null)
            {
                return default(TService);
            }
            return Container.Resolve<TService>(parameters);
        }
        #endregion
    }
}