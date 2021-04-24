/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacRegisterAttribute.cs
 *  Description  :  Attribute for register autofac.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace Autofac
{
    /// <summary>
    /// Attribute for register autofac.
    /// </summary>
    public class AutofacRegisterAttribute : Attribute
    {
        /// <summary>
        /// Is singleton mode?
        /// </summary>
        public bool Singleton { set; get; }

        /// <summary>
        /// The key for service.
        /// </summary>
        public object ServiceKey { set; get; }

        /// <summary>
        /// The Type for service.
        /// </summary>
        public Type ServiceType { set; get; }
    }
}