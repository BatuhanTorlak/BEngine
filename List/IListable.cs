namespace BEngine.List
{
    public interface IListable<T>
    {
        public BArray<T> ToBArray();
        public T[] ToArray();
        public RepeatableList<T> GetRepeatableList();
    }
}
