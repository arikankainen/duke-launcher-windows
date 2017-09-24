using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using HWND = System.IntPtr;

namespace Duke
{
    public static class OpenWindows
    {
        public static IDictionary<HWND, string> GetOpenWindows()
        {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void centerDOSBox(Control control)
        {
            foreach (KeyValuePair<IntPtr, string> window in GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                if (title.Contains("DOSBox 0.74"))
                {
                    RECT rct;
                    GetWindowRect(new HandleRef(control, handle), out rct);
                    int width = rct.Right - rct.Left;
                    int height = rct.Bottom - rct.Top;

                    Screen screen = Screen.FromControl(control);
                    int left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (width / 2));
                    int top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (height / 2));

                    MoveWindow(handle, left, top, width, height, true);
                }

            }



        }
    }
}
