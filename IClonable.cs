namespace BEngine
{
    public interface IClonable<T> where T : class
    {
        public T Clone(params object?[]? parameters);
    }
}
