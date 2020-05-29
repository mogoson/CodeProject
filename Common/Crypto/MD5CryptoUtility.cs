/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MD5CryptoUtility.cs
 *  Description  :  Utility for MD5 crypto service provider.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  3/23/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using System;
using System.IO;
using System.Security.Cryptography;

namespace MGS.Common.Crypto
{
    /// <summary>
    /// Utility for MD5 crypto service provider.
    /// </summary>
    public sealed class MD5CryptoUtility
    {
        /// <summary>
        /// Compute hash of byte array.
        /// </summary>
        /// <param name="buffer">Source byte array.</param>
        /// <returns>Hash code.</returns>
        public static string ComputeHash(byte[] buffer)
        {
            if (buffer == null)
            {
                LogUtility.LogError("Compute hash error: The buffer array is null.");
                return null;
            }

            var md5 = new MD5CryptoServiceProvider();
            var hashBytes = md5.ComputeHash(buffer);

            return BitConverter.ToString(hashBytes);
        }

        /// <summary>
        /// Compute hash of string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <returns>Hash code.</returns>
        public static string ComputeHash(string source)
        {
            if (source == null)
            {
                LogUtility.LogError("Compute hash error: The source string is null.");
                return null;
            }

            var sourceBytes = System.Text.Encoding.Default.GetBytes(source);
            return ComputeHash(sourceBytes);
        }

        /// <summary>
        /// Compute hash of file.
        /// </summary>
        /// <param name="filePath">Path of source file.</param>
        /// <returns>Hash code.</returns>
        public static string ComputeFileHash(string filePath)
        {
            if (!File.Exists(filePath))
            {
                LogUtility.LogError("Compute hash error: The source file {0} does not exist.");
                return null;
            }

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var md5 = new MD5CryptoServiceProvider();
                    var hashBytes = md5.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes);
                }
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Compute hash exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}