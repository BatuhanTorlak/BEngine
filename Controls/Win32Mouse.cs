using System.Runtime.InteropServices;

namespace BEngine.Controls
{
    internal static class Win32Mouse
    {
        [DllImport("user32.dll")]
        internal static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    }
}
