using System;

namespace BEngine.MathB
{
    public struct Degree
    {
        public static Degree operator +(Degree left, Degree right) => new Degree(left.degree + right.degree);
        public static Degree operator -(Degree left, Degree right) => new Degree(left.degree - right.degree);
        public static Degree operator +(Degree left, float right) => new Degree(left.degree - right);
        public static Degree operator -(Degree left, float right) => new Degree(left.degree - right);
        public static Degree operator +(Degree left, Radian right) => left + right.ToDegree();
        public static Degree operator -(Degree left, Radian right) => left - right.ToDegree();
        public static implicit operator Degree(float degree) => new Degree(degree);
        public static implicit operator Degree(Radian degree) => degree.ToDegree();
        public static implicit operator float(Degree degree) => degree.degree;

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
                    var x = value % -360;
                    _degree = 360 + x;
                    return;
                }

                if (value >= 360)
                {
                    _degree = value % 360;
                    return;
                }

                _degree = value;
            }
        }

        public Degree(float alpha)
        {
            _degree = 0;
            degree = alpha;
        }

        public float Sin() => MathB.SinDegree(degree);

        public float Cos() => MathB.CosDegree(degree);

        public float Tan() => MathB.TanDegree(degree);

        public Radian ToRadian() => new Radian(MathB.DegreeToRadian(_degree));

        public override string ToString() => $"{_degree}° Degree";
    }
}
