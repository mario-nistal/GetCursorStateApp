using System;
using System.Runtime.InteropServices;

namespace GetCursorState
{
    public static class GetCursorStateMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        public const int CURSOR_SHOWING = 0x00000001;

        // Predefined cursor types
        public const int IDC_ARROW = 32512;
        public const int IDC_IBEAM = 32513;
        public const int IDC_WAIT = 32514;
        public const int IDC_CROSS = 32515;
        public const int IDC_UPARROW = 32516;
        public const int IDC_SIZE = 32640;
        public const int IDC_ICON = 32641;
        public const int IDC_SIZENWSE = 32642;
        public const int IDC_SIZENESW = 32643;
        public const int IDC_SIZEWE = 32644;
        public const int IDC_SIZENS = 32645;
        public const int IDC_SIZEALL = 32646;
        public const int IDC_NO = 32648;
        public const int IDC_HAND = 32649;
        public const int IDC_APPSTARTING = 32650;
        public const int IDC_HELP = 32651;


        public static void CheckCursorType()
        {
            Console.WriteLine($"Cursor Type: {CheckCursorTypeString()}");
        }

        public static string CheckCursorTypeString()
        {
            CURSORINFO cursorInfo = new CURSORINFO();
            cursorInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

            if (GetCursorInfo(out cursorInfo))
            {
                if ((cursorInfo.flags & CURSOR_SHOWING) != 0)
                {
                    string cursorType = GetCursorType(cursorInfo.hCursor);
                    return cursorType;
                }
                else
                {
                    return "Cursor is not showing.";
                }
            }
            else
            {
                return "Failed to get cursor info, Check Access.";
            }
        }

        private static string GetCursorType(IntPtr hCursor)
        {
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_ARROW)) return "Arrow";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_IBEAM)) return "IBeam";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_WAIT)) return "Wait";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_CROSS)) return "Cross";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_UPARROW)) return "UpArrow";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZE)) return "Size";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_ICON)) return "Icon";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZENWSE)) return "SizeNWSE";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZENESW)) return "SizeNESW";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZEWE)) return "SizeWE";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZENS)) return "SizeNS";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_SIZEALL)) return "SizeAll";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_NO)) return "No";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_HAND)) return "Hand";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_APPSTARTING)) return "AppStarting";
            if (hCursor == LoadCursor(IntPtr.Zero, IDC_HELP)) return "Help";

            return "Unknown";
        }
    }
}
