using BEngine.MathB;

namespace BEngine
{
    public static class Convert
    {
        public static T ToType<T>(IConvertible<T> value) => value.ToType();

        public static int ToInt32(System.IConvertible value) => value.ToInt32(null);
        public static float ToFloat(System.IConvertible value) => value.ToSingle(null);
        public static double ToDouble(System.IConvertible value) => value.ToDouble(null);
        public static BString toString(object value) => value.ToString();
        public static byte ToInt8(System.IConvertible value) => value.ToByte(null);
        public static long ToInt64(System.IConvertible value) => value.ToInt64(null);
        public static char ToChar(System.IConvertible value) => value.ToChar(null);

        public static int ToInt32(IConvertible value) => value.ToInt32();
        public static float ToFloat(IConvertible value) => value.ToFloat();
        public static double ToDouble(IConvertible value) => value.ToDouble();
        public static Irr32 ToIrr32(IConvertible value) => value.ToIrr32();
        public static byte ToInt8(IConvertible value) => value.ToInt8();
        public static long ToInt64(IConvertible value) => value.ToInt64();
        public static char ToChar(IConvertible value) => value.ToChar();
        public static BInt ToBInt(IConvertible value) => value.ToBInt();
        public static bool ToBool(IConvertible value) => value.ToBool();
    }
}
