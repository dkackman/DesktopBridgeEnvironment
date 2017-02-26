using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DesktopBridgeEnvironment
{
    sealed class Win32Environment : IExecutionEnvironment
    {
        public string AppId
        {
            get
            {
                var guid = Assembly.GetEntryAssembly().GetCustomAttribute<GuidAttribute>()?.Value;
                return guid ?? Assembly.GetEntryAssembly().CodeBase;
            }
        }

        public string Version => Assembly.GetEntryAssembly().GetName().Version.ToString(4);

        public bool IsUwp => false;

        public string[] StartupArgs { get; set; }

    }
}
