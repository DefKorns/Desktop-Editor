using Microsoft.Win32.SafeHandles;
using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;


namespace Desktop_Editor
{
    static class Program
    {
        public static string BaseDirectoryInternal { get; internal set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            BaseDirectoryInternal = Path.GetDirectoryName(Application.ExecutablePath);
        }
    }
}
