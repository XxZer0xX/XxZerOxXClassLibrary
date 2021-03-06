﻿using System.Runtime.InteropServices;
using XxZerOxXClassLibrary.IO;
using XxZerOxXClassLibrary.IO.Extern;

namespace XxZerOxXClassLibrary.Imaging
{
    public static class ImageUtilities
    {
        public static System.Drawing.Icon GetRegisteredIcon(string filePath)
        {
            var shinfo = new SHfileInfo();
            Win32.SHGetFileInfo(filePath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }
    }
}
