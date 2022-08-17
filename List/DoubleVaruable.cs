namespace BEngine.List
{
    public class DoubleVaruable<T1, T2>
    {
        public static bool operator ==(DoubleVaruable<T1, T2> left, DoubleVaruable<T1, T2> right) => (left.first.Equals(right.first)) & (left.second.Equals(right.second));
        public static bool operator !=(DoubleVaruable<T1, T2> left, DoubleVaruable<T1, T2> right) => !(left == right);

        public T1 first;
        public T2 second;

        public DoubleVaruable(T1 obj1, T2 obj2)
        {
            first = obj1;
            second = obj2;
        }
        public DoubleVaruable(T1 obj1)
        {
            first = obj1;
        }

        public DoubleVaruable(T2 obj2)
        {
            second = obj2;
        }

        public DoubleVaruable() { }

        public override bool Equals(object? obj)
        {
            if (obj == null | this == null | obj.GetType() != GetType())
                return false;
            return this == obj;
        }
    }
}
