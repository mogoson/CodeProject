/*************************************************************************
 *  Copyright (c) 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Shell32.cs
 *  Description  :  API of Shell32 dll.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace MGS.WinLibrary
{
    /// <summary>
    /// API of Shell32 dll.
    /// </summary>
    public sealed class Shell32
    {
        #region Method
        /// <summary>
        /// Displays a dialog box that enables the user to select a Shell folder.
        /// </summary>
        /// <param name="lpbi">A pointer to a BROWSEINFO structure that contains information used to display the dialog box.</param>
        /// <returns>Returns a PIDL that specifies the location of the selected folder relative to the root of the namespace.
        /// If the user chooses the Cancel button in the dialog box, the return value is NULL.</returns>
        [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SHBrowseForFolder([In, Out] BrowseInfo lpbi);

        /// <summary>
        /// Converts an item identifier list to a file system path.
        /// </summary>
        /// <param name="pidl">The address of an item identifier list that specifies a file or directory location relative to
        /// the root of the namespace (the desktop).</param>
        /// <param name="pszPath">The address of a buffer to receive the file system path. This buffer must be at least
        /// MAX_PATH characters in size.</param>
        /// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
        [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern Boolean SHGetPathFromIDList([In] IntPtr pidl, [In, Out] Char[] pszPath);
        #endregion
    }

    /// <summary>
    /// Contains parameters for the SHBrowseForFolder function and receives information about the folder selected by the user.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class BrowseInfo
    {
        /// <summary>
        /// A handle to the owner window for the dialog box.
        /// </summary>
        public IntPtr hwndOwner = IntPtr.Zero;

        /// <summary>
        /// A PIDL that specifies the location of the root folder from which to start browsing. Only the specified folder
        /// and its subfolders in the namespace hierarchy appear in the dialog box. This member can be NULL;
        /// in that case, a default location is used.
        /// </summary>
        public IntPtr pidlRoot = IntPtr.Zero;

        /// <summary>
        /// Pointer to a buffer to receive the display name of the folder selected by the user.
        /// The size of this buffer is assumed to be MAX_PATH characters.
        /// </summary>
        public String pszDisplayName = String.Empty;

        /// <summary>
        /// Pointer to a null-terminated string that is displayed above the tree view control in the dialog box.
        /// This string can be used to specify instructions to the user.
        /// </summary>
        public String lpszTitle = String.Empty;

        /// <summary>
        /// Flags that specify the options for the dialog box.
        /// </summary>
        public UInt32 ulFlags = 0;

        /// <summary>
        /// Pointer to an application-defined function that the dialog box calls when an event occurs.
        /// </summary>
        public IntPtr lpfn = IntPtr.Zero;

        /// <summary>
        /// An application-defined value that the dialog box passes to the callback function, if one is specified in lpfn.
        /// </summary>
        public IntPtr lParam = IntPtr.Zero;

        /// <summary>
        /// An integer value that receives the index of the image associated with the selected folder, stored in the system image list.
        /// </summary>
        public Int32 iImage = 0;
    }

    /// <summary>
    /// Flags that specify the options for the dialog box.
    /// </summary>
    public sealed class BIFlags
    {
        /// <summary>
        /// Only return file system directories. If the user selects folders 
        /// that are not part of the file system, the OK button is grayed.
        /// </summary>
        public const UInt32 BIF_RETURNONLYFSDIRS = 0x00000001;

        /// <summary>
        /// Do not include network folders below the domain level in the dialog box's tree view control.
        /// </summary>
        public const UInt32 BIF_DONTGOBELOWDOMAIN = 0x00000002;

        /// <summary>
        /// Include a status area in the dialog box. The callback function can set the status text by
        /// sending messages to the dialog box. This flag is not supported when BIF_NEWDIALOGSTYLE is specified.
        /// </summary>
        public const UInt32 BIF_STATUSTEXT = 0x00000004;

        /// <summary>
        /// Only return file system ancestors. An ancestor is a subfolder that is beneath the root folder
        /// in the namespace hierarchy. If the user selects an ancestor of the root folder that is not part
        /// of the file system, the OK button is grayed.
        /// </summary>
        public const UInt32 BIF_RETURNFSANCESTORS = 0x00000008;

        /// <summary>
        /// When combined with BIF_NEWDIALOGSTYLE, adds a usage hint to the dialog box, in place of the
        /// edit box. BIF_EDITBOX overrides this flag.
        /// </summary>
        public const UInt32 BIF_UAHINT = 0x00000100;

        /// <summary>
        /// Do not include the New Folder button in the browse dialog box.
        /// </summary>
        public const UInt32 BIF_NONEWFOLDERBUTTON = 0x00000200;

        /// <summary>
        /// When the selected item is a shortcut, return the PIDL of the shortcut itself rather than its target.
        /// </summary>
        public const UInt32 BIF_NOTRANSLATETARGETS = 0x00000400;

        /// <summary>
        /// Only return computers. If the user selects anything other than a computer, the OK button is grayed.
        /// </summary>
        public const UInt32 BIF_BROWSEFORCOMPUTER = 0x00001000;

        /// <summary>
        /// Only allow the selection of printers. If the user selects anything other than a printer, the OK button is grayed.
        /// </summary>
        public const UInt32 BIF_BROWSEFORPRINTER = 0x00002000;

        /// <summary>
        /// The browse dialog box displays files as well as folders.
        /// </summary>
        public const UInt32 BIF_BROWSEINCLUDEFILES = 0x00004000;

        /// <summary>
        /// The browse dialog box can display sharable resources on remote systems.
        /// This is intended for applications that want to expose remote shares on a local system. 
        /// </summary>
        public const UInt32 BIF_SHAREABLE = 0x00008000;

        /// <summary>
        /// Windows 7 and later. Allow folder junctions such as a library or a compressed file with a
        /// .zip file name extension to be browsed.
        /// </summary>
        public const UInt32 BIF_BROWSEFILEJUNCTIONS = 0x00010000;
    }
}