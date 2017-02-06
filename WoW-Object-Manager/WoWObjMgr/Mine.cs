using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WoWObjMgr.Getters;

namespace WoWObjMgr
{
    class Mine
    {

        private Keyboard keyboard;
        private OrePositions pos;

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
            pos = new OrePositions();

            gatherOutlandOres();
           // clickOre();
        }

        //Method to gather the ore, scan the screen until you hit the ore
        [STAThread]
        private void clickOre()
        {           
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            Console.WriteLine("width: " + width + " height: " + height);

            POINT p = new POINT();
            //Dual screen will affect this, if single screen remove + width
            p.x = Convert.ToInt16(width / 2 + width);
            p.y = Convert.ToInt16(height / 2);

            keyboard.KeyDown((int)Keyboard.Keys.VK_LBUTTON);
            Thread.Sleep(1);
            keyboard.KeyUp((int)Keyboard.Keys.VK_LBUTTON);

            for (int y = -200; y <= 200; y += 10)
            {
                for (int x = -200; x <= 200; x += 10)
                {
                    int xTmp = Convert.ToInt16(x);
                    int yTmp = Convert.ToInt16(y);

                    SetCursorPos(p.x + xTmp, p.y + yTmp);

                    Thread.Sleep(1);

                    keyboard.KeyDown((int)Keyboard.Keys.VK_J);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_J);
                }
            }
        }

        //Call this to gather all ores in outland
        public void gatherOutlandOres()
        {
            Travel t = new Travel();
            MageRotation m = new MageRotation();

            while (pos.OutlandOres.Count > 0)
            {

                float Max_Z = 550f;
                float Min_Distance = 2f;

                t.Mount();
                t.FixPitch();
                t.Lift(Max_Z);

                Point dest = getClosest(t);

                float distance = 0;

                while (true)
                {
                    distance = t.MoveToPoint(dest, Min_Distance, 0.05f);

                    if (distance <= Min_Distance)
                    {
                        break;
                    }
                }

                t.Land(dest.getZ());
              
                clickOre();

                Thread.Sleep(3000);
                Console.WriteLine(pos.OutlandOres.Count);

                m.Attack();
            }
        }

        //Helper method to get the closest ore to the player
        private Point getClosest(Travel t)
        {
            float Min_Distance = float.MaxValue;

            int index = -1;

            Point p = null;
            Point player = GameInfo.GetPlayerPos();

            for(int i = 0; i < pos.OutlandOres.Count; i++)
            {
                Point dest = pos.OutlandOres[i];
                float distance = t.GetDistance(player, dest);

                if(distance < Min_Distance)
                {
                    Min_Distance = distance;

                    p = dest;
                    index = i;
                }
            }

            pos.OutlandOres.RemoveAt(index);

            return p;
        }
    }
}
