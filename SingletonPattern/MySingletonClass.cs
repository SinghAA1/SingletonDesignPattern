using System;
namespace SingletonPattern
{
    //there will only ever be one of these in existance per app domain
    public class MySingletonClass : IDisposable
    {
        private bool _disposed;
        //usage: var singleton = MySingletonClass.Instance
        private static volatile MySingletonClass _instance;
        private static readonly object _syncLock = new object();

        public MySingletonClass()
        {
        }

        public static MySingletonClass Instance
        {
            get
            {
                if(_instance != null) //already created
                {
                    return _instance;
                }
                lock(_syncLock) //single threaded
                {
                    if(_instance == null)
                    {
                        _instance = new MySingletonClass();
                    }
                }
                return _instance;
               
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if(disposing)
            {
                _instance = null; //dispose managed instance
            }
            _disposed = true;
                
        }

        ~MySingletonClass()
        {
            Dispose(false);
        }
    }
}
