/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICompressManager.cs
 *  Description  :  Interface for compress manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Interface for compress manager.
    /// </summary>
    public interface ICompressManager
    {
        /// <summary>
        /// Compressor for manager.
        /// </summary>
        ICompressor Compressor { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entrie"></param>
        /// <param name="desFile"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        /// <param name="errorCallback"></param>
        /// <returns></returns>
        string Compress(string entrie, string desFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entries"></param>
        /// <param name="desFile"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        /// <param name="errorCallback"></param>
        /// <returns></returns>
        string Compress(IEnumerable<string> entries, string desFile,
               Action<float> progressCallback = null,
               Action<string> completeCallback = null,
               Action<string> errorCallback = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="desDir"></param>
        /// <param name="progressCallback"></param>
        /// <param name="completeCallback"></param>
        /// <param name="errorCallback"></param>
        /// <returns></returns>
        string Decompress(string filePath, string desDir,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null);
    }
}