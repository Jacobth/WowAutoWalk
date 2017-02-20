using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WoWObjMgr.Threads
{
    class MouseThread
    {
        [STAThread]
        public static void CallClick()
        {
            try
            {
                Console.WriteLine("Child thread starts");
              
                while (true)
                {

                    Random rnd = new Random();
                    //   int time = rnd.Next(1, 2);

                    MouseClick.LeftMouseClick();

                  //  Thread.Sleep(2);
                }
            }

            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
                MouseClick.LeftMouseRelease();
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }

        }
    }
}
