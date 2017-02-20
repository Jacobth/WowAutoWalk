using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;

namespace WoWObjMgr.Classes
{
    class MageRotate : Rotation
    {
     
        private void MoveClose()
        {

        }

        [STAThread]
        public override void Attack()
        {
            float Min_Distance = 20f;

            if (t.GetDistance(GameInfo.GetPlayerPos(), GameInfo.GetTargetPos()) < Min_Distance)
            {

                if (GameInfo.GetTargetGuid() != 0)
                {
                    Rotates();
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
    }
}
