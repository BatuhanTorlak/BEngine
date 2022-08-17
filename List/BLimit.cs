namespace BEngine.List
{
    public class BLimit<T> : IListable<T>
    {
        private T[] ts;
        private int Size;
        private int fullSize;

        public BLimit(int size)
        {
            Size = size;
            ts = new T[size];
            fullSize = 0;
        }

        public T this[int index] { get => ts[index]; set => ts[index] = value; }

        public bool GetTypeObjects<Y>(out Y[] arr) where Y : T
        {
            Y[] ys = new Y[fullSize];
            int ct = 0;
            System.Type type = typeof(Y);

            for (var x = 0; x < fullSize; x++)
            {
                if (ts[x].GetType() == type)
                {
                    ys[ct] = (Y)ts[x];
                    ct++;
                }
            }
            if (ct == 0)
            {
                arr = new Y[0];
                return false;
            }
            Y[] newYs = new Y[ct];
            for (var x = 0; x < ct; x++)
            {
                newYs[x] = ys[x];
            }

            arr = newYs;
            return true;
        }

        public bool RemoveLeastAndGet(out T Out)
        {
            if (fullSize == 0)
            {
                Out = default(T);
                return false;
            }
            fullSize--;
            Out = ts[fullSize];
            ts[fullSize] = default(T);
            return true;
        }

        public bool RemoveLeastAndGet<Y>(out Y Out) where Y : T
        {
            if (fullSize == 0)
            {
                Out = default(Y);
                return false;
            }
            System.Type type = typeof(Y);
            for (var x = fullSize - 1; x >= 0; x--)
            {
                if (ts[x].GetType() == type)
                {
                    var rt = ts[x];
                    for (var i = x; x < fullSize - 1; x++)
                        ts[i] = ts[i + 1];
                    fullSize--;
                    Out = (Y)rt;
                    return true;
                }
            }
            Out = default(Y);
            return false;
        }

        public void Add(T obj)
        {
            if (fullSize == Size)
                return;
            ts[fullSize] = obj;
            fullSize++;
        }

        public void Add(T[] objs)
        {
            if (Size - fullSize < objs.Length)
                return;
            for (var x = 0; x < objs.Length; x++)
            {
                ts[fullSize + x] = objs[x];
            }
            fullSize += objs.Length;
        }

        public T RemoveAndGet(int index)
        {
            if (index >= fullSize)
                throw null;
            T rt = ts[index];

            for (var x = index; x < fullSize - 1; x++)
                ts[x] = ts[x + 1];

            return rt;
        }

        public int GetSize() => Size;

        public int Count() => fullSize;

        public void Resize(int newSize)
        {
            T[] arr = new T[newSize];
            
            if (newSize > fullSize)
            {
                for (var x = 0; x < fullSize; x++)
                {
                    arr[x] = ts[x];
                }
            }
            else
            {
                for (var x = 0; x < newSize; x++)
                {
                    arr[x] = ts[x];
                }
            }

            ts = arr;
        }

        public bool Contains(T obj)
        {
            throw new System.NotImplementedException();
        }

        public BArray<T> ToBArray()
        {
            return ts;
        }

        public T[] ToArray()
        {
            return ts;
        }

        public RepeatableList<T> GetRepeatableList()
        {
            T[] newTs = new T[fullSize];
            BArray<T>.Copy(ts, newTs);
            return new RepeatableList<T>(newTs);
        }
    }
}
