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
        /// Asynchronous load gif as frames textures.
        /// </summary>
        /// <param name="filePath">Path of gif file.</param>
        /// <param name="progressCallback">On loading callback.</param>
        /// <param name="completeCallback">On loaded callback.</param>
        public static void AsyncLoadGifAsFrames(string filePath, Action<float, Texture2D> progressCallback, Action<List<Texture2D>> completeCallback)
        {
            SingleBehaviour.Instance.StartCoroutine(AsyncLoadGifFromFile(filePath, progressCallback, completeCallback));
        }

        /// <summary>
        /// Asynchronous load gif from local file.
        /// </summary>
        /// <param name="filePath">Path of gif file.</param>
        /// <param name="progressCallback">On loading callback.</param>
        /// <param name="completeCallback">On loaded callback.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator AsyncLoadGifFromFile(string filePath, Action<float, Texture2D> progressCallback, Action<List<Texture2D>> completeCallback)
        {
            if (progressCallback == null && completeCallback == null)
            {
                LogUtility.LogWarning("Asynchronous load gif cancelled: All the callbacks is null.");
                yield break;
            }

            yield return null;
            Image gif = null;
            try
            {
                gif = Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                LogUtility.LogError("Asynchronous load gif error: {0}", ex.Message);
                progressCallback?.Invoke(1.0f, null);
                completeCallback?.Invoke(null);
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