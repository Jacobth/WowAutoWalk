using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;

namespace WoWObjMgr
{
    class MageRotation
    {

        private Travel t;
        private Keyboard keyboard;

        public MageRotation()
        {
            t = new Travel();
            keyboard = new Keyboard();
       }

        [STAThread]
        public void Attack()
        {

            float Min_Distance = 20f;

            if (t.GetDistance(GameInfo.GetPlayerPos(), GameInfo.GetTargetPos()) < Min_Distance) {
        
                if (GameInfo.GetTargetGuid() != 0)
                {
                    Rotate();
                }

                while (!GameInfo.IsTargetDead() && GameInfo.GetTargetGuid() != 0)
                {
                    //Cast arcane blast.
                    keyboard.KeyDown((int)Keyboard.Keys.VK_1);
                    Thread.Sleep(10);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_1);

                    Thread.Sleep(2500);

                }
            }
        }

        private void Target(float Min_Distance)
        {
  
            if (GameInfo.GetTargetGuid() != 0)
            {
                float distance = t.GetDistance(GameInfo.GetPlayerPos(), GameInfo.GetTargetPos());
            }
            else
            {

                long count = 0;

                  while(GameInfo.GetTargetGuid() == 0)
                  {
                    keyboard.KeyDown((int)Keyboard.Keys.VK_LEFT);
                    Thread.Sleep(10);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_LEFT);

                    Thread.Sleep(1);

                    keyboard.KeyDown((int)Keyboard.Keys.VK_TAB);
                    Thread.Sleep(10);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_TAB);

                    if(count > 100)
                    {
                        break;
                    }
                
                    count++;
                  }
            }

        }

        private void MoveClose()
        {

        }

        private void Rotate()
        {
            float rotate = 0.09f;

            float x = GameInfo.GetPlayerX();
            float y = GameInfo.GetPlayerY();

            Point p1 = new Point(x, y);
            Point p2 = GameInfo.GetTargetPos();
            Point p3 = new Point(p1.getX(), p2.getY());

            Console.WriteLine("x1 :" + p1.getX() + " x2: " + p2.getX() + " y1: " + p1.getY() + " y2: " + p2.getY());

            float a = p1.getY() - p3.getY();
            float b = p2.getX() - p3.getX();
            float C = (float)Math.Sqrt((a * a) + (b * b));

            t.Rotate(a, b, C, p1, p2, rotate);
        }

    }
}
