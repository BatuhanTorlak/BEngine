namespace BEngine.Vectors
{
    using MathB;
    public struct Vector2
    {
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
        public static Vector2 operator *(Vector2 v1, float n1) => new Vector2(v1.x * n1, v1.y * n1);
        public static Vector2 operator /(Vector2 v1, float n1) => new Vector2(v1.x / n1, v1.y / n1);
        public static Vector2 operator -(Vector2 v1) => new Vector2(-v1.x, -v1.y);
        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.x == v2.x) && (v1.y == v2.y);
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);
        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);
        public static explicit operator Vector2Int(Vector2 v) => new Vector2Int((int)v.x, (int)v.y);

        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(float x)
        {
            this.x = x;
            this.y = 0;
        }

        public Vector2(object? inp)
        {
            this.x = 0;
            this.y = 0;
        }

        public float Distance() => Distance(Zero(), this);

        public float Distance(Vector2 dest) => Distance(this, dest);

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            Vector2 v3 = v1 - v2;

            return MathB.Sqrt(v3.x * v3.x + v3.y * v3.y);
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x, y);
        }

        public Vector3 ToVector3(float z)
        {
            return new Vector3(x, y, z);
        }

        public Vector2 NotZero()
        {
            if (x == 0)
                x = float.Epsilon;
            if (y == 0)
                y = float.Epsilon;

            return this;
        }

        public static Vector2 Zero() => new Vector2(0, 0);

        public override string ToString() => $"Vector2({x}, {y})";

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
