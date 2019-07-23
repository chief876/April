using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace April.Custom.CustomForms
{
    public class BalloonTip
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private IntPtr hWnd;
        private List<BalloonTip> balloons = new List<BalloonTip>();

        public void Show(string title, string text, Control control, ToolTipIcon icon, double showTime, int x = 0, int y = 0)
        {
            balloons.Add(this);
            if(x == 0 && y == 0)
            {
                x = (control.RectangleToScreen(control.ClientRectangle).Left + control.Width / 2);
                y = (control.RectangleToScreen(control.ClientRectangle).Top + control.Height / 2);
            }

            TOOLINFO toolInfo = new TOOLINFO();
            toolInfo.cbSize = (uint)Marshal.SizeOf(toolInfo);
            toolInfo.uFlags = 0x20; // TTF_TRACK
            toolInfo.lpszText = text;
            IntPtr pToolInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(toolInfo));
            Marshal.StructureToPtr(toolInfo, pToolInfo, false);
            byte[] buffer = Encoding.Default.GetBytes(title);
            buffer = buffer.Concat(new byte[] { 0 }).ToArray();
            IntPtr pszTitle = Marshal.AllocCoTaskMem(buffer.Length);
            Marshal.Copy(buffer, 0, pszTitle, buffer.Length);
            hWnd = User32.CreateWindowEx(0x8, "tooltips_class32", "", 0xC3, 0, 0, 0, 0, control.Parent.Handle, (IntPtr)0, (IntPtr)0, (IntPtr)0);
            User32.SendMessage(hWnd, 1028, (IntPtr)0, pToolInfo); // TTM_ADDTOOL
            User32.SendMessage(hWnd, 1042, (IntPtr)0, (IntPtr)(x | (y << 16))); // TTM_TRACKPOSITION
            User32.SendMessage(hWnd, 1056, (IntPtr)icon, pszTitle); // TTM_SETTITLE 0:None, 1:Info, 2:Warning, 3:Error, >3:assumed to be an hIcon. ; 1057 for Unicode
            User32.SendMessage(hWnd, 1048, (IntPtr)0, (IntPtr)500); // TTM_SETMAXTIPWIDTH
            User32.SendMessage(hWnd, 0x40c, (IntPtr)0, pToolInfo); // TTM_UPDATETIPTEXT; 0x439 for Unicode
            User32.SendMessage(hWnd, 1041, (IntPtr)1, pToolInfo); // TTM_TRACKACTIVATE
            Marshal.FreeCoTaskMem(pszTitle);
            Marshal.DestroyStructure(pToolInfo, typeof(TOOLINFO));
            Marshal.FreeCoTaskMem(pToolInfo);


            control.Enter += control_Event;
            control.Leave += control_Event;
            control.TextChanged += control_Event;
            control.KeyPress += control_Event;
            control.Click += control_Event;
            control.LocationChanged += control_Event;
            control.SizeChanged += control_Event;
            control.VisibleChanged += control_Event;
            if (control is DataGridView)
                ((DataGridView)control).CellBeginEdit += control_Event;
            Control parent = control.Parent;
            while (parent != null)
            {
                parent.VisibleChanged += control_Event;
                parent = parent.Parent;
            }
            control.TopLevelControl.LocationChanged += control_Event;
            ((Form)control.TopLevelControl).Deactivate += control_Event;
            timer.AutoReset = false;
            timer.Elapsed += timer_Elapsed;
            if (showTime > 0)
            {
                timer.Interval = showTime;
                timer.Start();
            }
        }


        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Close();
        }
        void control_Event(object sender, EventArgs e)
        {
            Close();
        }

        void Close()
        {
            if (!semaphore.Wait(0))
                return;
            balloons.Remove(this);
            timer.Elapsed -= timer_Elapsed;
            timer.Close();
            User32.SendMessage(hWnd, 0x0010, (IntPtr)0, (IntPtr)0); // WM_CLOSE
        }
        [StructLayout(LayoutKind.Sequential)]
        struct TOOLINFO
        {
            public uint cbSize;
            public uint uFlags;
            public IntPtr hwnd;
            public IntPtr uId;
            public RECT rect;
            public IntPtr hinst;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszText;
            public IntPtr lParam;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

    }

    public static class User32
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImportAttribute("user32.dll")]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr LPVOIDlpParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public int Width { get { return this.Right - this.Left; } }
            public int Height { get { return this.Bottom - this.Top; } }
        }
    }
}
