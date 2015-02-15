using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace ExtendedExplorer {
    /* This class is to wrap the Shell API function related to icon.
     * It follows wrapper facade pattern (POSA patterns volume 2),
     * which hide the complexity of API calls and group functions with 
     * the same purpose into a same class.
     */
    sealed class IconReader {

        #region constants
        const int MAX_PATH = 256;
        const int NAMESIZE = 80;

        const uint SHGFI_ICON = 0x100;				// get icon handle & index. Get image list handle from SHFILEINFO.hIcon, index from SHFILEINFO.iIcon.
        const uint SHGFI_SMALLICON = 0x1;			// get small icon (SHGFI_ICON and/or SHGFI_SYSICONINDEX flag must be set)
        const uint SHGFI_USEFILEATTRIBUTES = 0x10;	// pszPath is not a real file. Use information in SHFILEINFO.dwFileAttribute
        const uint FILE_ATTRIBUTE_ARCHIVE = 0x20;
        const uint FILE_ATTRIBUTE_COMPRESSED = 0x800;
        const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        const uint FILE_ATTRIBUTE_HIDDEN = 0x2;
        const uint FILE_ATTRIBUTE_NORMAL = 0x0;
        const uint FILE_ATTRIBUTE_READONLY = 0x1;
        const uint FILE_ATTRIBUTE_SYSTEM = 0x4;
        #endregion

        #region DLL-imports
        // The exact structure needed to call shell API function
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        // The shell API function for retrieving file information
        [DllImport("Shell32.dll", EntryPoint = "SHGetFileInfo", CharSet = CharSet.Ansi)]
        private static extern IntPtr SHGetFileInfo(string pszPath,
          uint dwFileAttributes,
          ref SHFILEINFO psfi,
          uint cbFileInfo,
          uint uFlags);

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
        #endregion

        #region Fields/properties
        // The only way to access SystemIcons object is through static Instance
        // property. This creates singleton pattern
        private static readonly IconReader instance = new IconReader();
        public static IconReader Instance {
            get {
                return instance;
            }
        }
        #endregion

        public IconReader() { }

        // Get the shell icon that represents a file type. The file type is distinguished by the parameter fileExtension;
        public Icon getSmallFileTypeIcon(string pFileExtension) {
            SHFILEINFO psfi = new SHFILEINFO();
            uint uFlags = SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES;

            uint fileAttribute = FILE_ATTRIBUTE_ARCHIVE
                      | FILE_ATTRIBUTE_COMPRESSED
                      | FILE_ATTRIBUTE_HIDDEN
                      | FILE_ATTRIBUTE_NORMAL
                      | FILE_ATTRIBUTE_READONLY
                      | FILE_ATTRIBUTE_SYSTEM;

            SHGetFileInfo(pFileExtension, fileAttribute, ref psfi,
              (uint)Marshal.SizeOf(psfi), uFlags);

            Icon icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            DestroyIcon(psfi.hIcon);
            return icon;
        }

        // Get the shell icon that represents a closed folder
        public Icon getClosedFolderIcon() {
            SHFILEINFO psfi = new SHFILEINFO();
            uint uFlags = SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES;

            SHGetFileInfo("", FILE_ATTRIBUTE_DIRECTORY, ref psfi,
              (uint)Marshal.SizeOf(psfi), uFlags);

            Icon icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
            DestroyIcon(psfi.hIcon);
            return icon;
        }
    }
}