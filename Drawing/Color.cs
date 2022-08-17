namespace BEngine.Drawing
{
    public struct Color
    {
        public static implicit operator System.Drawing.Color(Color color) => System.Drawing.Color.FromArgb(color.Transparancy, color.Red, color.Green, color.Blue);
        public static implicit operator Color(System.Drawing.Color color) => new Color(color.R, color.G, color.B, color.A);

        public byte Red { set; get; }
        public byte Green { set; get; }
        public byte Blue { set; get; }
        public byte Transparancy { set; get; }

        public static readonly Color white = new Color(255, 255, 255);
        public static readonly Color black = new Color(0, 0, 0);
        public static readonly Color red = new Color(255, 0, 0);
        public static readonly Color green = new Color(0, 255, 0);
        public static readonly Color blue = new Color(0, 0, 255);

        public Color(byte red)
        {
            Red = red;
            Green = 0;
            Blue = 0;
            Transparancy = byte.MaxValue;
        }

        public Color(byte red, byte green)
        {
            Red = red;
            Green = green;
            Blue = 0;
            Transparancy = byte.MaxValue;
        }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Transparancy = byte.MaxValue;
        }

        public Color(byte red, byte green, byte blue, byte transparancy)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Transparancy = transparancy;
        }
    }
}
