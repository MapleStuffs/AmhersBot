using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Amherst
{
    internal class win32api
    {
        //IMPORT FUNCTIONS FOR MOVING WINDOW AROUND
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //import of findwindow function from the user32
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr hWndChildAfter, string className, string windowTitle);

        //regular findwindow
        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        //import of the postmessage function from user32
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        //wrapper for PostMessage that looks for errors
        public void PostMessageSafe(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            bool returnValue = PostMessage(hWnd, msg, wParam, lParam);
            /*if (!returnValue)
            {
                // An error occured
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }*/
        }

        public IntPtr FindAmherst(string windowName)
        {
            //initialize windowHandle
            IntPtr windowHandle = IntPtr.Zero;

            //find the windowhandle and return
            windowHandle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, string.Empty, windowName);

            //if still 0 try other method?
            if (windowHandle == IntPtr.Zero)
            {
                windowHandle = FindWindowByCaption(IntPtr.Zero, windowName);
            }

            return windowHandle;
        }
    }
}
