/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ByteConverter.cs
 *  Description  :  Converter of byte array.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/12/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using System;

namespace MGS.Common.Converter
{
    /// <summary>
    /// Converter of byte array.
    /// </summary>
    public static class ByteConverter
    {
        #region Public Method
        /// <summary>
        /// Byte array to Boolean array.
        /// </summary>
        /// <returns>Convert Boolean array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Boolean count.</param>
        /// <returns>Boolean array.</returns>
        public static bool[] ToBoolean(byte[] bytes, int start = 0, int count = 1)
        {
            //1(1 byte to a Boolean)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 1)
            {
                LogUtility.LogError(0, "Byte array to Boolean array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, bytes.Length - start);
            var booleanArray = new bool[count];
            for (var i = 0; i < count; i++)
            {
                booleanArray[i] = BitConverter.ToBoolean(bytes, start + i);
            }
            return booleanArray;
        }

        /// <summary>
        /// Byte array to Int16 array.
        /// </summary>
        /// <returns>Convert Int16 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int16 count.</param>
        /// <returns>Int16 array.</returns>
        public static short[] ToInt16(byte[] bytes, int start = 0, int count = 1)
        {
            //2(2 bytes to a Int16)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 2)
            {
                LogUtility.LogError(0, "Byte array to Int16 array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 2);
            var int16Array = new short[count];
            for (var i = 0; i < count; i++)
            {
                int16Array[i] = BitConverter.ToInt16(bytes, start + i * 2);
            }
            return int16Array;
        }

        /// <summary>
        /// Byte array to Int32 array.
        /// </summary>
        /// <returns>Convert Int32 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int32 count.</param>
        /// <returns>Int32 array.</returns>
        public static int[] ToInt32(byte[] bytes, int start = 0, int count = 1)
        {
            //4(4 bytes to a Int32)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 4)
            {
                LogUtility.LogError(0, "Byte array to Int32 array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 4);
            var int32Array = new int[count];
            for (var i = 0; i < count; i++)
            {
                int32Array[i] = BitConverter.ToInt32(bytes, start + i * 4);
            }
            return int32Array;
        }

        /// <summary>
        /// Byte array to Int64 array.
        /// </summary>
        /// <returns>Convert Int64 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int64 count.</param>
        /// <returns>Int64 array.</returns>
        public static long[] ToInt64(byte[] bytes, int start = 0, int count = 1)
        {
            //8(8 bytes to a Int64)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 8)
            {
                LogUtility.LogError(0, "Byte array to Int64 array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 8);
            var int64Array = new long[count];
            for (var i = 0; i < count; i++)
            {
                int64Array[i] = BitConverter.ToInt64(bytes, start + i * 8);
            }
            return int64Array;
        }

        /// <summary>
        /// Byte array to Char array.
        /// </summary>
        /// <returns>Convert Char array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Char count.</param>
        /// <returns>Char array.</returns>
        public static char[] ToChar(byte[] bytes, int start = 0, int count = 1)
        {
            //2(2 bytes to a Char)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 2)
            {
                LogUtility.LogError(0, "Byte array to Char array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 2);
            var charArray = new char[count];
            for (var i = 0; i < count; i++)
            {
                charArray[i] = BitConverter.ToChar(bytes, start + i * 2);
            }
            return charArray;
        }

        /// <summary>
        /// Byte array to Single array.
        /// </summary>
        /// <returns>Convert Single array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Single count.</param>
        /// <returns>Single array.</returns>
        public static float[] ToSingle(byte[] bytes, int start = 0, int count = 1)
        {
            //4(4 bytes to a Single)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 4)
            {
                LogUtility.LogError(0, "Byte array to Single array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 4);
            var singleArray = new float[count];
            for (var i = 0; i < count; i++)
            {
                singleArray[i] = BitConverter.ToSingle(bytes, start + i * 4);
            }
            return singleArray;
        }

        /// <summary>
        /// Byte array to Double array.
        /// </summary>
        /// <returns>Convert Double array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Double count.</param>
        /// <returns>Double array.</returns>
        public static double[] ToDouble(byte[] bytes, int start = 0, int count = 1)
        {
            //8(8 bytes to a Double)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 8)
            {
                LogUtility.LogError(0, "Byte array to Double array error: The param is invalid.");
                return null;
            }

            count = Math.Min(count, (bytes.Length - start) / 8);
            var doubleArray = new double[count];
            for (var i = 0; i < count; i++)
            {
                doubleArray[i] = BitConverter.ToDouble(bytes, start + i * 8);
            }
            return doubleArray;
        }
        #endregion
    }
}