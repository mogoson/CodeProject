/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ExplorerUtility.cs
 *  Description  :  Utility for windows explorer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/25/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Diagnostics;

namespace MGS.WinCommon.Utility
{
    /// <summary>
    /// Utility for windows explorer.
    /// </summary>
    public sealed class ExplorerUtility
    {
        #region Field and Property
        /// <summary>
        /// Explorer process name.
        /// </summary>
        public const string EXPLORER = "explorer";
        #endregion

        #region Public Method
        /// <summary>
        /// Show target path(or file) in explorer.
        /// </summary>
        /// <param name="path">Target path(or file) to show.</param>
        /// <param name="select">Select path?</param>
        /// <param name="eMode">Show explorer mode?</param>
        public static void Show(string path, bool select = true, bool eMode = true)
        {
            /* Command Prompt
             * Explorer [/n][/e][[,/root],[path]][[,/select],[path filename]]
             */

            var arguments = "/e";
            if (!eMode)
            {
                arguments = "/n";
            }

            if (!string.IsNullOrEmpty(path))
            {
                if (select)
                {
                    arguments += ",/select,";
                }
                else
                {
                    arguments += ",/root,";
                }
                arguments += path.Replace("/", "\\");
            }
            Process.Start(EXPLORER, arguments);
        }
        #endregion
    }
}