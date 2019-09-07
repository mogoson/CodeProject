/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Comdlg32.cs
 *  Description  :  API of Comdlg32 dll.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace MGS.WinLibrary
{
    /// <summary>
    /// API of Comdlg32 dll.
    /// </summary>
    public static class Comdlg32
    {
        /// <summary>
        /// Creates an Open dialog box that lets the user specify the drive, directory, and the name of a
        /// file or set of files to be opened.
        /// </summary>
        /// <param name="ofn">A pointer to an OPENFILENAME structure that contains information used to
        /// initialize the dialog box. When GetOpenFileName returns, this structure contains information
        /// about the user's file selection.</param>
        /// <returns>If the user specifies a file name and clicks the OK button, the return value is nonzero.</returns>
        #region Method
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern Boolean GetOpenFileName([In, Out] OpenFileName ofn);

        /// <summary>
        /// Creates a Save dialog box that lets the user specify the drive, directory, and name of a file to save.
        /// </summary>
        /// <param name="ofn">A pointer to an OPENFILENAME structure that contains information used to
        /// initialize the dialog box. When GetSaveFileName returns, this structure contains information
        /// about the user's file selection.</param>
        /// <returns>If the user specifies a file name and clicks the OK button and the function is
        /// successful, the return value is nonzero.</returns>
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern Boolean GetSaveFileName([In, Out] OpenFileName ofn);
        #endregion
    }

    /// <summary>
    /// Contains information that the GetOpenFileName and GetSaveFileName functions use to initialize an
    /// Open or Save As dialog box. After the user closes the dialog box, the system returns information
    /// about the user's selection in this structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        /// <summary>
        /// The length, in bytes, of the structure. Use sizeof (OPENFILENAME) for this parameter.
        /// </summary>
        public Int32 lStructSize = 0;

        /// <summary>
        /// A handle to the window that owns the dialog box. This member can be any valid window handle,
        /// or it can be NULL if the dialog box has no owner.
        /// </summary>
        public IntPtr hwndOwner = IntPtr.Zero;

        /// <summary>
        /// If the OFN_ENABLETEMPLATEHANDLE flag is set in the Flags member, hInstance is a handle to a
        /// memory object containing a dialog box template.
        /// </summary>
        public IntPtr hInstance = IntPtr.Zero;

        /// <summary>
        /// A buffer containing pairs of null-terminated filter strings. The last string in the buffer
        /// must be terminated by two NULL characters.
        /// </summary>
        public String lpstrFilter = String.Empty;

        /// <summary>
        /// A static buffer that contains a pair of null-terminated filter strings for preserving the
        /// filter pattern chosen by the user. 
        /// </summary>
        public String lpstrCustomFilter = String.Empty;

        /// <summary>
        /// The size, in characters, of the buffer identified by lpstrCustomFilter. This buffer should
        /// be at least 40 characters long. This member is ignored if lpstrCustomFilter is NULL or
        /// points to a NULL string.
        /// </summary>
        public Int32 nMaxCustFilter = 0;

        /// <summary>
        /// The index of the currently selected filter in the File Types control. The buffer pointed
        /// to by lpstrFilter contains pairs of strings that define the filters.
        /// </summary>
        public Int32 nFilterIndex = 0;

        /// <summary>
        /// The file name used to initialize the File Name edit control. The first character of this
        /// buffer must be NULL if initialization is not necessary. 
        /// </summary>
        public String lpstrFile = String.Empty;

        /// <summary>
        /// The size, in characters, of the buffer pointed to by lpstrFile. The buffer must be large enough
        /// to store the path and file name string or strings, including the terminating NULL character.
        /// </summary>
        public Int32 nMaxFile = 0;

        /// <summary>
        /// The file name and extension (without path information) of the selected file. This member can be NULL.
        /// </summary>
        public String lpstrFileTitle = String.Empty;

        /// <summary>
        /// The size, in characters, of the buffer pointed to by lpstrFileTitle. This member is ignored if lpstrFileTitle is NULL.
        /// </summary>
        public Int32 nMaxFileTitle = 0;

        /// <summary>
        /// The initial directory. The algorithm for selecting the initial directory varies on different platforms.
        /// </summary>
        public String lpstrInitialDir = String.Empty;

        /// <summary>
        /// A string to be placed in the title bar of the dialog box. If this member is NULL, the system uses the
        /// default title (that is, Save As or Open).
        /// </summary>
        public String lpstrTitle = String.Empty;

        /// <summary>
        /// A set of bit flags you can use to initialize the dialog box. When the dialog box returns, it sets these
        /// flags to indicate the user's input. This member can be a combination of the following flags.
        /// </summary>
        public UInt32 flags = 0;

        /// <summary>
        /// The zero-based offset, in characters, from the beginning of the path to the file name in the string
        /// pointed to by lpstrFile. For the ANSI version, this is the number of bytes; for the Unicode version,
        /// this is the number of characters.
        /// </summary>
        public Int16 nFileOffset = 0;

        /// <summary>
        /// The zero-based offset, in characters, from the beginning of the path to the file name extension in
        /// the string pointed to by lpstrFile. For the ANSI version, this is the number of bytes; for the Unicode
        /// version, this is the number of characters.
        /// </summary>
        public Int16 nFileExtension = 0;

        /// <summary>
        /// The default extension. GetOpenFileName and GetSaveFileName append this extension to the file name if
        /// the user fails to type an extension. This string can be any length, but only the first three characters
        /// are appended. The string should not contain a period (.). If this member is NULL and the user fails to
        /// type an extension, no extension is appended.
        /// </summary>
        public String lpstrDefExt = String.Empty;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the lpfnHook member.
        /// </summary>
        public IntPtr lCustData = IntPtr.Zero;

        /// <summary>
        /// A pointer to a hook procedure. This member is ignored unless the Flags member includes the OFN_ENABLEHOOK flag.
        /// </summary>
        public IntPtr lpfnHook = IntPtr.Zero;

        /// <summary>
        /// The name of the dialog template resource in the module identified by the hInstance member. For numbered dialog
        /// box resources, this can be a value returned by the MAKEINTRESOURCE macro. This member is ignored unless the
        /// OFN_ENABLETEMPLATE flag is set in the Flags member.
        /// </summary>
        public String lpTemplateName = String.Empty;

        /*
        /// <summary>
        /// This member is reserved.
        /// </summary>
        public IntPtr lpEditInfo = IntPtr.Zero;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public String lpstrPrompt = String.Empty;
        */

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public IntPtr pvReserved = IntPtr.Zero;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public Int32 dwReserved = 0;

        /// <summary>
        /// A set of bit flags you can use to initialize the dialog box. Currently, this member can be zero or the following flag:
        /// OFN_EX_NOPLACESBAR.
        /// </summary>
        public UInt32 flagsEx = 0;
    }

    /// <summary>
    /// A set of bit flags you can use to initialize the dialog box.
    /// </summary>
    public static class OFNFlags
    {
        /// <summary>
        /// The File Name list box allows multiple selections. If you also set the OFN_EXPLORER flag, the
        /// dialog box uses the Explorer-style user interface; otherwise, it uses the old-style user interface. 
        /// </summary>
        public const UInt32 OFN_ALLOWMULTISELECT = 0x00000200;

        /// <summary>
        /// If the user specifies a file that does not exist, this flag causes the dialog box to prompt the
        /// user for permission to create the file. 
        /// </summary>
        public const UInt32 OFN_CREATEPROMPT = 0x00002000;

        /// <summary>
        /// Prevents the system from adding a link to the selected file in the file system directory that
        /// contains the user's most recently used documents. 
        /// </summary>
        public const UInt32 OFN_DONTADDTORECENT = 0x02000000;

        /// <summary>
        /// Enables the hook function specified in the lpfnHook member.
        /// </summary>
        public const UInt32 OFN_ENABLEHOOK = 0x00000020;

        /// <summary>
        /// Causes the dialog box to send CDN_INCLUDEITEM notification messages to your OFNHookProc hook
        /// procedure when the user opens a folder. 
        /// </summary>
        public const UInt32 OFN_ENABLEINCLUDENOTIFY = 0x00400000;

        /// <summary>
        /// Enables the Explorer-style dialog box to be resized using either the mouse or the keyboard.
        /// </summary>
        public const UInt32 OFN_ENABLESIZING = 0x00800000;

        /// <summary>
        /// The lpTemplateName member is a pointer to the name of a dialog template resource in the module
        /// identified by the hInstance member.
        /// </summary>
        public const UInt32 OFN_ENABLETEMPLATE = 0x00000040;

        /// <summary>
        /// The hInstance member identifies a data block that contains a preloaded dialog box template.
        /// </summary>
        public const UInt32 OFN_ENABLETEMPLATEHANDLE = 0x00000080;

        /// <summary>
        /// Indicates that any customizations made to the Open or Save As dialog box use the Explorer-style
        /// customization methods.
        /// </summary>
        public const UInt32 OFN_EXPLORER = 0x00080000;

        /// <summary>
        /// The user typed a file name extension that differs from the extension specified by lpstrDefExt.
        /// </summary>
        public const UInt32 OFN_EXTENSIONDIFFERENT = 0x00000400;

        /// <summary>
        /// The user can type only names of existing files in the File Name entry field.
        /// </summary>
        public const UInt32 OFN_FILEMUSTEXIST = 0x00001000;

        /// <summary>
        /// Forces the showing of system and hidden files, thus overriding the user setting to show or not show
        /// hidden files.
        /// </summary>
        public const UInt32 OFN_FORCESHOWHIDDEN = 0x10000000;

        /// <summary>
        /// Hides the Read Only check box.
        /// </summary>
        public const UInt32 OFN_HIDEREADONLY = 0x00000004;

        /// <summary>
        /// For old-style dialog boxes, this flag causes the dialog box to use long file names.
        /// </summary>
        public const UInt32 OFN_LONGNAMES = 0x00200000;

        /// <summary>
        /// Restores the current directory to its original value if the user changed the directory while searching for files.
        /// </summary>
        public const UInt32 OFN_NOCHANGEDIR = 0x00000008;

        /// <summary>
        /// Directs the dialog box to return the path and file name of the selected shortcut (.LNK) file.
        /// </summary>
        public const UInt32 OFN_NODEREFERENCELINKS = 0x00100000;

        /// <summary>
        /// For old-style dialog boxes, this flag causes the dialog box to use short file names (8.3 format).
        /// </summary>
        public const UInt32 OFN_NOLONGNAMES = 0x00040000;

        /// <summary>
        /// Hides and disables the Network button.
        /// </summary>
        public const UInt32 OFN_NONETWORKBUTTON = 0x00020000;

        /// <summary>
        /// The returned file does not have the Read Only check box selected and is not in a write-protected directory.
        /// </summary>
        public const UInt32 OFN_NOREADONLYRETURN = 0x00008000;

        /// <summary>
        /// The file is not created before the dialog box is closed. This flag should be specified if the application
        /// saves the file on a create-nonmodify network share.
        /// </summary>
        public const UInt32 OFN_NOTESTFILECREATE = 0x00010000;

        /// <summary>
        /// The common dialog boxes allow invalid characters in the returned file name.
        /// </summary>
        public const UInt32 OFN_NOVALIDATE = 0x00000100;

        /// <summary>
        /// Causes the Save As dialog box to generate a message box if the selected file already exists.
        /// </summary>
        public const UInt32 OFN_OVERWRITEPROMPT = 0x00000002;

        /// <summary>
        /// The user can type only valid paths and file names. If this flag is used and the user
        /// types an invalid path and file name in the File Name entry field, the dialog box
        /// function displays a warning in a message box. 
        /// </summary>
        public const UInt32 OFN_PATHMUSTEXIST = 0x00000800;

        /// <summary>
        /// Causes the Read Only check box to be selected initially when the dialog box is created.
        /// </summary>
        public const UInt32 OFN_READONLY = 0x00000001;

        /// <summary>
        /// Specifies that if a call to the OpenFile function fails because of a network sharing
        /// violation, the error is ignored and the dialog box returns the selected file name.
        /// </summary>
        public const UInt32 OFN_SHAREAWARE = 0x00004000;

        /// <summary>
        /// Causes the dialog box to display the Help button. The hwndOwner member must specify the
        /// window to receive the HELPMSGSTRING registered messages that the dialog box sends when
        /// the user clicks the Help button.
        /// </summary>
        public const UInt32 OFN_SHOWHELP = 0x00000010;
    }

    /// <summary>
    /// A set of bit flags you can use to initialize the dialog box.
    /// </summary>
    public static class OFNFlagsEx
    {
        /// <summary>
        /// If this flag is set, the places bar is not displayed. If this flag is not set, Explorer-style dialog
        /// boxes include a places bar containing icons for commonly-used folders, such as Favorites and Desktop. 
        /// </summary>
        public const UInt32 OFN_EX_NOPLACESBAR = 0x00000001;
    }
}