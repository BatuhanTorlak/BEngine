#define COMPONENTS

namespace BEngine.B3D.Components
{
    public class Collider : IComponent
    {
        public Object Parent { get; private set; }

        internal Collider(Object parent)
        {
            Parent = parent;
        }

        internal IComponent Clone()
        {
            return new Collider(Parent);
        }

        void IComponent.Start()
        {
            throw null;
        }

        void IComponent.Update()
        {
            throw null;
        }

        IComponent IComponent.Clone()
        {
            throw null;
        }

        IComponent IComponent.Create(params object[] parameters)
        {
            return new Collider((Object)parameters[0]);
        }
    }
}