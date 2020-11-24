using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace LR3_MPP
{
    static class Program
    {
        private const int StdOutputHandle = -11;
        private const int WritingInterval = 200;
        private const int ClosingDelay = 1500;

        [DllImport(
            "kernel32.dll",
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr GetStdHandle(int nStdHandle);
        
        public static void Main()
        {
            Thread thread = new Thread(ConsoleWrite);
            thread.Start();
            CloseHandleAsync(GetStdHandle(StdOutputHandle), ClosingDelay);
        }

        static async void CloseHandleAsync(IntPtr handle, int delay)
        {
            await Task.Delay(delay);
            Console.WriteLine($"Closing handle: {handle}");
            new OSHandle(handle).Dispose();
        }

        static void ConsoleWrite()
        {
            Mutex mutex = new Mutex();
            while (true)
            {
                try
                {
                    mutex.Lock();
                    Console.WriteLine($"Thread ({Thread.CurrentThread.ManagedThreadId}) is alive.");
                    mutex.Unlock();
                    Thread.Sleep(WritingInterval);
                }
                catch
                {
                    mutex.Unlock();
                    break;
                }
            }
        }
    }
}
