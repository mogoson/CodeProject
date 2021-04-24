/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DictionaryAvatar.cs
 *  Description  :  Avatar for Dictionary serialize by JsonUtility.
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
    /// Avatar for Dictionary serialize by JsonUtility.
    /// </summary>
    /// <typeparam name="TKey">Type of key.
    /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
    /// </typeparam>
    /// <typeparam name="TValue">Type of value.
    /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
    /// </typeparam>
    public class DictionaryAvatar<TKey, TValue> : ISerializationCallbackReceiver
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
        public DictionaryAvatar(Dictionary<TKey, TValue> source)
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