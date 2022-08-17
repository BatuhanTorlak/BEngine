namespace BEngine.B3D
{
    public class Script : IComponent
    {
        public Object gameObject
        {
            private set;
            get;
        }

        public Script(Object parent)
        {
            gameObject = parent;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        void IComponent.Start()
        {
            this.Start();
        }

        void IComponent.Update()
        {
            this.Update();
        }

        IComponent IComponent.Clone()
        {
            throw new System.NotImplementedException();
        }

        IComponent IComponent.Create(params object[] parameters)
        {
            return this;
        }
    }
}
