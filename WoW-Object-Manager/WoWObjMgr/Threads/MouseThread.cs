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
                MouseClick.LeftMouseRelease();
            }
            finally
            {
            }

        }
    }
}
