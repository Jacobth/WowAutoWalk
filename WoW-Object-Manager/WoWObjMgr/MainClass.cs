using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WowAuto.Utilities;
using WoWObjMgr.Classes;
using WoWObjMgr.Getters;
using WoWObjMgr.Utilities;

namespace WoWObjMgr
{
    class MainClass
    {


        static void Main(string[] args)
        {
            ZoneInfo zoneInfo = new ZoneInfo();

            while (true)
            {
                string line;

                line = Console.ReadLine();
                string[] lines = line.Split(' ');
                string arg = lines[0];
                string op = "";

                if (lines.Count() == 0)
                {
                    Console.WriteLine("Error: Specify action");
                }

                else if(lines.Count() == 1)
                {
                    Console.WriteLine("Error: Specify arguments");
                }
            

                else
                {
                    op = lines[1];
                    Arguments(arg, op, zoneInfo);
                }

              

            }

          //  Mine m = new Mine();

            //MageRotation mage = new MageRotation();

         //   OreLists o = new OreLists();

            /*  while(true)
              {
                  Console.WriteLine(GameInfo.GetMapId() + " z: " + GameInfo.GetPlayerZ());
              }

           Thread.Sleep(3000);

            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 4,
                               Screen.PrimaryScreen.Bounds.Height / 4,
                               PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            int width = (int)(-Screen.PrimaryScreen.Bounds.Width * 0.9f);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        width,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
    
            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save("C:/Users/jacobth/World of Warcraft 3.3.5a/Screenshots/Screenshot.jpg", ImageFormat.Jpeg);
                                      
            Bitmap b = new Bitmap("C:/Users/jacobth/World of Warcraft 3.3.5a/Screenshots/WoWScrnShot_022517_150147.jpg");

            bool tmp = ImageColor.ContainsColor(bmpScreenshot, 233, 196, 66);
            Console.WriteLine(tmp);
            Thread.Sleep(100000);*/
            

        //    Travel t = new Travel();
            //mage.Attack();
           // t.Capture();
        //    t.TravelWalk("ironforge");
           // t.click();
           // t.TravelFly("Shattrath");
            //t.TravelFly("Dalaran");

        }

        private void Action(string s)
        {
            string[] op = s.Split(' ');
            string method = op[0];
            string flag = op[1];
        }

        private static void Arguments(string arg, string op, ZoneInfo info)
        {
            if (arg.Equals("mine") && op != "")
            {
                Mine m = new Mine();
                OreLists o = new OreLists();

                Rotation mage = new MageRotate();

                List<Point> ores = o.MineMap(op);

                int zone = o.MineZone(op);

                bool sameZone = zone == info.GetContinent(GameInfo.GetMapId());

                if (!sameZone)
                {
                    Console.WriteLine("Error: Ores in different continent");
                }

                else if (ores.Count > 0)
                {
                    m.GatherOres(ores, mage);
                }
            }

            else if (arg.Equals("walk"))
            {
                Travel t = new Travel();
                t.TravelWalk(op);
            }

            else if (arg.Equals("fly"))
            {

            }
        }

    }
}
