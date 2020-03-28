/*************************************************************************
 *  Copyright © 2015-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ArrayConverter.cs
 *  Description  :  Converter of array.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  10/12/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Logger;

namespace MGS.Common.Converter
{
    /// <summary>
    /// Converter of array.
    /// </summary>
    public sealed class ArrayConverter
    {
        #region Public Method
        /// <summary>
        /// Convert one dimention array to two dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <param name="row">Two dimention array's row.</param>
        /// <param name="column">Two dimention array's column.</param>
        /// <returns>Two dimentions array.</returns>
        public static T[,] ToTwoDimention<T>(T[] array, int row, int column)
        {
            if (array == null || array.Length == 0 || row * column != array.Length)
            {
                LogUtility.LogError("Convert one dimention array to two dimentions array error: The param is invalid.");
                return null;
            }

            var twoDArray = new T[row, column];
            var index = 0;
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < column; c++)
                {
                    twoDArray[r, c] = array[index];
                    index++;
                }
            }
            return twoDArray;
        }

        /// <summary>
        /// Convert one dimention array to three dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <param name="layer">Three dimention array's layer.</param>
        /// <param name="row">Three dimention array's row.</param>
        /// <param name="column">Three dimention array's column.</param>
        /// <returns>Three dimentions array.</returns>
        public static T[,,] ToThreeDimention<T>(T[] array, int layer, int row, int column)
        {
            if (array == null || array.Length == 0 || row * column * layer != array.Length)
            {
                LogUtility.LogError("Convert one dimention array to three dimentions array error: The param is invalid.");
                return null;
            }

            var threeDArray = new T[layer, row, column];
            var index = 0;
            for (var l = 0; l < layer; l++)
            {
                for (var r = 0; r < row; r++)
                {
                    for (var c = 0; c < column; c++)
                    {
                        threeDArray[l, r, c] = array[index];
                        index++;
                    }
                }
            }
            return threeDArray;
        }

        /// <summary>
        /// Convert two dimention array to one dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <returns>One dimentions array.</returns>
        public static T[] ToOneDimention<T>(T[,] array)
        {
            if (array == null || array.Length == 0)
            {
                LogUtility.LogError("Convert two dimention array to one dimentions array error: The param is invalid.");
                return null;
            }

            var oneDArray = new T[array.Length];
            var index = 0;
            for (var r = 0; r < array.GetLength(0); r++)
            {
                for (var c = 0; c < array.GetLength(1); c++)
                {
                    oneDArray[index] = array[r, c];
                    index++;
                }
            }
            return oneDArray;
        }

        /// <summary>
        /// Convert three dimention array to one dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <returns>One dimentions array.</returns>
        public static T[] ToOneDimention<T>(T[,,] array)
        {
            if (array == null || array.Length == 0)
            {
                LogUtility.LogError("Convert three dimention array to one dimentions array error: The param is invalid.");
                return null;
            }

            var oneDArray = new T[array.Length];
            var index = 0;
            for (var l = 0; l < array.GetLength(0); l++)
            {
                for (var r = 0; r < array.GetLength(1); r++)
                {
                    for (var c = 0; c < array.GetLength(2); c++)
                    {
                        oneDArray[index] = array[l, r, c];
                        index++;
                    }
                }
            }
            return oneDArray;
        }
        #endregion
    }
}