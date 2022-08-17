using System;

namespace BEngine.MathB
{
    public struct Radian
    {
        public static Radian operator +(Radian left, Radian right) => new Radian(left.degree + right.degree);
        public static Radian operator -(Radian left, Radian right) => new Radian(left.degree - right.degree);
        public static Radian operator +(Radian left, float right) => new Radian(left.degree - right);
        public static Radian operator -(Radian left, float right) => new Radian(left.degree - right);
        public static Radian operator +(Radian left, Degree right) => left + right.ToRadian();
        public static Radian operator -(Radian left, Degree right) => left - right.ToRadian();
        public static implicit operator Radian(float degree) => new Radian(degree);
        public static implicit operator Radian(Degree degree) => degree.ToRadian();
        public static implicit operator float(Radian degree) => degree.degree;

        internal float _degree;
        public float degree
        {
            get
            {
                return _degree;
            }
            set
            {
                if (value < 0)
                {
                    var x = value % -(2 * MathB.PI);
                    _degree = (2 * MathB.PI) + x;
                    return;
                }

                if (value >= (2 * MathB.PI))
                {
                    _degree = value % (2 * MathB.PI);
                    return;
                }

                _degree = value;
            }
        }

        public Radian(float alpha)
        {
            _degree = 0;
            degree = alpha;
        }

        public float Sin() => MathB.Sin(degree);

        public float Cos() => MathB.Cos(degree);

        public float Tan() => MathB.Tan(degree);

        public Degree ToDegree() => new Degree(MathB.RadianToDegree(_degree));

        public override string ToString() => $"{_degree / MathB.PI}π Radian";
    }
}
