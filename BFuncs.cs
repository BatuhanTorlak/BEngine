namespace BEngine
{
    using List;

    public static class BFuncs
    {
        public static readonly byte Continue = 1;
        public static readonly byte Break = 2;
        public static readonly byte Return = 3;

        public static void Cout(object? msg)
        {
            System.Console.Write(msg);
        }

        public static void Cout() { }

        public static void CoutNewLine(object? msg)
        {
            System.Console.Write(msg);
            System.Console.Write("\n");
        }

        public static void CoutNewLine()
        {
            System.Console.Write("\n");
        }

        public static BString? Cin()
        {
            return System.Console.ReadLine();
        }

        public static BString? Cin(object? msg)
        {
            Cout(msg);
            return Cin();
        }

        public static void BForeach<T>(RepeatableList<T> enumerable, BActionOut<T, byte> command)
        {
            var i = command.Invoke(enumerable.Current);
            while (enumerable.Next())
            {
                if (i == Break)
                    break;
                i = command.Invoke(enumerable.Current);
            }
        }

        public static void BForeach<T>(RepeatableList<T> enumerable, BActionOut<T, uint, byte> command)
        {
            var i = command.Invoke(enumerable.Current, enumerable.current);
            while (enumerable.Next())
            {
                if (i == Break)
                    break;
                i = command.Invoke(enumerable.Current, enumerable.current);
            }
        }

        public static void AsyncFunc(System.Action command)
        {
            System.Threading.Tasks.Task.Run(command);
        }

        public static void AsyncFunc(System.Action command, float time)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Tasks.Task.WaitAll(System.Threading.Tasks.Task.Delay((int)(time * 1000)));
                command.Invoke();
            });
        }

        public unsafe static int GetSize<T>(T* ptr) where T : unmanaged
        {
            int ct = 0;
            while(true)
            {
                if (*(byte*)(ptr + ct) == 0)
                    break;
                ct++;
            }
            return ct;
        }

        public unsafe static void* HeapAlloc(int size)
        {
            fixed(byte* vs = new byte[size + 1])
            {
                *(vs + size) = 0;
                return vs;
            }
        }

        public unsafe static void* StackAlloc(int size)
        {
            byte* vs = stackalloc byte[size + 1];
            *(vs + size) = 0;
            return vs;
        }

        private static int leastRanNum;

        private static int LCG16BASE(int num)
        {
            num = unchecked(8253729 * num + 2396403);
            return num % 3276;
        }

        private static int LCG16(int num)
        {
            num = unchecked(LCG16BASE(num / 2) * num + LCG16BASE(num / 3));
            return num % LCG16BASE(num / 6);
        }

        public static int RandomInt(int min, int max)
        {
            if (leastRanNum == default)
            {
                leastRanNum = LCG16(MathB.MathB.Center(min, max));
            }
            else
            {
                leastRanNum = LCG16(leastRanNum);
            }
            return MathB.MathB.Scale(leastRanNum, int.MinValue, int.MaxValue, min, max);
        }
    }
}