#define BLIST

namespace BEngine.List
{
    public class BList<T> : IList<T>, IListable<T>
    {
        public static BList<T> operator +(BList<T> left, T right) { var x = new BList<T>(left.ts); x.Add(right); return x; }
        public static BList<T> operator +(T left, BList<T> right) {  var x = new BList<T>(right.ts); x.AddStart(left); return x; }
        /*public static BList<T> operator +(IEnumerable<T> left, BList<T> right)
        {
            var obj = new BList<T>(left);
            obj.Add(right.ToArray());

            return obj;
        }*/
        public static BList<T> operator +(T[] left, BList<T> right) 
        {
            var obj = new BList<T>(left);
            obj.Add(right.ts);

            return obj;
        }
        /*public static BList<T> operator +(BList<T> left, IEnumerable<T> right)
        {
            var obj = new BList<T>(left);
            obj.Add(right.ToArray());

            return obj;
        }*/
        public static BList<T> operator +(BList<T> left, T[] right)
        {
            var obj = new BList<T>(left.ts);
            obj.Add(right);

            return obj;
        }
        public static BList<T> operator +(BList<T> left, BList<T> right) 
        {
            var obj = new BList<T>(left.ts);
            obj.Add(right.ts);

            return obj;
        }
        public static implicit operator BList<T>(T[] vs) => new BList<T>(vs);
        public static implicit operator BList<T>(T obj) => new T[]{ obj };
        public static implicit operator T[](BList<T> obj) => obj.ts;
        private T[] ts;
        public int Length
        {
            get
            {
                return ts.Length;
            }
        }

        public BList()
        {
            ts = new T[0];
        }

        public BList(RepeatableList<T> vs)
        {
            ts = vs.ts;
        }

        /*public BList(IEnumerable<T> vs)
        {
            ts = vs.ToArray();
        }*/

        public BList(T[] vs)
        {
            ts = vs;
        }

        public void Add(T Obj)
        {
            if(Length == 0)
            {
                ts = new T[] { Obj };
                return;
            }

            var i = new T[Length + 1];
            i[Length] = Obj;

            for (var x = 0; x < Length; x++)
            {
                i[x] = ts[x];
            }

            ts = i;
        }

        public T this[int i]
        {
            get
            {
                return ts[i];
            }
            set
            {
                ts[i] = value;
            }
        }

        /*public void Add(IEnumerable<T> Objs)
        {
            var ct = 0;
            
            foreach(var x in Objs)
            {
                ct++;
            }

            if (ct == 0)
                return;

            var obj = new T[ct];
            var d = 0;
            foreach(var x in Objs)
            {
                obj[d] = x;
                d++;
            }

            if (Length == 0)
            {
                ts = new T[ct];
                for (var x = 0; x < ct; x++)
                {
                    ts[x] = obj[x];
                }
                return;
            }

            var i = new T[ct + Length];

            for (var x = 0; x < Length; x++)
            {
                i[x] = ts[x];
            }
            for (var x = 0; x < ct; x++)
            {
                i[x + ct] = obj[x];
            }

            ts = i;

            return;
        }*/

        public void Add(T[] Objs)
        {
            if (Objs.Length == 0)
                return;

            var i = new T[Objs.Length + Length];

            for (var x = Length; x < Length + Objs.Length; x++)
            {
                i[x] = Objs[x - Length];
            }
            
            if (Length == 0)
            {
                ts = i;
                return;
            }

            for (var x = 0; x < Length; x++)
            {
                i[x] = ts[x];
            }

            ts = i;
        }

        public void Add(IListable<T> obj) => Add(obj.ToArray());

        public void Add(RepeatableList<T> obj) => Add(obj.ts);

        public void AddStart(T Obj)
        {
            if (Length == 0)
            {
                ts = new T[] { Obj };
                return;
            }

            var i = new T[Length + 1];
            i[0] = Obj;

            for(var x = 1; x < Length + 1; x++)
            {
                i[x] = ts[x - 1];
            }

            ts = i;
        }

        public void AddStart(T[] objs)
        {
            var x = new BList<T>(objs);
            x.Add(objs);
            x.Add(ts);

            ts = x.ts;
        }

        public void Insert(int Index, T obj)
        {
            if (Index < 0 | Index > Length)
            {
                throw new System.Exception("Index Out Of Range");
            }

            if (Index == Length)
            {
                Add(obj);
                return;
            }

            if (Index == 0)
            {
                AddStart(obj);
                return;
            }

            var i = new T[Length + 1];
            var x = 0;

            while(x < Index)
            {
                i[x] = ts[x];
                x++;
            }
            i[Index] = obj;
            x++;
            while (x < Length + 1)
            {
                i[x] = ts[x - 1];
                x++;
            }

            ts = i;
        }

        public void RemoveEnd()
        {
            T[] vs = new T[Length - 1];
            for (var x = 0; x < vs.Length; x++)
            {
                vs[x] = ts[x];
            }
            ts = vs;
        }

        public void RemoveStart()
        {
            T[] vs = new T[Length - 1];
            for(var x = 0; x < vs.Length; x++)
            {
                vs[x] = ts[x + 1];
            }
            ts = vs;
        }

        public void RemoveAt(int Index)
        {
            if (Index < 0 | Index > Length)
            {
                throw new System.Exception("Index Out Of Range");
            }

            if (Index == Length)
            {
                RemoveEnd();
                return;
            }

            if (Index == 0)
            {
                RemoveStart();
                return;
            }

            var x = 0;
            var vs = new T[Length - 1];
            while (x < Index)
            {
                vs[x] = ts[x];
                x++;
            }
            x++;
            while (x < Length - 1)
            {
                vs[x - 1] = ts[x];
                x++;
            }
        }

        public void Remove(T obj)
        {
            T[] objs = new T[Length - GetCountOf(obj)];

            var x = 0;
            var y = 0;
            while(x < Length)
            {
                if (ts[x].Equals(obj))
                {
                    x++;
                    continue;
                }
                objs[y] = ts[x];
                y++;
                x++;
            }

            ts = objs;
        }

        public int GetCountOf(params T[] Objs)
        {
            int ct = 0;
            foreach(var x in ts)
            {
                var z = false;
                foreach(var i in Objs)
                {
                    if (i.Equals(x))
                    {
                        z = true;
                        break;
                    }
                }
                if (z)
                {
                    ct++;
                }
            }
            return ct;
        }

        public int GetFirstIndexOf(T obj)
        {
            for (var x = 0; x < ts.Length; x++)
            {
                if (ts[x].Equals(obj))
                    return x;
            }
            return -1;
        }

        public bool Contains(T obj)
        {
            foreach(var x in ts)
            {
                if (x.Equals(obj))
                    return true;
            }

            return false;
        }

        public int Count() => ts.Length;

        public T[] ToArray()
        {
            return ts;
        }

        public override string ToString()
        {
            var x = $"BList<{typeof(T).Name}>() " + "{ ";

            var i = 0;
            while(i < ts.Length - 1)
            {
                x += $"{ts[i]}, ";

                i++;
            }

            x += $"{ts[i]}" + " }";

            return x;
        }

        public BArray<T> ToBArray()
        {
            return ts;
        }

        RepeatableList<T> IListable<T>.GetRepeatableList()
        {
            return new RepeatableList<T>(ts);
        }

        /*public IEnumerator<T> GetEnumerator()
        {
            foreach(var i in ts)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ts.GetEnumerator();
        }*/
    }
}