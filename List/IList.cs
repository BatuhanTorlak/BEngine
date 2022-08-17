namespace BEngine.List
{
    public interface IList<T>
    {
        public void Add(T obj);
        public void Add(T[] obj);
        public void Add(IListable<T> obj);
        public void Add(RepeatableList<T> obj);
        public void Remove(T obj);
        public void RemoveAt(int index);
        public bool Contains(T obj);
        public int Count();
    }
}
