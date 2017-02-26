using System;
using System.Threading;

namespace DesktopBridgeEnvironment
{
    public sealed class SingleInstance : IDisposable
    {
        private readonly Mutex _mutex;

        public SingleInstance(string appId)
        {
            _mutex = new Mutex(true, appId);
        }

        public bool IsFirstInstance
        {
            get
            {
                return _mutex.WaitOne(TimeSpan.Zero, true);
            }
        }

        public void Dispose()
        {
            if (IsFirstInstance)
            {
                _mutex.ReleaseMutex();
            }
            _mutex.Dispose();
        }
    }
}
