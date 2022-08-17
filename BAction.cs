namespace BEngine
{
    public delegate void BAction();
    public class BFunc
    {
        public static implicit operator BFunc(BAction act) => new BFunc(act);
        
        public BFunc(BAction act)
        {
            action = act;
        }

        private BAction action;

        public async void AsyncInvoke()
        {
            action();
        }

        public void Invoke()
        {       
            action();
        }
    }

    public delegate void BAction<in T>(T obj);
    public class BFunc<T>
    {
        public static implicit operator BFunc<T>(BAction<T> act) => new BFunc<T>(act);

        public BFunc(BAction<T> act)
        {
            action = act;
        }

        private BAction<T> action;

        public async void AsyncInvoke(T obj)
        {
            action(obj);
        }

        public void Invoke(T obj)
        {
            action(obj);
        }
    }

    public delegate T BActionOut<out T>();
    public class BFuncOut<T>
    {
        public static implicit operator BFuncOut<T>(BActionOut<T> act) => new BFuncOut<T>(act);

        public BFuncOut(BActionOut<T> act)
        {
            action = act;
        }

        private BActionOut<T> action;

        public async void AsyncInvoke(T obj)
        {
            action();
        }

        public T Invoke()
        {
            return action();
        }
    }

    public delegate void BAction<in T, in T1>(T obj, T1 obj2);
    public class BFunc<T, T1>
    {
        public static implicit operator BFunc<T, T1>(BAction<T, T1> act) => new BFunc<T, T1>(act);

        public BFunc(BAction<T, T1> act)
        {
            action = act;
        }

        private BAction<T, T1> action;

        public async void AsyncInvoke(T obj, T1 obj2)
        {
            action(obj, obj2);
        }

        public void Invoke(T obj, T1 obj2)
        {
            action(obj, obj2);
        }
    }

    public delegate Tout BActionOut<in T, out Tout>(T obj);
    public class BFuncOut<T, Tout>
    {
        public static implicit operator BFuncOut<T, Tout>(BActionOut<T, Tout> act) => new BFuncOut<T, Tout>(act);

        public BFuncOut(BActionOut<T, Tout> act)
        {
            action = act;
        }

        private BActionOut<T, Tout> action;

        public async void AsyncInvoke(T obj)
        {
            action(obj);
        }

        public Tout Invoke(T obj)
        {
            return action(obj);
        }
    }

    public delegate Tout BActionOut<in T, in T1, out Tout>(T obj, T1 obj1);
    public class BFuncOut<T, T1, Tout>
    {
        public static implicit operator BFuncOut<T, T1, Tout>(BActionOut<T, T1, Tout> act) => new BFuncOut<T, T1, Tout>(act);

        public BFuncOut(BActionOut<T, T1, Tout> act)
        {
            action = act;
        }

        private BActionOut<T, T1, Tout> action;

        public async void AsyncInvoke(T obj, T1 obj1)
        {
            action(obj, obj1);
        }

        public Tout Invoke(T obj, T1 obj1)
        {
            return action(obj, obj1);
        }
    }
}
