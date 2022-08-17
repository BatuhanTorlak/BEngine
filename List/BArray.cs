namespace BEngine.List
{
    public class BArray<T> : IListable<T>
    {
        public static implicit operator BArray<T>(T[] arr) => new BArray<T>(arr);
        public static implicit operator BArray<T>(T obj) => new BArray<T>(new T[] { obj });
        public static implicit operator T[](BArray<T> arr) => arr.ts;

        T[] ts;
        public BArray(int size)
        {
            ts = new T[size];
        }

        public BArray(T[] arr)
        {
            ts = arr;
        }

        public BArray()
        {
            ts = new T[0];
        }

        public T[] ToArray() => ts;

        public T this[int index] { get => ts[index]; set => ts[index] = value; }

        public static void Copy(T[] From, T[] To)
        {
            if (From.Length == To.Length)
            {
                To = From;
                return;
            }
            
            var lit = 0;
            if (From.Length > To.Length)
            {
                lit = To.Length;
            }
            else
            {
                lit = From.Length;
            }
            for (var x = 0; x < lit; x++)
            {
                To[x] = From[x];
            }
        }

        public bool Contains(T obj)
        {
            for (var x = 0; x < ts.Length; x++)
            {
                if (ts[x].Equals(obj))
                    return true;
            }
            return false;
        }

        public BArray<T> ToBArray()
        {
            return this;
        }

        public RepeatableList<T> GetRepeatableList()
        {
            return new RepeatableList<T>(ts);
        }
    }
}
