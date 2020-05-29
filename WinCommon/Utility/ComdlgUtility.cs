/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ComdlgUtility.cs
 *  Description  :  Utility for Comdlg32.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/6/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.WinLibrary;
using System.Runtime.InteropServices;

namespace MGS.WinCommon.Utility
{
    /// <summary>
    /// Utility for Comdlg32.
    /// </summary>
    public class ComdlgUtility
    {
        #region Public Method
        /// <summary>
        /// Displays the "open file" dialog and returns the selected path name.
        /// </summary>
        /// <param name="title">Title of dialog.</param>
        /// <param name="directory">Default directory of dialog.</param>
        /// <param name="filter">Filter of dialog; example "Image(*.jpg;*.png)\0*.jpg;*.png".</param>
        /// <returns>The path of selected file.</returns>
        public static string OpenFileDialog(string title, string directory, string filter)
        {
            var ofn = new OpenFileName
            {
                lpstrTitle = title,
                lpstrInitialDir = directory,
                lpstrFilter = filter,
                nMaxFile = 256,
                flags = OFNFlags.OFN_EXPLORER | OFNFlags.OFN_FILEMUSTEXIST | OFNFlags.OFN_PATHMUSTEXIST | OFNFlags.OFN_NOCHANGEDIR
            };
            ofn.lStructSize = Marshal.SizeOf(ofn);

            if (Comdlg32.GetOpenFileName(ofn))
            {
                return ofn.lpstrFile;
            }
            return string.Empty;
        }

        /// <summary>
        /// Displays the "save file" dialog and returns the selected path name.
        /// </summary>
        /// <param name="title">Title of dialog.</param>
        /// <param name="directory">Default directory of dialog.</param>
        /// <param name="defaultName">Default name of save file.</param>
        /// <param name="filter">Filter of dialog; example: "Text(*.txt)\0*.txt".</param>
        /// <returns>The path of save file.</returns>
        public static string SaveFileDialog(string title, string directory, string defaultName, string filter)
        {
            var ofn = new OpenFileName
            {
                lpstrTitle = title,
                lpstrInitialDir = directory,
                lpstrFile = defaultName,
                lpstrFilter = filter,
                nMaxFile = 256,
                flags = OFNFlags.OFN_EXPLORER | OFNFlags.OFN_PATHMUSTEXIST | OFNFlags.OFN_NOCHANGEDIR
            };
            ofn.lStructSize = Marshal.SizeOf(ofn);

            if (Comdlg32.GetSaveFileName(ofn))
            {
                return ofn.lpstrFile;
            }
            return string.Empty;
        }

        /// <summary>
        /// Displays the "open folder" dialog and returns the selected path name.
        /// </summary>
        /// <param name="title">Title of dialog.</param>
        /// <returns>The path of selected folder.</returns>
        public static string OpenFolderDialog(string title)
        {
            var lpbi = new BrowseInfo
            {
                lpszTitle = title,
                ulFlags = BIFlags.BIF_RETURNONLYFSDIRS
            };

            var pidl = Shell32.SHBrowseForFolder(lpbi);
            var pszPath = new char[256];
            if (Shell32.SHGetPathFromIDList(pidl, pszPath))
            {
                var fdrPath = new string(pszPath);
                return fdrPath.Substring(0, fdrPath.IndexOf('\0'));
            }
            return string.Empty;
        }
        #endregion
    }
}