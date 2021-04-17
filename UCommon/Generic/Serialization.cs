/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Serialization.cs
 *  Description  :  Define Generic serialization for JsonUtility.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/17/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UCommon.Generic
{
    /// <summary>
    /// Serialization for List.
    /// </summary>
    /// <typeparam name="T">Type of list item.</typeparam>
    public class Serialization<T>
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
        public Serialization(List<T> source)
        {
            this.source = source;
        }
    }

    /// <summary>
    /// Serialization for Dictionary.
    /// </summary>
    /// <typeparam name="TKey">Type of key.</typeparam>
    /// <typeparam name="TValue">Type of value.</typeparam>
    public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
    {
        /// <summary>
        /// List of keys.
        /// </summary>
        [SerializeField]
        private List<TKey> keys;

        /// <summary>
        /// List of values.
        /// </summary>
        [SerializeField]
        private List<TValue> values;

        /// <summary>
        /// Source dictionary.
        /// </summary>
        public Dictionary<TKey, TValue> Source { private set; get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Source dictionary.</param>
        public Serialization(Dictionary<TKey, TValue> source)
        {
            Source = source;
        }

        /// <summary>
        /// On before serialize.
        /// </summary>
        public void OnBeforeSerialize()
        {
            keys = new List<TKey>(Source.Keys);
            values = new List<TValue>(Source.Values);
        }

        /// <summary>
        /// On after deserialize.
        /// </summary>
        public void OnAfterDeserialize()
        {
            Source = new Dictionary<TKey, TValue>();
            if (keys == null || values == null)
            {
                return;
            }

            var index = 0;
            foreach (var key in keys)
            {
                var value = default(TValue);
                if (index < values.Count)
                {
                    value = values[index];
                }

                Source.Add(key, value);
                index++;
            }
        }
    }
}