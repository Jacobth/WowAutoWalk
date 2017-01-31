using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace WoWObjMgr
{
    class Travel
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const UInt32 WM_KEYUP = 0x0101;

        const int VK_F5 = 0x74;
        const int VK_SPACE = 0x20;
        const int VK_LEFT = 0x25;
        const int VK_X = 0x58;

        private ZoneLists zones;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
        private Container cont;
        PlayerScan scan;

        public Travel()
        {
            zones = new ZoneLists();
            cont = new Container();
            scan = new PlayerScan();
        }

        static void Main(string[] args)
        {
        
            Travel t = new Travel();
            //t.Capture();
            t.TravelWalk("", 0);
            //t.TravelFly("Shattrath");
            //t.TravelFly("Dalaran");

        }

        [STAThread]
        public void TravelFly(string city) {

            float Min_Distance = 100;
            float Rotation = 0.05f;

            Cities c = cont.getCity(city);

            scan.Ping();
                  
            Process[] processList = Process.GetProcessesByName("wow");
            Process wow = processList[0];

            FixPitch(wow);    
                
            Lift(wow, c.getZ());

            float Current = MoveToPoint(new Point(c.getX(), c.getY()), Min_Distance, Rotation, wow);
            
            if(Current > Min_Distance)
            {
                MoveToPoint(new Point(c.getX(), c.getY()), Min_Distance, Rotation, wow);
            }
                                                                          
        }

        //Calculate the distance between the target and the character
        private float GetDistance(Point p1, Point p2)
        {
            Point p3 = new Point(p1.getX(), p2.getY());

            float a = p1.getY() - p3.getY();
            float b = p2.getX() - p3.getX();

            float distance = (float)Math.Sqrt((a*a) + (b*b));

            return Math.Abs(distance);
        }

        //Move the target up in the air along the Z-axis
        private void Lift(Process p, float z)
        {
            PostMessage(p.MainWindowHandle, WM_KEYDOWN, VK_SPACE, 0);

            while (scan.GetLocalPlayer().ZPos < z)
            {
                scan.Ping();
            }

            PostMessage(p.MainWindowHandle, WM_KEYUP, VK_SPACE, 0);
        }

        //Rotate the character to point towards the target
        private void Rotate(float a, float b, float c, Process p, Point p1, Point p2, float diff)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            float angle = (float)Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));            

            float Pi = (float)Math.PI;
            float rotation = 0;

            scan.Ping();

            float rot = scan.GetLocalTarget().Rotation;

            if(p1.getX() < p2.getX() && p1.getY() < p2.getY())
            {
                rotation = (Pi / 2) - angle;
                Console.WriteLine("in 1");
            }
            else if(p1.getX() < p2.getX() && p1.getY() > p2.getY())
            {
                rotation = Pi - ((Pi / 2) - angle);
                Console.WriteLine("in 2");
            }
            else if(p1.getX() > p2.getX() && p1.getY() > p2.getY())
            {
                rotation = Pi + (Pi/2) - angle;
                Console.WriteLine("in 3" + " angle: " + angle);
            }
            else
            {
                rotation = (3 * Pi / 2) + angle;
                Console.WriteLine("in 4");
            }

            while(Math.Abs(rot - rotation) > diff)
            {
               // Console.WriteLine(rotation + " difference: ");
                PostMessage(p.MainWindowHandle, WM_KEYDOWN, VK_LEFT, 0);
                Thread.Sleep(10);
                PostMessage(p.MainWindowHandle, WM_KEYUP, VK_LEFT, 0);

                scan.Ping();
                rot = scan.GetLocalPlayer().Rotation;
            }
        }

        //Adjust the pitch of the character before flying
        private void FixPitch(Process p)
        {
            PostMessage(p.MainWindowHandle, WM_KEYDOWN, VK_SPACE, 0);
            Thread.Sleep(1000);
            PostMessage(p.MainWindowHandle, WM_KEYUP, VK_SPACE, 0);

            PostMessage(p.MainWindowHandle, WM_KEYDOWN, VK_X, 0);
            Thread.Sleep(1200);
            PostMessage(p.MainWindowHandle, WM_KEYUP, VK_X, 0);

            Thread.Sleep(1000); 
        }

        //Helper method for capturing coordinates data
        private void Capture()
        {
            while (true)
            {
                scan.Ping();
                WowObject obj = scan.GetLocalPlayer();
                Console.WriteLine("X: " + obj.XPos + " Y: " + obj.YPos + " Z: " + obj.ZPos);
            }
        }

        //Move towards given point p
        [STAThread]
        private float MoveToPoint(Point p, float Max_Distance, float rotate, Process wow)
        {           

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            float x = obj.XPos;
            float y = obj.YPos;

            Point p1 = new Point(x, y);
            Point p2 = new Point(p.getX(), p.getY());
            Point p3 = new Point(p1.getX(), p2.getY());

            Console.WriteLine("x1 :" + p1.getX() + " x2: " + p2.getX() + " y1: " + p1.getY() + " y2: " + p2.getY());

            float a = p1.getY() - p3.getY();
            float b = p2.getX() - p3.getX();
            float C = (float)Math.Sqrt((a * a) + (b * b));

            Rotate(a, b, C, wow, p1, p2, rotate);

            float distance = GetDistance(p1, p2);
            float init_distance = distance;
            float prev = init_distance;
            //  int count = 1;

            PostMessage(wow.MainWindowHandle, WM_KEYDOWN, VK_F5, 0);

            while (true)
            {

                scan.Ping();
                obj = scan.GetLocalPlayer();

                x = obj.XPos;
                y = obj.YPos;

                p1 = new Point(x, y);
                p2 = new Point(p.getX(), p.getY());

                distance = GetDistance(p1, p2);

                if (prev < distance)
                {
                    PostMessage(wow.MainWindowHandle, WM_KEYUP, VK_F5, 0);
                    return distance;
                }

                prev = distance;

                Console.WriteLine(distance);

                if (distance < Max_Distance)
                {
                    PostMessage(wow.MainWindowHandle, WM_KEYUP, VK_F5, 0);
                    return distance;
                }

            }
        }

        //Walk to a given city from current destionation
        [STAThread]
        public void TravelWalk(string city, int end)
        {

            float rotate = 0.03f;

            Process[] processList = Process.GetProcessesByName("wow");
            Process wow = processList[0];

            int start = MoveToClosestNode();

            float Max_Distance = 5f;

            ZoneLists zones = new ZoneLists();

         //   Cities c = cont.getCity(city);
            List<int> path = zones.Dun_Morogh.shortest_path(start, end);
            path.Reverse();
            foreach (int i in path)
            {
                Console.WriteLine(i);
            }
                
            Thread.Sleep(500);


            foreach (int i in path)
            {

                MoveToPoint(zones.Dm[i], Max_Distance, rotate, wow);
                
            }
        }

        //Helper method to walk to the closes node in the road netwrok
        private int MoveToClosestNode()
        {
            float rotate = 0.03f;
            float min_distance = float.MaxValue;
            int index = -1;

            Process[] processList = Process.GetProcessesByName("wow");
            Process wow = processList[0];

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            float x = obj.XPos;
            float y = obj.YPos;

            Point p1 = new Point(x, y);

            for (int i = 0; i < zones.Dm.Count; i++) 
            {
                float distance = GetDistance(p1, zones.Dm[i]);

                if(distance < min_distance)
                {
                    min_distance = distance;
                    index = i;
                }
            }

            Point p = zones.Dm[index];
            MoveToPoint(p, 5f, rotate, wow);

            return index;
        }
    }
}
