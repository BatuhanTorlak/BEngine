using BEngine.List;
using BEngine.Vectors;

namespace BEngine.B3D
{
    public class Object
    {
        public string Name { get; set; }
        public Transform transform { get; private set; }
        internal Object? Parent { get; set; }
        internal BList<IComponent> components { get; set; } = new BList<IComponent>();

        internal Object()
        {
            transform = new Transform(this);
            Parent = null;
            Name = "Object";
        }
        internal Object(Object parent)
        {
            transform = new Transform(this);
            Parent = parent;
            Name = "Object";
        }
        internal Object(Transform transform, Object? parent)
        {
            this.transform = transform;
            Parent = parent;
            Name = "Object";
        }
        internal Object(Transform transform, string name, Object? parent)
        {
            this.transform = transform;
            Parent = parent;
            Name = name;
        }

        public bool TryGetParent(out Object parent)
        {
            parent = Parent;
            return Parent != null;
        }

        public T AddComponent<T>() where T : IComponent, new()
        {
            foreach(var x in components.ToArray())
            {
                if (x.GetType() == typeof(T))
                    throw null;
            }

            var y = new T();

            components.Add(y);

            return y;
        }

        public T GetComponent<T>() where T : IComponent
        {
            foreach(var x in components.ToArray())
            {
                if (x.GetType() == typeof(T))
                    return (T)x;
            }

            throw null;
        }

        public static Object TestInstantiate()
        {
            return new Object();
        }

        public static Object Instantiate()
        {
            Object obj = new Object();
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Object referance)
        {
            Object obj = referance.Clone();
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Transform parent)
        {
            Object obj = new Object(parent.Parent);
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Vector3 position)
        {
            Object obj = new Object();
            obj.transform.position = position;
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Transform parent, Object referance)
        {
            Object obj = referance.Clone();
            obj.Parent = parent.Parent;
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Transform parent, Vector3 position)
        {
            Object obj = new Object(parent.Parent);
            obj.transform.position = position;
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        public static Object Instantiate(Transform parent, Object referance, Vector3 position)
        {
            Object obj = referance.Clone();
            obj.Parent = parent.Parent;
            obj.transform.position = position;
            SceneManager.ActiveScene.SceneObjs.Add(obj);
            return obj;
        }

        internal Object Clone()
        {
            Object obj = new Object(transform.Clone(), Name, Parent);
            foreach(var x in components.ToArray())
            {
                obj.components.Add(x.Clone());
            }
            return obj;
        }
    }
}
