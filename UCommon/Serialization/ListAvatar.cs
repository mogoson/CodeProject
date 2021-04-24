/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ListAvatar.cs
 *  Description  :  Avatar for List serialize by JsonUtility.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/17/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UCommon.Serialization
{
    /// <summary>
    /// Avatar for List serialize by JsonUtility.
    /// </summary>
    /// <typeparam name="T">Type of list item.
    /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
    /// </typeparam>
    public class ListAvatar<T>
    {
        /// <summary>
        /// Source list.
        /// </summary>
        [SerializeField]
        private List<T> source;

        /// <summary>
        /// Source list.
        /// </summary>
        public List<T> Source { get { return source; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Source list.</param>
        public ListAvatar(List<T> source)
        {
            this.source = source;
        }
    }
}