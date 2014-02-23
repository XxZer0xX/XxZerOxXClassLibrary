using System;

namespace XxZerOxXClassLibrary
{
    internal sealed class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // large
        public const uint SHGFI_SMALLICON = 0x1; // small

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHfileInfo psfi, uint cbSizeFileInfo, uint uFlags);
    }
}
