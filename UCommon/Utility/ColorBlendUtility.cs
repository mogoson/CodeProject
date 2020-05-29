/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ColorBlendUtility.cs
 *  Description  :  Utility for color blend.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UCommon.Generic;
using UnityEngine;

namespace MGS.UCommon.Utility
{
    /// <summary>
    /// Utility for color blend.
    /// </summary>
    public sealed class ColorBlendUtility
    {
        /// <summary>
        /// Blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <param name="mode">Mode of color blend.</param>
        /// <returns>Blended color.</returns>
        public static Color Blend(Color a, Color b, ColorBlendMode mode)
        {
            var c = Color.white;
            switch (mode)
            {
                case ColorBlendMode.Normal:
                    c = NormalBlend(a, b);
                    break;

                case ColorBlendMode.Dissolve:
                    c = DissolveBlend(a, b);
                    break;

                case ColorBlendMode.Darken:
                    c = DarkenBlend(a, b);
                    break;

                case ColorBlendMode.Multiply:
                    c = MultiplyBlend(a, b);
                    break;

                case ColorBlendMode.ColorBurn:
                    c = ColorBurnBlend(a, b);
                    break;

                case ColorBlendMode.LinearBurn:
                    c = LinearBurnBlend(a, b);
                    break;

                case ColorBlendMode.DarkerColor:
                    c = DarkerColorBlend(a, b);
                    break;

                case ColorBlendMode.Lighten:
                    c = LightenBlend(a, b);
                    break;

                case ColorBlendMode.Screen:
                    c = ScreenBlend(a, b);
                    break;

                case ColorBlendMode.ColorDodge:
                    c = ColorDodgeBlend(a, b);
                    break;

                case ColorBlendMode.LinearDodge:
                    c = LinearDodgeBlend(a, b);
                    break;

                case ColorBlendMode.LighterColor:
                    c = LighterColorBlend(a, b);
                    break;

                case ColorBlendMode.Overlay:
                    c = OverlayBlend(a, b);
                    break;

                case ColorBlendMode.SoftLight:
                    c = SoftLightBlend(a, b);
                    break;

                case ColorBlendMode.HardLight:
                    c = HardLightBlend(a, b);
                    break;

                case ColorBlendMode.VividLight:
                    c = VividLightBlend(a, b);
                    break;

                case ColorBlendMode.LinearLight:
                    c = LinearLightBlend(a, b);
                    break;

                case ColorBlendMode.PinLight:
                    c = PinLightBlend(a, b);
                    break;

                case ColorBlendMode.HardMix:
                    c = HardMixBlend(a, b);
                    break;

                case ColorBlendMode.Difference:
                    c = DifferenceBlend(a, b);
                    break;

                case ColorBlendMode.Exclusion:
                    c = ExclusionBlend(a, b);
                    break;

                case ColorBlendMode.Subtract:
                    c = SubtractBlend(a, b);
                    break;

                case ColorBlendMode.Divide:
                    c = DivideBlend(a, b);
                    break;

                case ColorBlendMode.Hue:
                    c = HueBlend(a, b);
                    break;

                case ColorBlendMode.Color:
                    c = ColorBlend(a, b);
                    break;

                case ColorBlendMode.Saturation:
                    c = SaturationBlend(a, b);
                    break;

                case ColorBlendMode.Luminosity:
                    c = LuminosityBlend(a, b);
                    break;
            }
            return c;
        }

        /// <summary>
        /// Normal mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color NormalBlend(Color a, Color b)
        {
            return b * b.a + a * (1 - b.a);
        }

        /// <summary>
        /// Dissolve mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color DissolveBlend(Color a, Color b)
        {
            return Random.Range(0, 1) == 0 ? a : b;
        }

        /// <summary>
        /// Darken mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color DarkenBlend(Color a, Color b)
        {
            var mA = ((Vector4)a).magnitude;
            var mB = ((Vector4)b).magnitude;
            return Mathf.Min(mA, mB) == mA ? a : b;
        }

        /// <summary>
        /// Multiply mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color MultiplyBlend(Color a, Color b)
        {
            return a * b;
        }

        /// <summary>
        /// ColorBurn mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color ColorBurnBlend(Color a, Color b)
        {
            var re = Color.white - a;
            var qu = new Color(re.r / b.r, re.g / b.g, re.b / b.b, re.a / b.a);
            return Color.white - qu;
        }

        /// <summary>
        /// LinearBurn vblend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LinearBurnBlend(Color a, Color b)
        {
            return a + b - Color.white;
        }

        /// <summary>
        /// DarkerColor mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color DarkerColorBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Lighten mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LightenBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Screen mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color ScreenBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// ColorDodge mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color ColorDodgeBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// LinearDodge mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LinearDodgeBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// LighterColor mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LighterColorBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Overlay mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color OverlayBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// SoftLight mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color SoftLightBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// HardLight mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color HardLightBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// VividLight mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color VividLightBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// LinearLight mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LinearLightBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// PinLight mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color PinLightBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// HardMix mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color HardMixBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Difference mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color DifferenceBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Exclusion mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color ExclusionBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Subtract mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color SubtractBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Divide mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color DivideBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Hue mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color HueBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Component-Color mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color ColorBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Saturation mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color SaturationBlend(Color a, Color b)
        {
            return Color.red;
        }

        /// <summary>
        /// Luminosity mode blend color a and color b.
        /// </summary>
        /// <param name="a">Color a.</param>
        /// <param name="b">Color b.</param>
        /// <returns>Blended color.</returns>
        public static Color LuminosityBlend(Color a, Color b)
        {
            return Color.red;
        }
    }
}