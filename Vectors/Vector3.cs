#define VECTORS

namespace BEngine.Vectors
{
    using MathB;
    public struct Vector3
    {
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        public static Vector3 operator *(Vector3 v1, float n1) => new Vector3(v1.x * n1, v1.y * n1, v1.z * n1);
        public static Vector3 operator /(Vector3 v1, float n1) => new Vector3(v1.x / n1, v1.y / n1, v1.z / n1);
        public static Vector3 operator -(Vector3 v1) => new Vector3(-v1.x, -v1.y, -v1.z);
        public static bool operator ==(Vector3 v1, Vector3 v2) => (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z);
        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);
        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y);

        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }

        public Vector3(float x)
        {
            this.x = x;
            this.y = 0;
            this.z = 0;
        }

        public float Distance() => Distance(Zero(), this);

        public float Distance(Vector3 dest) => Distance(this, dest);

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            Vector3 v3 = v1 - v2;

            return MathB.Sqrt(v3.x * v3.x + v3.y * v3.y + v3.z * v3.z);
        }

        public Vector2 ToVector2() => new Vector2(x, y);

        public static Vector3 Zero() => new Vector3(0, 0, 0);

        public static Vector3 Up() => new Vector3(0, 1, 0);
        public static Vector3 Down() => new Vector3(0, -1, 0);
        public static Vector3 Right() => new Vector3(1, 0, 0);
        public static Vector3 Left() => new Vector3(-1, 0, 0);
        public static Vector3 Forward() => new Vector3(0, 0, 1);
        public static Vector3 Back() => new Vector3(0, 0, -1);

        public override string ToString() => $"Vector3({x}, {y}, {z})";

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
