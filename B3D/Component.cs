namespace BEngine.B3D
{
    public interface IComponent
    {
        internal void Start();
        internal void Update();
        internal IComponent Clone();
        internal IComponent Create(params object?[]? parameters);
    }

    internal static class Component
    {
        internal static IComponent component;
    }
}
