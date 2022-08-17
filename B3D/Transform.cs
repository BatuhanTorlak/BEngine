using BEngine.Vectors;

namespace BEngine.B3D
{
    public class Transform
    {
        public Object Parent { get; private set; }
        private Vector3 _position;
        public Vector3 position;
        public Vector3 localPosition
        {
            get
            {
                if (Parent.Parent != null)
                {
                    return position - _position;
                }
                return _position;
            }
            set
            {
                position += value - localPosition;
                _position = value;
            }
        }

        internal Transform(Object parent)
        {
            Parent = parent;
        }

        internal Transform Clone()
        {
            Transform transform = new Transform(Parent);
            transform.position = this.position;
            return transform;
        }

        internal Transform Clone(Object newParent)
        {
            Transform transform = new Transform(newParent);
            transform.position = this.position;
            return transform;
        }
    }
}
