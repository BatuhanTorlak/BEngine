namespace BEngine.List
{
    public class RepeatableList<T>
    {
        public static implicit operator RepeatableList<T>(T[] obj) => new RepeatableList<T>(obj);
        public static implicit operator RepeatableList<T>(BArray<T> obj) => obj.GetRepeatableList();

        internal uint current;
        internal int length;
        internal T[] ts;
        public T Current => ts[current];

        public bool Next()
        {
            current++;
            if (current < length)
            {
                return true;
            }
            return false;
        }

        public bool Back()
        {
            current--;
            if (current >= 0)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            current = 0;
        }

        public RepeatableList(T[] Ts)
        {
            current = 0;
            length = Ts.Length;
            ts = Ts;
        }
    }
}
