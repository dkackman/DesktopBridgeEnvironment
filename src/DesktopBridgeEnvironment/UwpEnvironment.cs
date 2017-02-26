using System.Globalization;
using Windows.ApplicationModel;

namespace DesktopBridgeEnvironment
{
    sealed class UwpEnvironment : IExecutionEnvironment
    {
        public string AppId => Package.Current.Id.FullName;

        public string Version => string.Format(
                                        CultureInfo.InvariantCulture,
                                        "{0}.{1}.{2}.{3}",
                                        Package.Current.Id.Version.Major,
                                        Package.Current.Id.Version.Minor,
                                        Package.Current.Id.Version.Build,
                                        Package.Current.Id.Version.Revision);

        public bool IsUwp => true;

        public string[] StartupArgs { get; set; }

    }
}
