using BEngine.MathB;

namespace BEngine
{
    public interface IConvertible
    {
        public int ToInt32();
        public float ToFloat();
        public double ToDouble();
        public virtual BString ToString() => ToString();
        public Irr32 ToIrr32();
        public byte ToInt8();
        public long ToInt64();
        public char ToChar();
        public BInt ToBInt();
        public bool ToBool();
    }

    public interface IConvertible<T>
    {
        public T ToType();
    }
}
