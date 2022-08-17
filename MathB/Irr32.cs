namespace BEngine.MathB
{
    public struct Irr32 : IConvertible
    {
        public static Irr32 operator +(Irr32 num1, Irr32 num2) => new Irr32(((MathB.Locom32(num1.Downer, num2.Downer) / num1.Downer) * num1.Upper) + ((MathB.Locom32(num1.Downer, num2.Downer) / num2.Downer) * num2.Upper), MathB.Locom32(num1.Downer, num2.Downer));
        public static Irr32 operator -(Irr32 num1, Irr32 num2) => new Irr32(((MathB.Locom32(num1.Downer, num2.Downer) / num1.Downer) * num1.Upper) - ((MathB.Locom32(num1.Downer, num2.Downer) / num2.Downer) * num2.Upper), MathB.Locom32(num1.Downer, num2.Downer));
        public static Irr32 operator *(Irr32 num1, Irr32 num2) => new Irr32(num1.Upper * num2.Upper, num1.Downer * num2.Downer);
        public static Irr32 operator /(Irr32 num1, Irr32 num2) => new Irr32(num1.Upper * num2.Downer, num1.Downer * num2.Upper);
        public static Irr32 operator +(Irr32 num1, int num2) => num1 + new Irr32(num2);
        public static Irr32 operator -(Irr32 num1, int num2) => num1 - new Irr32(num2);
        public static Irr32 operator *(Irr32 num1, int num2) => num1 * new Irr32(num2);
        public static Irr32 operator /(Irr32 num1, int num2) => num1 / new Irr32(num2);
        public static Irr32 operator +(Irr32 num1, float num2) => num1 + new Irr32(num2);
        public static Irr32 operator -(Irr32 num1, float num2) => num1 - new Irr32(num2);
        public static Irr32 operator *(Irr32 num1, float num2) => num1 * new Irr32(num2);
        public static Irr32 operator /(Irr32 num1, float num2) => num1 / new Irr32(num2);
        public static Irr32 operator -(Irr32 num)
        {
            if(num.Upper < 0 | num.Downer < 0)
            {
                if (num.Upper < 0)
                    num.Upper = -num.Upper;
                if (num.Downer < 0)
                    num.Downer = -num.Downer;
            }
            else
            {
                num.Upper = -num.Upper;
            }
            return num;
        }
        public static bool operator ==(Irr32 num1, Irr32 num2)
        {
            var x = Simplification(num1);
            var z = Simplification(num2);

            return (x.Upper == z.Upper) && (x.Downer == z.Downer);
        }
        public static bool operator ==(Irr32 num1, float num2) => num1 == new Irr32(num2);
        public static bool operator !=(Irr32 num1, Irr32 num2) => !(num1 == num2);
        public static bool operator !=(Irr32 num1, float num2) => !(num1 == new Irr32(num2));
        public static bool operator >(Irr32 num1, float num2) => num1 > new Irr32(num2);
        public static bool operator <(Irr32 num1, float num2) => num1 < new Irr32(num2);
        public static bool operator >=(Irr32 num1, float num2) => num1 >= new Irr32(num2);
        public static bool operator <=(Irr32 num1, float num2) => num1 <= new Irr32(num2);
        public static bool operator >(Irr32 num1, Irr32 num2)
        {
            var x = num1 + new Irr32(0, num2.Downer);
            var y = num2 + new Irr32(0, num1.Downer);

            return x.Upper > y.Upper;
        }
        public static bool operator <(Irr32 num1, Irr32 num2)
        {
            var x = num1 + new Irr32(0, num2.Downer);
            var y = num2 + new Irr32(0, num1.Downer);

            return x.Upper < y.Upper;
        }
        public static bool operator >=(Irr32 num1, Irr32 num2) => !(num1 < num2);
        public static bool operator <=(Irr32 num1, Irr32 num2) => !(num1 > num2);
        public static bool operator ==(Irr32 num1, int num2) => num1 == new Irr32(num2);
        public static bool operator !=(Irr32 num1, int num2) => !(num1 == num2);
        public static bool operator >(Irr32 num1, int num2) => num1 > new Irr32(num2);
        public static bool operator <(Irr32 num1, int num2) => num1 < new Irr32(num2);
        public static bool operator >=(Irr32 num1, int num2) => num1 >= new Irr32(num2);
        public static bool operator <=(Irr32 num1, int num2) => num1 <= new Irr32(num2);
        public static implicit operator Irr32(int num) => new Irr32(num);
        public static implicit operator Irr32(float num) => new Irr32(num);
        public static implicit operator Irr32(string num) => new Irr32(num);
        public static implicit operator Irr32(BString num) => new Irr32(num.ToString());

        public int Upper;
        public int Downer;

        public Irr32(object? inp)
        {
            Upper = 1;
            Downer = 1;
        }
        public Irr32(BString num)
        {
            string[] i = Text.Cut(num, CutType.Ignore, '/');
            if (!num.Contains(','))
            {
                Upper = Convert.ToInt32(i[0]);
                Downer = Convert.ToInt32(i[1]);
                goto end;
            }
            var newNum = Convert.ToFloat(i[0]) / Convert.ToFloat(i[1]);
            string[] x = Text.Cut(newNum.ToString(), CutType.Ignore, ',');
            if (x.Length != 2)
            {
                Upper = Convert.ToInt32(x[0]);
                Downer = 1;
            }
            else
            {
                Upper = Convert.ToInt32(x[0] + x[1]);
                Downer = Convert.ToInt32(MathB.Pow(10, x[1].Length));
            }
        end:
            Simplification();
        }
        public Irr32(float num)
        {
            string[] i = Text.Cut(num.ToString(), CutType.Ignore, ',');

            if (i.Length != 2)
            {
                Upper = Convert.ToInt32(i[0]);
                Downer = 1;
            }
            else
            {
                Upper = Convert.ToInt32(i[0] + i[1]);
                Downer = Convert.ToInt32(MathB.Pow(10, i[1].Length));

                Simplification();
            }
        }
        public Irr32(int num1)
        {
            Upper = num1;
            Downer = 1;
        }
        public Irr32(int num1, int num2)
        {
            Upper = num1;
            Downer = num2;
        }
        public Irr32(float num1, float num2)
        {
            var num = num1 / num2;

            string[] i = Text.Cut(num.ToString(), CutType.Ignore, ',');

            if (i.Length != 2)
            {
                Upper = Convert.ToInt32(i[0]);
                Downer = 1;
            }
            else
            {
                Upper = Convert.ToInt32(i[0] + i[1]);
                Downer = Convert.ToInt32(MathB.Pow(10, i[1].Length));

                Simplification();
            }
        }

        public static Irr32 Simplification(Irr32 inpt)
        {
            if (inpt.Upper % inpt.Downer == 0)
                return new Irr32(inpt.Upper / inpt.Downer);

            var i = MathB.Grcodi32(inpt.Upper, inpt.Downer);

            if (i != 1)
                return new Irr32(inpt.Upper / i, inpt.Downer / i);

            return inpt;
        }

        public Irr32 Simplification()
        {
            this = Simplification(this);
            return this;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public float ToFloat() => ToSingle();

        public Irr32 ToIrr32() => this;

        public byte ToInt8() => (byte)ToInt32();

        public long ToInt64() => (long)Upper / (long)Downer;

        public char ToChar() => throw null;

        public int ToInt32() => Upper / Downer;

        public float ToSingle() => (float)Upper / (float)Downer;

        public double ToDouble() => (double)Upper / (double)Downer;

        public BInt ToBInt() => new BInt(ToInt64());

        public override string ToString() => $"{Upper}/{Downer}";

        public bool ToBool()
        {
            var x = ToIrr32();
            if (x == 1)
                return true;
            if (x == 0)
                return false;
            throw null;
        }
    }

}
