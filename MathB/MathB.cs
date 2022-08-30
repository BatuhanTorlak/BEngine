#define MATHB

using BEngine.Vectors;
using BEngine.List;
using System;

namespace BEngine.MathB
{
    public static class MathB
    {
        public static readonly float PI = 3.1415927f;

        /// <summary>
        /// Least Common Floor
        /// </summary>
        public static int Locom32(int x, int y)
        {
            if (x == 0 | y == 0)
                return 0;
            if (x == 1)
                return y;
            if (y == 1)
                return x;
            var Bolens = new BList<int>();

            bool Bulunamadi = false;

            while (true)
            {
                for (var i = 2; i < int.MaxValue; i++)
                {
                    if (x % i == 0 && y % i == 0)
                    {
                        Bolens.Add(i);
                        x /= i;
                        y /= i;
                        break;
                    }
                    if (i > x || i > y)
                    {
                        Bulunamadi = true;
                        break;
                    }
                }
                if (Bulunamadi)
                    break;
            }

            var u = 1;
            foreach (var z in Bolens.ToArray())
                u *= z;

            u *= x;
            u *= y;

            return u;
        }

        /// <summary>
        /// Greatest Common Divisor
        /// </summary>
        public static int Grcodi32(int x, int y)
        {
            if (x == 0 | y == 0)
                return 0;
            if (x == 1 | y == 1)
                return 1;
            var Bolens = new BList<int>();

            bool Bulunamadi = false;

            while (true)
            {
                for (var i = 2; i < int.MaxValue; i++)
                {
                    if (x % i == 0 && y % i == 0)
                    {
                        Bolens.Add(i);
                        x /= i;
                        y /= i;
                        break;
                    }
                    if (i > x || i > y)
                    {
                        Bulunamadi = true;
                        break;
                    }
                }
                if (Bulunamadi)
                    break;
            }

            var u = 1;
            foreach (var z in Bolens.ToArray())
                u *= z;

            return u;
        }

        public static float Pow(float num, int pow)
        {
            if (pow == 0)
                return 1;

            var i = 1f;
            while (pow > 0)
            {
                i *= num;
                pow--;
            }
            return i;
        }

        public static int Pow(int num, int pow)
        {
            if (pow == 0)
                return 1;

            var i = 1;
            while (pow > 0)
            {
                i *= num;
                pow--;
            }
            return i;
        }

        public static Vector3 Pow(Vector3 v, int pow)
        {
            if (pow == 0)
                new Vector3(1, 1, 1);

            var i = new Vector3(1, 1, 1);
            while (0 < pow)
            {
                i.x *= v.x;
                i.y *= v.y;
                i.z *= v.z;
                pow--;
            }
            return i;
        }

        public static Vector2 Pow(Vector2 v, int pow)
        {
            if (pow == 0)
                new Vector2(1, 1);

            var i = new Vector2(1, 1);
            while (0 < pow)
            {
                i.x *= v.x;
                i.y *= v.y;
                pow--;
            }
            return i;
        }

        public static Vector3 RotateDegree(Vector3 Center, Vector3 Pos, Vector2 degree)
        {
            var NewPos = Center - Pos;

            float d = NewPos.Distance();

            degree.x %= 360;
            degree.y %= 360;

            Radian Alpha = MathF.Atan2(NewPos.z, NewPos.x) + DegreeToRadian(degree.x);
            Radian Beta = MathF.Atan2(NewPos.y, Sqrt(Pow(NewPos.x, 2) + Pow(NewPos.z, 2))) + DegreeToRadian(degree.y);

            return Center + new Vector3(d * Sin(Alpha) * Cos(Beta), d * Sin(Beta), d * Cos(Alpha) * Cos(Beta));
        }

        public static Vector3 RotateDegree(Vector3 Pos, Vector2 degree)
        {
            float d = Pos.Distance();

            degree.x %= 360;
            degree.y %= 360;

            Radian Alpha = MathF.Atan2(Pos.z, Pos.x) + DegreeToRadian(degree.x);
            Radian Beta = MathF.Atan2(Pos.y, Sqrt(Pow(Pos.x, 2) + Pow(Pos.z, 2))) + DegreeToRadian(degree.y);

            return new Vector3(d * Sin(Alpha) * Cos(Beta), d * Sin(Beta), d * Cos(Alpha) * Cos(Beta));
        }

        public static Vector2 RotateDegree(Vector2 Center, Vector2 Pos, float degree)
        {
            Vector2 NewPos = Pos - Center;
            float D = NewPos.Distance();

            degree %= 360;

            Radian Alpha = MathF.Atan2(NewPos.y, NewPos.x) + DegreeToRadian(degree);

            return Center + new Vector2(D * Cos(Alpha), D * Sin(Alpha));
        }

        public static Vector2 RotateDegree(Vector2 Pos, float degree)
        {
            float D = Pos.Distance();

            degree %= 360;

            Radian Alpha = MathF.Atan2(Pos.y, Pos.x) + DegreeToRadian(degree);

            return new Vector2(D * Cos(Alpha), D * Sin(Alpha));
        }

        public static Vector2 RotateRadian(Vector2 Center, Vector2 Pos, float radian)
        {
            Vector2 NewPos = Pos - Center;
            float D = NewPos.Distance();

            radian %= 2 * PI;

            Radian Alpha = MathF.Atan2(NewPos.y, NewPos.x) + radian;

            return Center + new Vector2(D * Cos(Alpha), D * Sin(Alpha));
        }

        public static Vector2 RotateRadian(Vector2 Pos, float radian)
        {
            float D = Pos.Distance();

            radian %= 2 * PI;

            Radian Alpha = MathF.Atan2(Pos.y, Pos.x) + radian;

            return new Vector2(D * Cos(Alpha), D * Sin(Alpha));
        }

        public static Vector3 Abs(Vector3 v1) => new Vector3(Abs(v1.x), Abs(v1.y), Abs(v1.z));

        public static Vector2 Abs(Vector2 v1) => new Vector2(Abs(v1.x), Abs(v1.y));

        public static Irr32 Pow(Irr32 num, int pow)
        {
            if (pow == 0)
                return new Irr32(1, 1);

            var i = num;
            for (var x = 0; x < pow - 1; x++)
            {
                i *= num;
            }
            return i;
        }

        public static float Abs(float num)
        {
            if (num < 0)
                return -num;
            return num;
        }

        public static float Scale(float num, float min, float max, float newMin, float newMax) => num * ((newMax - newMin) / (max - min));
        public static int Scale(int num, int min, int max, int newMin, int newMax) => ((newMax - newMin) / (max - min));

        public static float DegreeToRadian(float degree) => degree * PI / 180;

        public static float RadianToDegree(float radian) => radian * 180 / PI;

        public static float Factorial(float num)
        {
            var x = num;

            num--;

            while(num > 0)
            {
                x *= num;
                num--;
            }

            return x;
        }

        public static float Sin(float radian)
        {
            if (radian == PI * 0.5 | radian == PI * 1.5f)
                return 1;
            if (radian == 0 | radian == PI | radian == PI * 2)
                return 0;
            double sin = radian;

            for (var x = 1; x < 15; x++)
            {
                if (x % 2 == 0)
                {
                    sin += Pow(radian, 1 + (x * 2)) / Factorial(1 + (x * 2));
                }
                else
                {
                    sin -= Pow(radian, 1 + (x * 2)) / Factorial(1 + (x * 2));
                }
            }

            return (float)sin;
        }
        public static float Cos(float radian)
        {
            if (radian == PI * 0.5 | radian == PI * 1.5f)
                return 0;
            if (radian == 0 | radian == PI)
                return 1;
            var cos = 1.0;

            for (var x = 1; x < 15; x++)
            {
                if (x % 2 == 0)
                {
                    cos += Pow(radian, x * 2) / Factorial(x * 2);
                }
                else
                {
                    cos -= Pow(radian, x * 2) / Factorial(x * 2);
                }
            }

            return (float)cos;
        }
        public static float Tan(float radian) => Sin(radian) / Cos(radian);

        public static float SinDegree(float degree) => Sin(DegreeToRadian(degree));
        public static float CosDegree(float degree) => Cos(DegreeToRadian(degree));
        public static float TanDegree(float degree) => Tan(DegreeToRadian(degree));

        public static float Summation(float start, float end, BActionOut<float, float> operation)
        {
            float num = 0;

            if (start < end)
                while (start < end)
                {
                    num += operation(start);
                    start++;
                }
            else
                while (start > end)
                {
                    num += operation(start);
                    start--;
                }

            return num;
        }

        public static float Multiplication(float start, float end, BActionOut<float, float> operation)
        {
            float num = 1;

            if (start < end)
                while (start < end)
                {
                    num *= operation(start);
                    start++;
                }
            else
                while (start > end)
                {
                    num *= operation(start);
                    start--;
                }

            return num;
        }

        public static float Sqrt(float num)
        {
            return BabylonianSqrt(num, 5);
        }

        public static float BabylonianSqrt(float num, int n)
        {
            return BabylonianSqrtMethod(num, SqrtInt((int)num), n);
        }

        public static float BabylonianSqrtMethod(float num, float closeNum, int n)
        {
            double x = closeNum;
            for (var i = 0; i < n; i++)
            {
                x = .5f * (x + (num / x));
            }
            return (float)x;
        }

        public static int SqrtInt(int num)
        {
            long x = num;
            long c = 0;
            long d = 1 << 30;
            while (d > num)
                d >>= 2;
            while (d != 0)
            {
                if (x >= c + d)
                {
                    x -= c + d;
                    c = (c >> 1) + d;
                }
                else
                    c >>= 1;
                d >>= 2;
            }
            return (int)c;
        }

        public static float Center(float start, float end)
        {
            return start + ((end - start) / 2);
        }

        public static int Center(int start, int end)
        {
            return start + ((end - start) / 2);
        }

        public static Irr32 Sqrt(Irr32 num) => new Irr32(Sqrt(num.Upper), Sqrt(num.Downer));

        public static Irr32 Abs(Irr32 num)
        {
            if (num < 0)
                return -num;
            return num;
        }
    }
}
