namespace BEngine.Controls
{
    using Vectors;
    public static class Mouse
    {
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
    }
}
