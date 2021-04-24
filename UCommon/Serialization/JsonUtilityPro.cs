/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonUtilityPro.cs
 *  Description  :  JsonUtility Pro.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UCommon.Serialization
{
    /// <summary>
    /// JsonUtility Pro.
    /// </summary>
    public sealed class JsonUtilityPro
    {
        /// <summary>
        /// Deserialize List from json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="json">Json text of List.</param>
        /// <returns>List object.</returns>
        public static List<T> FromJson<T>(string json)
        {
            var avatarJson = ToListAvatar(json);
            return FromAvatarJson<T>(avatarJson);
        }

        /// <summary>
        /// Deserialize List from avatar json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="json">Json text of ListAvatar.</param>
        /// <returns>List object.</returns>
        public static List<T> FromAvatarJson<T>(string json)
        {
            var avatar = JsonUtility.FromJson<ListAvatar<T>>(json);
            if (avatar == null)
            {
                return null;
            }

            return avatar.Source;
        }

        /// <summary>
        /// Serialize List to json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="list">Source list.</param>
        /// <returns>Json text of List.</returns>
        public static string ToJson<T>(List<T> list)
        {
            var avatarJson = ToAvatarJson<T>(list);
            return FromListAvatar(avatarJson);
        }

        /// <summary>
        /// Serialize List to avatar json.
        /// </summary>
        /// <typeparam name="T">Type of List item.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="list">Source list.</param>
        /// <returns>Json text of ListAvatar.</returns>
        public static string ToAvatarJson<T>(List<T> list)
        {
            var avatar = new ListAvatar<T>(list);
            return JsonUtility.ToJson(avatar);
        }

        /// <summary>
        /// Deserialize Dictionary from json.
        /// </summary>
        /// <typeparam name="TKey">Type of Dictionary key.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <typeparam name="TValue">Type of Dictionary velue.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="json">Json text of DictionaryAvatar.</param>
        /// <returns>Dictionary object.</returns>
        public static Dictionary<TKey, TValue> FromJson<TKey, TValue>(string json)
        {
            var avatar = JsonUtility.FromJson<DictionaryAvatar<TKey, TValue>>(json);
            if (avatar == null)
            {
                return null;
            }

            return avatar.Source;
        }

        /// <summary>
        /// Serialize Dictionary to json.
        /// </summary>
        /// <typeparam name="TKey">Type of Dictionary key.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <typeparam name="TValue">Type of Dictionary velue.
        /// The T must with SerializableAttribute and public field or private property with SerializeField Attribute if custom type.
        /// </typeparam>
        /// <param name="dictionary">Source dictionary.</param>
        /// <returns>Json text of DictionaryAvatar.</returns>
        public static string ToJson<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            var avatar = new DictionaryAvatar<TKey, TValue>(dictionary);
            return JsonUtility.ToJson(avatar);
        }

        /// <summary>
        /// Parse list json to ListAvatar json.
        /// </summary>
        /// <param name="json">Json text of list.</param>
        /// <returns>Json text of ListAvatar.</returns>
        public static string ToListAvatar(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return json;
            }

            return "{\"source\":" + json + "}";
        }

        /// <summary>
        /// Parse ListAvatar json to list json.
        /// </summary>
        /// <param name="json">Json text of ListAvatar.</param>
        /// <returns>Json text of list.</returns>
        public static string FromListAvatar(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return json;
            }

            var listJson = json.Replace("{\"source\":", string.Empty);
            return listJson.Remove(listJson.LastIndexOf("}"));
        }
    }
}