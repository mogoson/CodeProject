/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleMonoBehaviour.cs
 *  Description  :  Define the base of single MonoBehaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCommon.DesignPattern
{
    /// <summary>
    /// MonoBehaviour with a single instance.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    [DisallowMultipleComponent]
    public abstract class SingleMonoBehaviour<T> : MonoBehaviour where T : SingleMonoBehaviour<T>
    {
        #region Nested Class
        /// <summary>
        /// Inner singleton provide instance.
        /// </summary>
        private class InnerSingleton
        {
            #region Property
            /// <summary>
            /// Single instance of the specified type T.
            /// </summary>
            internal static readonly T Instance = new GameObject(typeof(T).Name).AddComponent<T>();
            #endregion

            #region Static Method
            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
            /// </summary>
            static InnerSingleton()
            {
                DontDestroyOnLoad(Instance);
            }
            #endregion
        }
        #endregion

        #region Property
        /// <summary>
        /// Single instance of the specified type T.
        /// </summary>
        public static T Instance { get { return InnerSingleton.Instance; } }
        #endregion
    }
}