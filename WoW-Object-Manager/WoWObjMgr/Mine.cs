using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WoWObjMgr.Classes;
using WoWObjMgr.Getters;
using WoWObjMgr.Threads;

namespace WoWObjMgr
{
    class Mine
    {

        private Keyboard keyboard;
        private OreLists pos;

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        public Mine()
        {
            keyboard = new Keyboard();
            pos = new OreLists();
       //     SetMiningView();
         //   ClickOre();
        }

        //Method to gather the ore, scan the screen until you hit the ore
        [STAThread]
        private void ClickOre()
        {           
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

        //    Console.WriteLine("width: " + width + " height: " + height);

            POINT p = new POINT();
            //Dual screen will affect this, if single screen remove + width
            p.x = Convert.ToInt16(width / 2 + width);
            p.y = Convert.ToInt16(height / 2);

      //      keyboard.KeyHold((int)Keyboard.Keys.VK_LBUTTON, 1);

            int range = height / 8;
            int inc = 30;

            for (int y = -range; y <= range; y += inc)
            {
                for (int x = -range; x <= range; x += inc)
                {
                    int xTmp = Convert.ToInt16(x);
                    int yTmp = Convert.ToInt16(y);

                    SetCursorPos(p.x + xTmp, p.y + yTmp);
                    Thread.Sleep(5);

                    //  keyboard.KeyHold((int)Keyboard.Keys.VK_RBUTTON, 0);
                    MouseClick.RightMouseClick();
                }
            }
            Thread.Sleep(2000);
        }

        //Call this to gather all ores in specified area
        public void GatherOres(List<Point> ores, Rotation rotation)
        {
            Travel t = new Travel();
            bool landed = true;

            while (ores.Count > 0)
            {
               
                float Min_Distance = 2f;

                if(landed)
                {
                    t.Mount();                  
                }
                landed = true;

                float Max_Z = 550f;
                t.Lift(Max_Z);

                Point dest = GetClosest(t, ores);
              
                float distance = 0;

                while (true)
                {
                    distance = t.MoveToPoint(dest, Min_Distance, 0.05f);

                    if (distance <= Min_Distance)
                    {
                        break;
                    }
                }

                landed = t.Land(dest.getZ());
              
                ClickOre();

                Thread.Sleep(3000);
                Console.WriteLine(ores.Count);

                rotation.Attack();
                ClickOre();
                Thread.Sleep(3000);
            }
        }

        //Helper method to get the closest ore to the player
        private Point GetClosest(Travel t, List<Point> ores)
        {
            float Min_Distance = float.MaxValue;

            int index = -1;

            Point p = null;
            Point player = GameInfo.GetPlayerPos();

            for(int i = 0; i < ores.Count; i++)
            {
                Point dest = ores[i];
                float distance = t.GetDistance(player, dest);

                if(distance < Min_Distance)
                {
                    Min_Distance = distance;

                    p = dest;
                    index = i;
                }
            }

            ores.RemoveAt(index);

            return p;
        }

        private void SetMiningView()
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            Console.WriteLine("width: " + width + " height: " + height);

            POINT p = new POINT();
            //Dual screen will affect this, if single screen remove + width
            p.x = Convert.ToInt16(width / 2 + width);
            p.y = Convert.ToInt16(height / 4);

            int range = height / 8;
            int inc = 5;

            ThreadStart thread = new ThreadStart(MouseThread.CallClick);
            Thread cThread = new Thread(thread);
            cThread.Start();

            for (int y = -range; y <= range; y += inc)
            {
                int yTmp = Convert.ToInt16(y);

                SetCursorPos(p.x, p.y + yTmp);
                Thread.Sleep(100);
            }

            cThread.Abort();
        }

        private float GetMaxZ(Point p)
        {
            if(p.getZ() > 600f)
            {
                return 1200f;
            }
            else
            {
                return 550f;
            }
        }
    }
}
