namespace BEngine.List
{
    public class BDictionary<T, T1> : IList<DoubleVaruable<T, T1>>, IListable<DoubleVaruable<T, T1>>
    {
        private BList<DoubleVaruable<T, T1>> vars = new BList<DoubleVaruable<T, T1>>();

        public T1 this[T i]
        {
            get
            {
                var index = GetIndex(i);
                return vars[index].second;
            }
            set
            {
                var index = GetIndex(i);
                vars[index].second = value;
            }
        }

        private int GetIndex(T index)
        {
            for (var x = 0; x < vars.Count(); x++)
            {
                if (vars[x].first.Equals(index))
                    return x;
            }
            return vars.Count();
        }
    
        public void Add(T head, T1 value)
        {
            if (head == null | value == null)
                throw null;
            vars.Add(new DoubleVaruable<T, T1>(head, value));
        }

        public void Add(T[] head, T1[] value)
        {
            var leng = head.Length;
            if (leng != value.Length | head == null | value == null | leng == 0)
                throw null;
            for (var x = 0; x < leng; x++)
                vars.Add(new DoubleVaruable<T, T1>(head[x], value[x]));
        }

        public void AddStart(T head, T1 value)
        {
            if (head == null | value == null)
                throw null;
            vars.AddStart(new DoubleVaruable<T, T1>(head, value));
        }

        public void AddStart(T[] head, T1[] value)
        {
            var leng = head.Length;
            if (leng != value.Length | head == null | value == null | leng == 0)
                throw null;
            for (var x = leng - 1; x >= 0; x--)
                vars.AddStart(new DoubleVaruable<T, T1>(head[x], value[x]));
        }

        public DoubleVaruable<T, T1> GetIndex(int index)
        {
            return vars[index];
        }

        public void Remove(T key)
        {
            vars.RemoveAt(GetIndex(key));
        }

        public void RemoveAt(int index) => vars.RemoveAt(index);

        public bool Contains(DoubleVaruable<T, T1> obj)
        {
            for (var x = 0; x < vars.Length; x++)
            {
                if (vars[x] == obj)
                    return true;
            }
            return false;
        }

        public void Add(DoubleVaruable<T, T1> obj)
        {
            vars.Add(obj);
        }

        public void Add(DoubleVaruable<T, T1>[] obj)
        {
            vars.Add(obj);
        }

        public void Add(IListable<DoubleVaruable<T, T1>> obj)
        {
            vars.Add(obj);
        }

        public void Add(RepeatableList<DoubleVaruable<T, T1>> obj)
        {
            vars.Add(obj);
        }

        public void Remove(DoubleVaruable<T, T1> obj)
        {
            vars.Remove(obj);
        }

        public int Count()
        {
            return vars.Count();
        }

        public BArray<DoubleVaruable<T, T1>> ToBArray()
        {
            return vars.ToBArray();
        }

        public DoubleVaruable<T, T1>[] ToArray()
        {
            return vars.ToArray();
        }

        RepeatableList<DoubleVaruable<T, T1>> IListable<DoubleVaruable<T,T1>>.GetRepeatableList()
        {
            return new RepeatableList<DoubleVaruable<T, T1>>(vars);
        }
    }
}
