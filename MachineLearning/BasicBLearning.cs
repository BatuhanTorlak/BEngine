namespace BEngine.MachineLearning
{
    using List;
    public class BasicBLearning
    {
        public BActionOut<WorkStatus>[] cmds;

        public int ct { private set; get; } = 0;
        public int step { private set; get; } = 0;
        private BList<BList<int>> bList = new BList<BList<int>>();
        private int LeastWork = 0;

        public void Reset()
        {
            ct++;
            step = 0;
        }

        public WorkStatus Work()
        {
            step++;
            if (ct == 0)
            {
                LeastWork = BFuncs.RandomInt(0, cmds.Length);
                return cmds[LeastWork]();
            }
            return WorkStatus.Ongoing;
        }

        public void CompleteWork(WorkStatus status)
        {
            bList[ct].Add(LeastWork);
            switch (status)
            {
                case WorkStatus.Fail:
                    break;
                case WorkStatus.Ongoing:
                    break;
                case WorkStatus.Complete:
                    break;
            }
        }
    }
}
