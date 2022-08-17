namespace BEngine
{
    public struct BChar
    {
        public static implicit operator BChar(char Value) => new BChar(Value);
        public static implicit operator BChar(byte Value) => new BChar(Value);
        public static implicit operator char(BChar Value) => (char)Value.value;
        public static implicit operator byte(BChar Value) => Value.value;
        public static BString operator +(BChar left, BChar right) => new BString(left.value) + new BString(right.value);
        public static byte operator +(BChar left, byte right)
        {
            var value = left.value + right;
            if (value > byte.MaxValue)
                throw null;
            return (byte)value;
        }
        public static byte operator -(BChar left, byte right)
        {
            var value = left.value - right;
            if (value < 0)
                throw null;
            return (byte)value;
        }
        public static bool operator ==(BChar left, BChar right) => left.value == right.value;
        public static bool operator !=(BChar left, BChar right) => left.value != right.value;
        public static bool operator >(BChar left, BChar right) => left.value > right.value;
        public static bool operator <(BChar left, BChar right) => left.value < right.value;
        public static bool operator >=(BChar left, BChar right) => left.value >= right.value;
        public static bool operator <=(BChar left, BChar right) => left.value <= right.value;
        public static bool operator ==(BChar left, byte right) => left.value == right;
        public static bool operator !=(BChar left, byte right) => left.value != right;
        public static bool operator >(BChar left, byte right) => left.value > right;
        public static bool operator <(BChar left, byte right) => left.value < right;
        public static bool operator >=(BChar left, byte right) => left.value >= right;
        public static bool operator <=(BChar left, byte right) => left.value <= right;
        public static bool operator ==(byte left, BChar right) => left == right.value;
        public static bool operator !=(byte left, BChar right) => left != right.value;
        public static bool operator >(byte left, BChar right) => left > right.value;
        public static bool operator <(byte left, BChar right) => left < right.value;
        public static bool operator >=(byte left, BChar right) => left >= right.value;
        public static bool operator <=(byte left, BChar right) => left <= right.value;
        public static bool operator ==(BChar left, char right) => left.value == right;
        public static bool operator !=(BChar left, char right) => left.value != right;
        public static bool operator >(BChar left, char right) => left.value > right;
        public static bool operator <(BChar left, char right) => left.value < right;
        public static bool operator >=(BChar left, char right) => left.value >= right;
        public static bool operator <=(BChar left, char right) => left.value <= right;
        public static bool operator ==(char left, BChar right) => left == right.value;
        public static bool operator !=(char left, BChar right) => left != right.value;
        public static bool operator >(char left, BChar right) => left > right.value;
        public static bool operator <(char left, BChar right) => left < right.value;
        public static bool operator >=(char left, BChar right) => left >= right.value;
        public static bool operator <=(char left, BChar right) => left <= right.value;

        private byte value;

        public BChar(char Value)
        {
            value = (byte)Value;
        }
        public BChar(byte Value)
        {
            value = Value;
        }
    }
}