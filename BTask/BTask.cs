#if BTASK == false
#define BTASK
#endif

using System.Threading.Tasks;

namespace BEngine.Task
{
    public static class BTask
    {
        private static System.Collections.Generic.Dictionary<int, BTasks> btasks;
        private static bool IsFinished;
        private static int LastCodeCt;
        private class BTasks
        {
            internal System.Action cmd;
            internal float rpt;
            private bool Runnable;

            internal BTasks(System.Action act, float t)
            {
                cmd = act;
                rpt = t;
                Runnable = true;
                Invoke(Run, rpt);
            }

            internal void Run()
            {
                if (!Runnable | !IsFinished)
                    return;
                cmd.Invoke();
                Invoke(Run, rpt);
            }

            internal void Stop()
            {
                Runnable = false;
            }
        }

        public static int InvokeRepeating(System.Action cmd, float t)
        {
            if (!IsFinished)
            {
                LastCodeCt = 0;
                btasks = new System.Collections.Generic.Dictionary<int, BTasks>();
                btasks.Add(0, new BTasks(cmd, t));
                IsFinished = true;
                return 0;
            }

            LastCodeCt++;
            btasks.Add(LastCodeCt, new BTasks(cmd, t));

            return LastCodeCt;
        }

        public static void CancelInvoke(int i)
        {
            btasks[i].Stop();
            btasks.Remove(i);
            if (btasks.Count == 0)
                IsFinished = false;
        }

        public static void CancelInvokeAll()
        {
            IsFinished = false;
            if (btasks != null & btasks.Count != 0)
            {
                foreach(var x in btasks)
                    x.Value.Stop();
                btasks.Clear();
            }
        }

        public static void Invoke(System.Action command, float t)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Tasks.Task.WaitAll(System.Threading.Tasks.Task.Delay(System.Convert.ToInt32(t * 1000)));
                command.Invoke();
            });
        }
    }
}