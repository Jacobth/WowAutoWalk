using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WoWObjMgr.Classes;
using WoWObjMgr.Getters;
using WoWObjMgr.Utilities;

namespace WoWObjMgr
{
    class MainClass
    {


        static void Main(string[] args)
        {

            Mine m = new Mine();

            //MageRotation mage = new MageRotation();

            OreLists o = new OreLists();

            /*  while(true)
              {
                  Console.WriteLine(GameInfo.GetMapId() + " z: " + GameInfo.GetPlayerZ());
              }*/

            Rotation mage = new MageRotate();

            m.GatherOres(o.GetFelIron(), mage);

        //    Travel t = new Travel();
            //mage.Attack();
           // t.Capture();
        //    t.TravelWalk("ironforge");
           // t.click();
           // t.TravelFly("Shattrath");
            //t.TravelFly("Dalaran");

        }

    }
}
