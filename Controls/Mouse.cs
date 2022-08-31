namespace BEngine.Controls
{
    using Vectors;
    public static class Mouse
    {
        public static Vector2Int Position
        {
            get => GetPosition();
            set => SetPosition(value);
        }
        public static int x
        {
            get => Position.x;
            set => Position = new Vector2Int(value, Position.y);
        }
        public static int y
        {
            get => Position.y;
            set => Position = new Vector2Int(Position.x, value);
        }

        public static void Click(int x = 0, int y = 0)
        {
            Win32Mouse.mouse_event(ControlVaruables.Mouse.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            Win32Mouse.mouse_event(ControlVaruables.Mouse.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void Click(Vector2Int pos)
        {
            Win32Mouse.mouse_event(ControlVaruables.Mouse.MOUSEEVENTF_LEFTDOWN, pos.x, pos.y, 0, 0);
            Win32Mouse.mouse_event(ControlVaruables.Mouse.MOUSEEVENTF_LEFTUP, pos.x, pos.y, 0, 0);
        }

        public static void SetPosition(int x = 0, int y = 0) => Win32Mouse.SetCursorPos(x, y);
        public static void SetPosition(Vector2Int pos) => Win32Mouse.SetCursorPos(pos.x, pos.y);

        public static Vector2Int GetPosition()
        {
            if (Win32Mouse.GetCursorPos(out Vector2Int pos))
            {
                return pos;
            }
            throw null;
        }
    }
}
