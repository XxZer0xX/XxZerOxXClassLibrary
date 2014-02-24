﻿using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XxZerOxXClassLibrary.AutoCad
{
    public static class ComAccess
    {
        public static AcadApplication GetAcadApplication(string autocadExePath)
        {
            AcadApplication AcApp = null;
            try
            {
                AcApp = (AcadApplication)Marshal.GetActiveObject("AutoCad.Application");
            }
            catch
            {
                try
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(autocadExePath);
                    string projid = string.Format("{0}.{1}.{2}",
                        versionInfo.FileDescription.Replace(' ', '.'),
                        versionInfo.ProductMajorPart,
                        versionInfo.ProductMinorPart);
                        
                        
                    //Type type = Type.GetTypeFromProgID(projid);
                    //AcApp = Activator.CreateInstance(type);

                    var acadProcess = new Process();
                    acadProcess.StartInfo.Arguments = "/nologo";
                    acadProcess.StartInfo.FileName = autocadExePath;
                    acadProcess.Start();
                    while (AcApp == null)
                    {
                        try
                        {
                            AcApp = (AcadApplication)Marshal.GetActiveObject(projid);
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (COMException)
                {
                    throw;
                }
            }
            try
            {
                int i = -1;
                while (!AcApp.GetAcadState().IsQuiescent && i++ < 120)
                    Thread.Sleep(250);

                if (i == 120)
                    Environment.Exit(0);

            }
            catch (COMException err)
            {
                if (err.ErrorCode.ToString() == "-2147417846")
                {
                    Thread.Sleep(5000);
                }
            }
            return AcApp;
        }
    }
}
