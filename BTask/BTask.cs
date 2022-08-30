#if BTASK == false
#define BTASK
#endif

namespace BEngine.Task
{
    using List;
    public static class BTask
    {
        private static BDictionary<int, BTasks> btasks;
        private static bool IsFinished;
        private static int LastCodeCt;
        private class BTasks
        {
            internal BAction cmd;
            internal float rpt;
            private bool Runnable;

            internal BTasks(BAction act, float t)
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

        public static int InvokeRepeating(BAction cmd, float t)
        {
            if (!IsFinished)
            {
                LastCodeCt = 0;
                btasks = new BDictionary<int, BTasks>();
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
            if (btasks.Count() == 0)
                IsFinished = false;
        }

        public static void CancelInvokeAll()
        {
            IsFinished = false;
            if (btasks != null & btasks.Count() != 0)
            {
                foreach(var x in btasks.ToArray())
                    x.second.Stop();
                btasks = new BDictionary<int, BTasks>();
            }
        }

        public static void Invoke(BAction command, float t)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Tasks.Task.Delay(Convert.ToInt32(t * 1000)).Wait();
                command.Invoke();
            });
        }
    }
}