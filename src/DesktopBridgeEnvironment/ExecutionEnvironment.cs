using DesktopBridge;

namespace DesktopBridgeEnvironment
{
    public static class ExecutionEnvironment
    {
        static ExecutionEnvironment()
        {
            if (new Helpers().IsRunningAsUwp())
            {
                Current = new UwpEnvironment();
            }
            else
            {
                Current = new Win32Environment();
            }
        }

        public static IExecutionEnvironment Current { get; private set; }
    }
}
