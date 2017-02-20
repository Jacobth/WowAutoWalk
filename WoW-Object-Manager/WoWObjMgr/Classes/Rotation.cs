using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;

namespace WoWObjMgr.Classes
{
    abstract class Rotation
    {
        public abstract void Attack();

        public Travel t;
        public Keyboard keyboard;

        public Rotation()
        {
            t = new Travel();
            keyboard = new Keyboard();
        }

        public void Rotates()
        {
            float rotate = 0.09f;

            Point target = GameInfo.GetTargetPos();

            t.Rotate(target, rotate);
        }

        public void Target(float Min_Distance)
        {

            Travel t = new Travel();
            Keyboard keyboard = new Keyboard();

            if (GameInfo.GetTargetGuid() != 0)
            {
                float distance = t.GetDistance(GameInfo.GetPlayerPos(), GameInfo.GetTargetPos());
            }
            else
            {

                long count = 0;

                while (GameInfo.GetTargetGuid() == 0)
                {
                    keyboard.KeyDown((int)Keyboard.Keys.VK_LEFT);
                    Thread.Sleep(10);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_LEFT);

                    Thread.Sleep(1);

                    keyboard.KeyDown((int)Keyboard.Keys.VK_TAB);
                    Thread.Sleep(10);
                    keyboard.KeyUp((int)Keyboard.Keys.VK_TAB);

                    if (count > 100)
                    {
                        break;
                    }

                    count++;
                }
            }

        }
    }
}
