/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ColorBlendMode.cs
 *  Description  :  Mode of color blend.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UCommon.Generic
{
    /// <summary>
    /// Mode of color blend.
    /// </summary>
    public enum ColorBlendMode
    {
        #region Normal
        /// <summary>
        /// Normal-Normal Mode.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Normal-Dissolve Mode.
        /// </summary>
        Dissolve = 1,
        #endregion

        #region Darken
        /// <summary>
        /// Darken-Darken Mode.
        /// </summary>
        Darken = 2,

        /// <summary>
        /// Darken-Multiply Mode.
        /// </summary>
        Multiply = 3,

        /// <summary>
        /// Darken-ColorBurn Mode.
        /// </summary>
        ColorBurn = 4,

        /// <summary>
        /// Darken-LinearBurn Mode.
        /// </summary>
        LinearBurn = 5,

        /// <summary>
        /// Darken-DarkerColor Mode.
        /// </summary>
        DarkerColor = 6,
        #endregion

        #region Lighten
        /// <summary>
        /// Lighten-Lighten Mode.
        /// </summary>
        Lighten = 7,

        /// <summary>
        /// Lighten-Screen Mode.
        /// </summary>
        Screen = 8,

        /// <summary>
        /// Lighten-ColorDodge Mode.
        /// </summary>
        ColorDodge = 9,

        /// <summary>
        /// Lighten-LinearDodge Mode.
        /// </summary>
        LinearDodge = 10,

        /// <summary>
        /// Lighten-LighterColor Mode.
        /// </summary>
        LighterColor = 11,
        #endregion

        #region Contrast
        /// <summary>
        /// Contrast-Overlay Mode.
        /// </summary>
        Overlay = 12,

        /// <summary>
        /// Contrast-SoftLight Mode.
        /// </summary>
        SoftLight = 13,

        /// <summary>
        /// Contrast-HardLight Mode.
        /// </summary>
        HardLight = 14,

        /// <summary>
        /// Contrast-VividLight Mode.
        /// </summary>
        VividLight = 15,

        /// <summary>
        /// Contrast-LinearLight Mode.
        /// </summary>
        LinearLight = 16,

        /// <summary>
        /// Contrast-PinLight Mode.
        /// </summary>
        PinLight = 17,

        /// <summary>
        /// Contrast-HardMix Mode.
        /// </summary>
        HardMix = 18,
        #endregion

        #region Cancelation
        /// <summary>
        /// Cancelation-Difference Mode.
        /// </summary>
        Difference = 19,

        /// <summary>
        /// Cancelation-Exclusion Mode.
        /// </summary>
        Exclusion = 20,

        /// <summary>
        /// Cancelation-Subtract Mode.
        /// </summary>
        Subtract = 21,

        /// <summary>
        /// Cancelation-Divide Mode.
        /// </summary>
        Divide = 22,
        #endregion

        #region Component
        /// <summary>
        /// Component-Hue Mode.
        /// </summary>
        Hue = 23,

        /// <summary>
        /// Component-Color Mode.
        /// </summary>
        Color = 24,

        /// <summary>
        /// Component-Saturation Mode.
        /// </summary>
        Saturation = 25,

        /// <summary>
        /// Component-Luminosity Mode.
        /// </summary>
        Luminosity = 26
        #endregion
    }
}