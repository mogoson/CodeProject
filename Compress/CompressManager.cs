/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CompressManager.cs
 *  Description  :  Compress manager.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  5/30/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using System;
using System.Collections.Generic;

namespace MGS.Compress
{
    /// <summary>
    /// Compress manager.
    /// </summary>
    public class CompressManager : Singleton<CompressManager>, ICompressManager
    {
        public ICompressor Compressor { set; get; }

        public string Compress(string entrie, string desFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        public string Compress(IEnumerable<string> entries, string desFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        public string Decompress(string filePath, string desDir,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }
    }
}