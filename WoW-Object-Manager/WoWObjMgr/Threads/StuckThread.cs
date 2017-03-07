using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;

namespace WoWObjMgr.Threads
{
    class StuckThread
    {

        private const int TIME = 6000;

        // mode = 0 lookin on z, mode >= 1 looking on x and y
        [STAThread]
        public static void CallStuck(int mode)
        {
            try
            {
                while (true)
                {
                    float z = GameInfo.GetPlayerZ();
                    float x = GameInfo.GetPlayerX();
                    float y = GameInfo.GetPlayerY();

                    Thread.Sleep(TIME);

                    if(mode == 0)
                    {
                        if(z == GameInfo.GetPlayerZ())
                        {
                            Travel.isMoving = false;
                        }
                    }

                    else
                    {
                        if(x == GameInfo.GetPlayerX() || y == GameInfo.GetPlayerY())
                        {
                            Travel.isMoving = false;
                        }
                    }
                }
            }

            catch (ThreadAbortException e)
            {
            }
            finally
            {
            }

        }
    }
}
