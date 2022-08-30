using System.Runtime.InteropServices;

namespace BEngine.Controls
{
    internal static class Win32Keyboard
    {
        [DllImport("user32.dll")]
        internal static extern short GetAsyncKeyState(int vKey);

        [DllImport("User32.dll")]
        internal static extern byte VkKeyScan(char ch);

        [DllImport("User32.dll")]
        internal static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    }
}
