namespace BEngine.Vectors
{
    using MathB;
    public struct Vector2Int
    {
        public static Vector2Int operator +(Vector2Int v1, Vector2Int v2) => new Vector2Int(v1.x + v2.x, v1.y + v2.y);
        public static Vector2Int operator -(Vector2Int v1, Vector2Int v2) => new Vector2Int(v1.x - v2.x, v1.y - v2.y);
        public static Vector2Int operator *(Vector2Int v1, int n1) => new Vector2Int(v1.x * n1, v1.y * n1);
        public static Vector2Int operator /(Vector2Int v1, int n1) => new Vector2Int(v1.x / n1, v1.y / n1);
        public static Vector2Int operator -(Vector2Int v1) => new Vector2Int(-v1.x, -v1.y);
        public static bool operator ==(Vector2Int v1, Vector2Int v2) => (v1.x == v2.x) && (v1.y == v2.y);
        public static bool operator !=(Vector2Int v1, Vector2Int v2) => !(v1 == v2);
        public static implicit operator Vector2(Vector2Int vector2Int) => new Vector2(vector2Int.x, vector2Int.y);

        public int x;
        public int y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2Int(int x)
        {
            this.x = x;
            this.y = 0;
        }

        public Vector2Int(object? inp)
        {
            this.x = 0;
            this.y = 0;
        }

        public float Distance()
        {
            return Distance(Zero(), this);
        }

        public float Distance(Vector2Int dest)
        {
            return Distance(this, dest);
        }

        public static float Distance(Vector2Int v1, Vector2Int v2)
        {
            Vector2Int v3 = v1 - v2;

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

        public static Vector2Int Zero()
        {
            return new Vector2Int(0, 0);
        }

        public override string ToString()
        {
            return $"Vector2Int({x}, {y})";
        }

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
