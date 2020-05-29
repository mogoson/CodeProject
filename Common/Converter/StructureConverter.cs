/*************************************************************************
 *  Copyright (c) 2015-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  StructureConverter.cs
 *  Description  :  Converter of structure.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  10/12/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using System.Runtime.InteropServices;

namespace MGS.Common.Converter
{
    /// <summary>
    /// Converter of structure.
    /// </summary>
    public sealed class StructureConverter
    {
        #region Public Method
        /// <summary>
        /// Convert byte array to structure.
        /// </summary>
        /// <typeparam name="T">Structure type.</typeparam>
        /// <param name="byteArray">Byte array.</param>
        /// <returns>Structure.</returns>
        public static T FromByteArray<T>(byte[] byteArray) where T : struct
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                LogUtility.LogError("Convert byte array to structure error: The byte array is null or empty.");
                return default(T);
            }

            var size = Marshal.SizeOf(default(T));
            if (size > byteArray.Length)
            {
                LogUtility.LogError("Convert byte array to structure error: The length of byte array is not match type {0}.", typeof(T).Name);
                return default(T);
            }

            var intPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(byteArray, 0, intPtr, size);
            var structure = (T)Marshal.PtrToStructure(intPtr, typeof(T));
            Marshal.FreeHGlobal(intPtr);
            return structure;
        }

        /// <summary>
        /// Convert structure to byte array.
        /// </summary>
        /// <typeparam name="T">Structure type.</typeparam>
        /// <param name="structure">Structure.</param>
        /// <returns>Byte array.</returns>
        public static byte[] ToByteArray<T>(T structure) where T : struct
        {
            var size = Marshal.SizeOf(structure);
            if (size == 0)
            {
                LogUtility.LogError("Convert structure to byte array error: The size of type {0} is zero.", typeof(T).Name);
                return null;
            }

            var intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, intPtr, true);
            var byteArray = new byte[size];
            Marshal.Copy(intPtr, byteArray, 0, size);
            Marshal.FreeHGlobal(intPtr);
            return byteArray;
        }
        #endregion
    }
}