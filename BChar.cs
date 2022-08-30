namespace BEngine
{
    using List;

    public struct BChar : IConvertible
    {
        public static implicit operator BChar(char Value) => new BChar(Value);
        public static implicit operator BChar(short Value) => new BChar(Value);
        public static implicit operator char(BChar Value) => (char)Value.value;
        public static implicit operator short(BChar Value) => Value.value;
        public static BString operator +(BChar left, BChar right) => new BString(left.value) + new BString(right.value);
        public static byte operator +(BChar left, short right)
        {
            var value = left.value + right;
            if (value > byte.MaxValue)
                throw null;
            return (byte)value;
        }
        public static byte operator -(BChar left, short right)
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
        public static bool operator ==(BChar left, short right) => left.value == right;
        public static bool operator !=(BChar left, short right) => left.value != right;
        public static bool operator >(BChar left, short right) => left.value > right;
        public static bool operator <(BChar left, short right) => left.value < right;
        public static bool operator >=(BChar left, short right) => left.value >= right;
        public static bool operator <=(BChar left, short right) => left.value <= right;
        public static bool operator ==(short left, BChar right) => left == right.value;
        public static bool operator !=(short left, BChar right) => left != right.value;
        public static bool operator >(short left, BChar right) => left > right.value;
        public static bool operator <(short left, BChar right) => left < right.value;
        public static bool operator >=(short left, BChar right) => left >= right.value;
        public static bool operator <=(short left, BChar right) => left <= right.value;
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

        internal static BDictionary<BChar, byte> WordToByte = new BDictionary<BChar, byte>(
            new BChar[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' },
            new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9});

        private short value;

        public BChar(char Value)
        {
            value = (byte)Value;
        }
        public BChar(short Value)
        {
            value = Value;
        }

        public int ToInt32()
        {
            return WordToByte[value];
        }

        public float ToFloat()
        {
            return WordToByte[value];
        }

        public double ToDouble()
        {
            return WordToByte[value];
        }

        public MathB.Irr32 ToIrr32()
        {
            return WordToByte[value];
        }

        public byte ToInt8()
        {
            return WordToByte[value];
        }

        public long ToInt64()
        {
            return WordToByte[value];
        }

        public short ToInt16()
        {
            return WordToByte[value];
        }

        public char ToChar()
        {
            return this;
        }

        public BInt ToBInt()
        {
            throw new System.NotImplementedException();
        }

        public bool ToBool()
        {
            if ((char)value == '0')
                return false;
            if ((char)value == '1')
                return true;
            throw null;
        }
    }
}