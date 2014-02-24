using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XxZerOxXClassLibrary.AutoCad
{
    public static class Extenstions
    {
        public static void SendCommandSynchronously(this Autodesk.AutoCAD.ApplicationServices.Document document,
            string commandString)
        {
            object[] data = { commandString + "\n" };
            object comDocument = document.AcadDocument;
            comDocument.GetType().InvokeMember("SendCommand", System.Reflection.BindingFlags.InvokeMethod,
                null, comDocument, data);
        }
    }
}
