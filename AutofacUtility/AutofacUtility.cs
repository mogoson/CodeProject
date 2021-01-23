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
        #endregion

        #region Private Method
        /// <summary>
        /// Build container.
        /// </summary>
        /// <param name="registerInfos">Register infos.</param>
        /// <returns>IContainer.</returns>
        private static IContainer BuildContainer(IDictionary<string, ICollection<string>> registerInfos)
        {
            if (registerInfos == null || registerInfos.Count <= 0)
            {
                return null;
            }

            var builder = new ContainerBuilder();
            RegisterTypes(builder, registerInfos);
            return builder.Build(Builder.ContainerBuildOptions.None);
        }

        /// <summary>
        /// Register types to builder.
        /// </summary>
        /// <param name="builder">Container builder.</param>
        /// <param name="registerInfos">Register infos.</param>
        private static void RegisterTypes(ContainerBuilder builder, IDictionary<string, ICollection<string>> registerInfos)
        {
            if (builder == null || registerInfos == null || registerInfos.Count <= 0)
            {
                return;
            }

            foreach (var assemblyName in registerInfos.Keys)
            {
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                var typeNames = registerInfos[assemblyName];
                foreach (var typeName in typeNames)
                {
                    var type = assembly.GetType(typeName);
                    var irBuilder = builder.RegisterType(type).AsImplementedInterfaces().AsSelf();

                    var register = (AutofacRegisterAttribute)Attribute.GetCustomAttribute(type, typeof(AutofacRegisterAttribute));
                    if (register.Singleton)
                    {
                        irBuilder.SingleInstance();
                    }

                    if (register.ServiceKey == null || register.ServiceType == null)
                    {
                        continue;
                    }

                    irBuilder.Keyed(register.ServiceKey, register.ServiceType);
                }
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Initialize utility.
        /// </summary>
        /// <param name="registerInfos">Register infos(assemblyName, typeNames).</param>
        /// <returns>IContainer.</returns>
        public static IContainer Initialize(IDictionary<string, ICollection<string>> registerInfos)
        {
            Container = BuildContainer(registerInfos);
            return Container;
        }

        /// <summary>
        /// Resolve TService.
        /// </summary>
        /// <typeparam name="TService">TService type.</typeparam>
        /// <returns>TService</returns>
        public static TService Resolve<TService>()
        {
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
            return Container.Resolve<TService>(parameters);
        }
        #endregion
    }
}