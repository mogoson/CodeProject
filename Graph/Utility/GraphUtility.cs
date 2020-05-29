/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GraphUtility.cs
 *  Description  :  Utility for graph.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/19/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;
using MGS.UCommon.DesignPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;

namespace MGS.Graph
{
    /// <summary>
    /// Utility for graph.
    /// </summary>
    public sealed class GraphUtility
    {
        #region Public Method
        /// <summary>
        /// Load gif from local file async(Coroutine).
        /// </summary>
        /// <param name="filePath">Path of gif file.</param>
        /// <param name="progressCallback">On loading callback.</param>
        /// <param name="completeCallback">On loaded callback.</param>
        /// <param name="errorCallback">On error callback.</param>
        public static void LoadGifFromFileAsycn(string filePath,
            Action<float, Texture2D> progressCallback = null,
            Action<List<Texture2D>> completeCallback = null,
            Action<string> errorCallback = null)
        {
            SingleBehaviour.Instance.StartCoroutine(LoadGifFromFile(filePath, progressCallback, completeCallback, errorCallback));
        }

        /// <summary>
        /// Load gif from local file.
        /// </summary>
        /// <param name="filePath">Path of gif file.</param>
        /// <param name="progressCallback">On loading callback.</param>
        /// <param name="completeCallback">On loaded callback.</param>
        /// <param name="errorCallback">On error callback.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator LoadGifFromFile(string filePath,
            Action<float, Texture2D> progressCallback = null,
            Action<List<Texture2D>> completeCallback = null,
            Action<string> errorCallback = null)
        {
            if (!File.Exists(filePath))
            {
                var error = string.Format("Load gif error: The source file can not find in the path {0}", filePath);
                errorCallback?.Invoke(error);
                yield break;
            }

            Image gif = null;
            try
            {
                gif = Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                var error = string.Format("Load gif exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
                errorCallback?.Invoke(error);
                yield break;
            }

            var dimension = new FrameDimension(gif.FrameDimensionsList[0]);
            var framesCount = gif.GetFrameCount(dimension);

            var frames = new List<Texture2D>();
            for (int i = 0; i < framesCount; i++)
            {
                var bitmap = new Bitmap(gif.Width, gif.Height);
                var graphics = System.Drawing.Graphics.FromImage(bitmap);

                gif.SelectActiveFrame(dimension, i);
                graphics.DrawImage(gif, Point.Empty);

                var frame = new Texture2D(bitmap.Width, bitmap.Height);
                frame.LoadImage(GetBitmapData(bitmap));
                frame.Apply();
                frames.Add(frame);

                var progress = (float)(i + 1) / framesCount;
                progressCallback?.Invoke(progress, frame);
                yield return null;
            }
            completeCallback?.Invoke(frames);
        }

        /// <summary>
        /// Get bytes data of bitmap.
        /// </summary>
        /// <param name="bitmap">Bitmap source.</param>
        /// <returns>Bytes data of bitmap.</returns>
        public static byte[] GetBitmapData(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                LogUtility.LogError("Get bytes data of bitmap error: The bitmap can not be null.");
                return null;
            }

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.GetBuffer();
            }
        }
        #endregion
    }
}