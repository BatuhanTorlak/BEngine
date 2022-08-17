using BEngine.Drawing;
using BEngine.Vectors;

namespace BEngine.Algorithms.MapAlgorithm
{
    public class MapPoint
    {
        internal int x;
        internal int y;
        public Color color;
        public MapPoint[] mapPoints;
        public Map map;

        public MapPoint(Map baseMap, MapPoint[] allowedMapPoints, Color pointColor)
        {
            map = baseMap;
            mapPoints = allowedMapPoints;
            color = pointColor;
        }
    }
}
