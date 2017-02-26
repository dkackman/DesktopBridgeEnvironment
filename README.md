
# DesktopBridgeEnvironment
Library that helps a Desktop Bridge application run both as a package and regular exe.

[NuGet Package](https://www.nuget.org/packages/DesktopBridgeEnvironment/)

A Desktop Bridge exe doesn't share the same Launch.Suspend semantics as a UWP app. This make Toast notifcations somewhat cumbersome as everytime a user reacts to a UWP notificaiton an new instance is invoked. Further, the lifetime a UWP toast can outlast the app instance. This package helps smooth over those differences between UWP and Win32.

    static void Main(string [] args)
    {
        using (var instance = new SingleInstance(ExecutionEnvironment.Current.AppId))
        {
            // make sure we are the only instance running before doing anything.
            if (instance.IsFirstInstance)
            {
                ExecutionEnvironment.Current.StartupArgs = args;

                Application.Run(new Form1());
            }
        }
    }
    
And then elsewhere in the app:

    protected override void OnLoad(EventArgs e)
    {
        if (ExecutionEnvironment.Current.IsUwp)
        {
            // do uwp form load stuff
            
            if (ExecutionEnvironment.Current.StartupArgs != null && ExecutionEnvironment.Current.StartupArgs.Length > 0)
            {
                // process Uwp notification message
            }            
        }
        else
        {
            // do win32 form load stuff
        }
        
        base.OnLoad(e);       
    }

