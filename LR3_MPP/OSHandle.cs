using System;
using System.Runtime.InteropServices;

namespace LR3_MPP
{
    public class OSHandle : IDisposable
    {
        [DllImport("Kernel32.dll",
            EntryPoint = "CloseHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern bool CloseHandle(IntPtr handle);
        private readonly Mutex mutex;
        private bool disposed = false;

        public IntPtr Handle { get; set; }

        public OSHandle(IntPtr handle)
        {
            Handle = handle;
            mutex = new Mutex();
        }

        ~OSHandle()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            mutex.Lock();
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                {
                    CloseHandle(Handle);
                    Handle = IntPtr.Zero;
                }

                disposed = true;
            }

            mutex.Unlock();
        }
    }
}
