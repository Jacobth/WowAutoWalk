using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WoWObjMgr
{
    class JumpThread
    {
        [STAThread]
        public static void CallJump()
        {
            try
            {
                Console.WriteLine("Child thread starts");

                Keyboard keyboard = new Keyboard();

                while (true)
                {
                    int key = (int)Keyboard.Keys.VK_SPACE;

                    keyboard.KeyHold(key, 10);

                    Thread.Sleep(10000);
                }
            }

            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }

        }
    }
}
