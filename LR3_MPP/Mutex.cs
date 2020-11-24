using System.Threading;

namespace LR3_MPP
{
    public class Mutex
    {
        private const int UnlockedId = -1;
        private int lockThreadId = UnlockedId;

        private static int CurrentThreadId => Thread.CurrentThread.ManagedThreadId;

        public void Lock()
        {
            SpinWait spinWait = new SpinWait();
            while (Interlocked.CompareExchange(ref lockThreadId, CurrentThreadId, UnlockedId) != UnlockedId)
            {
                spinWait.SpinOnce();
            }
        }

        public void Unlock()
        {
            if (Interlocked.CompareExchange(ref lockThreadId, UnlockedId, CurrentThreadId) != CurrentThreadId)
            {
                throw new UnlockMutexException($"Unable to unlock mutex by {CurrentThreadId} thread");
            }
        }
    }
}
