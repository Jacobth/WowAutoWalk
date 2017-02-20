using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WoWObjMgr
{
    class MouseClick
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void RightMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        public static void LeftMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public static void LeftMouseHold()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);                      
        }

        public static void LeftMouseRelease()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
    }   
}
