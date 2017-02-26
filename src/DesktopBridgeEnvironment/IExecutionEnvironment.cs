namespace DesktopBridgeEnvironment
{
    public interface IExecutionEnvironment
    {
        string AppId { get; }

        string Version { get; }

        bool IsUwp { get; }

        string[] StartupArgs { get; set; }
    }
}
