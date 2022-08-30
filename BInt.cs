using BEngine.MathB;

namespace BEngine
{
    using MathB;
    public struct BInt : IConvertible
    {
        public static implicit operator BInt(int value) => new BInt(value);
        public static implicit operator BInt(long value) => new BInt(value);
        public static explicit operator int(BInt value) => value.ToInt32();
        public static explicit operator long(BInt value) => value.ToInt64();
        public static implicit operator bool(BInt value) => value.ToBool();
        private bool IsNegative;
        private byte[] nums;

        public BInt(long num)
        {
            IsNegative = num < 0;
            num = (long)MathB.MathB.Abs(num);
            if (num < 255)
            {
                nums = new byte[] { (byte)num };
                return;
            }
            var size = num / 255;
            var i = num % 255;
            if (i > 0)
            {
                size++;
            }
            nums = new byte[size];
            for (var x = 0; x < size; x++)
            {
                nums[x] = 255;
            }
            if (i > 0)
                nums[size - 1] = (byte)i;
        }

        public BInt ToBInt() => this;

        public bool ToBool() => (nums[0] == 1) ? true : ((nums[0] == 0) ? false : throw null);

        public char ToChar() => (char)nums[0];

        public double ToDouble() => ToInt64() * (IsNegative ? -1 : 1);

        public float ToFloat() => ToInt32() * (IsNegative ? -1 : 1);

        public int ToInt32()
        {
            long x = 0;
            foreach (var i in nums)
            {
                x += i;
                if (x > int.MaxValue)
                    return int.MaxValue;
            }
            return (int)x * (IsNegative ? -1 : 1);
        }

        public long ToInt64()
        {
            long x = 0;
            foreach (var i in nums)
            {
                x += i;
                if (x > long.MaxValue)
                    return long.MaxValue;
            }
            return x * (IsNegative ? -1 : 1);
        }

        public byte ToInt8() => nums[0];

        public short ToInt16()
        {
            long x = 0;
            foreach (var i in nums)
            {
                x += i;
                if (x > short.MaxValue)
                    return short.MaxValue;
            }
            return (short)(x * (IsNegative ? -1 : 1));
        }

        public Irr32 ToIrr32() => ToInt32();

        public override string ToString() => ToInt64().ToString();

        public BString ToCharArray()
        {
            BString x = "";
            foreach (var i in nums)
                x += (char)i;
            return x;
        }
    }
}
