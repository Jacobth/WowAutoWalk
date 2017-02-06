using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WoWObjMgr
{
    class Keyboard
    {

        private Process p;

        private const UInt32 WM_KEYDOWN = 0x0100;
        private const UInt32 WM_KEYUP = 0x0101;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public enum Keys : int
        {
            VK_F5 = 0x74,
            VK_SPACE = 0x20,
            VK_LEFT = 0x25,
            VK_RIGHT = 0x27,
            VK_UP = 0x26,
            VK_DOWN = 0x28,
            VK_X = 0x58,
            VK_RBUTTON = 0x2,
            VK_LBUTTON = 0x1,
            VK_J = 0x4A,
            VK_0 = 0x30,
            VK_1 = 0x31,
            VK_2 = 0x32,
            VK_3 = 0x33,
            VK_4 = 0x34,
            VK_5 = 0x35,
            VK_TAB = 0x09,
        }

        public Keyboard()
        {
            Process[] processList = Process.GetProcessesByName("wow");
            p = processList[0];
        }

        public void KeyDown(int key)
        {
            PostMessage(p.MainWindowHandle, WM_KEYDOWN, key, 0);
        }

        public void KeyUp(int key)
        {
            PostMessage(p.MainWindowHandle, WM_KEYUP, key, 0);
        }

    }
}
