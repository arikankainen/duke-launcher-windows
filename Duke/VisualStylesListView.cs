using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;

namespace Duke
{
    class VisualStylesListView : System.Windows.Forms.ListView
    {

        // The ListView control has a flicker issue. The problem appears to be that the control's Update overload is improperly
        // implemented such that it acts like a Refresh. An Update should cause the control to redraw only its invalid regions
        // whereas a Refresh redraws the control’s entire client area. So if you were to change, say, the background color of one
        // item in the list then only that particular item should need to be repainted. Unfortunately, the ListView control seems
        // to be of a different opinion and wants to repaint its entire surface whenever you mess with a single item… even if the
        // item is not currently being displayed. So, anyways, you can easily suppress the flicker by rolling your own as follows:
        public VisualStylesListView()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        // this is for flicker issue too
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        // enable visual styles
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
                NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
        }
    }

    class NativeMethods
    {
        // enable visual styles listview
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        // enable listening messages (used to show old instance if new one is launched
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        public static readonly int WM_AK_TRACKCHANGED = RegisterWindowMessage("WM_AK_TRACKCHANGED");
        public static readonly int WM_AK_PAUSEPLAYER = RegisterWindowMessage("WM_AK_PAUSEPLAYER");
        public static readonly int WM_AK_PLAYPLAYER = RegisterWindowMessage("WM_AK_PLAYPLAYER");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

    }



}
