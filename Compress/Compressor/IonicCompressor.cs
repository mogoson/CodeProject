/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IonicCompressor.cs
 *  Description  :  Ionic compressor.
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
    public class IonicCompressor : ICompressor
    {
        public void Compress(string entrie, string desFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        public void Compress(IEnumerable<string> entries, string desFile,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }

        public void Decompress(string filePath, string desDir,
            Action<float> progressCallback = null,
            Action<string> completeCallback = null,
            Action<string> errorCallback = null)
        {
            throw new NotImplementedException();
        }
    }
}