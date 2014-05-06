using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;

namespace XxZerOxXClassLibrary.AutoCad
{
    public static class Extensions
    {
        public static void SendCommandAsync(this Document doc,string command)
        {
            var acadDoc = doc.AcadDocument;
            acadDoc.GetType().InvokeMember(
                "SendCommand",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                acadDoc,
                new[] { command + "\n" });
        }
    }
}
