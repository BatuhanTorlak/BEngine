namespace BEngine.Drawing
{
    using List;

    public class BMap
    {
        private Color[,] map;
        public Color[,] Map { get => map; }

        private int _width;
        private int _height;
        public int Width { get => _width; set => Resize(value, _height); }
        public int Height { get => _height; set => Resize(_width, value); }
        
        Color this[int x, int y]
        {
            get => map[x, y];
            set => map[x, y] = value;
        }

        public BMap(int width, int height)
        {
            map = new Color[width, height];
            _width = width;
            _height = height;
            Fill(Color.white);
        }
        public BMap(Vectors.Vector2Int size)
        {
            map = new Color[size.x, size.y];
            _width = size.x;
            _height = size.y;
            Fill(Color.white);
        }

        public BMap(Vectors.Vector2 size)
        {
            _width = (int)size.x;
            _height = (int)size.y;
            map = new Color[_width, _height];
            Fill(Color.white);
        }

        public void Fill(Color color)
        {
            for (var y = 0; y < _width; y++)
            {
                for (var x = 0; x < _height; x++)
                {
                    map[x, y] = color;
                }
            }
        }

        public void ReFill(Color color, params Color[] colors)
        {
            BList<Color> clrs = colors;
            for (var y = 0; y < _width; y++)
            {
                for (var x = 0; x < _height; x++)
                {
                    if (clrs.Contains(map[x, y]))
                        map[x, y] = color;
                }
            }
        }

        public void Resize(int width, int height)
        {
            Color[,] newMap = new Color[width, height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (x < _width & y < _height)
                    {
                        newMap[x, y] = map[x, y];
                        continue;
                    }
                    newMap[x, y] = new Color(255, 255, 255);
                }
            }
        }
    }
}
