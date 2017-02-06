using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;

namespace WoWObjMgr
{
    class Travel
    {       
        private ZoneLists zones;
        private Container cont;
        private Keyboard keyboard;      

        public Travel()
        {
            zones = new ZoneLists();
            cont = new Container();
            keyboard = new Keyboard();
        }
      
        [STAThread]
        public void TravelFly(string city) {

            float Min_Distance = 100;
            float Rotation = 0.05f;

            Cities c = cont.getCity(city);
               
            FixPitch();    
                
            Lift(c.getZ());

            float Current = MoveToPoint(new Point(c.getX(), c.getY()), Min_Distance, Rotation);
            
            if(Current > Min_Distance)
            {
                MoveToPoint(new Point(c.getX(), c.getY()), Min_Distance, Rotation);
            }
                                                                          
        }

        //Calculate the distance between the target and the character
        public float GetDistance(Point p1, Point p2)
        {
            Point p3 = new Point(p1.getX(), p2.getY());

            float a = p1.getY() - p3.getY();
            float b = p2.getX() - p3.getX();

            float distance = (float)Math.Sqrt((a*a) + (b*b));

            return Math.Abs(distance);
        }

        //Move the target up in the air along the Z-axis
        public void Lift(float z)
        {
            keyboard.KeyDown((int)Keyboard.Keys.VK_SPACE);

            while (GameInfo.GetPlayerZ() < z)
            {

            }

            keyboard.KeyUp((int)Keyboard.Keys.VK_SPACE);
        }

        //Land on the ground and dismount
        public void Land(float z)
        {
            keyboard.KeyDown((int)Keyboard.Keys.VK_X);

            while (GameInfo.GetPlayerZ() > z + 10f)
            {      
            }

            keyboard.KeyUp((int)Keyboard.Keys.VK_X);

            keyboard.KeyDown((int)Keyboard.Keys.VK_0);
            Thread.Sleep(1);
            keyboard.KeyUp((int)Keyboard.Keys.VK_0);
        }

        //Rotate the character to point towards the target
        public void Rotate(float a, float b, float c, Point p1, Point p2, float diff)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            float angle = (float)Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));            

            float Pi = (float)Math.PI;
            float rotation = 0;

            float rot = GameInfo.GetPlayerRot();

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
                keyboard.KeyDown((int)Keyboard.Keys.VK_LEFT);
                Thread.Sleep(10);
                keyboard.KeyUp((int)Keyboard.Keys.VK_LEFT);

                rot = GameInfo.GetPlayerRot();
            }
        }

        //Adjust the pitch of the character before flying
        public void FixPitch()
        {
            keyboard.KeyDown((int)Keyboard.Keys.VK_SPACE);
            Thread.Sleep(1000);
            keyboard.KeyUp((int)Keyboard.Keys.VK_SPACE);

            keyboard.KeyDown((int)Keyboard.Keys.VK_X);
            Thread.Sleep(1200);
            keyboard.KeyUp((int)Keyboard.Keys.VK_X);

            Thread.Sleep(1000); 
        }

        //Helper method for capturing coordinates data
        private void Capture()
        {
            while (true)
            {
                Console.WriteLine("X: " + GameInfo.GetPlayerX() + " Y: " + GameInfo.GetPlayerY() + " Z: " + GameInfo.GetPlayerZ());
            }
        }

        //Move towards given point p
        [STAThread]
        public float MoveToPoint(Point p, float Max_Distance, float rotate)
        {           
            float x = GameInfo.GetPlayerX();
            float y = GameInfo.GetPlayerY();

            Point p1 = new Point(x, y);
            Point p2 = new Point(p.getX(), p.getY());
            Point p3 = new Point(p1.getX(), p2.getY());

            Console.WriteLine("x1 :" + p1.getX() + " x2: " + p2.getX() + " y1: " + p1.getY() + " y2: " + p2.getY());

            float a = p1.getY() - p3.getY();
            float b = p2.getX() - p3.getX();
            float C = (float)Math.Sqrt((a * a) + (b * b));

            Rotate(a, b, C, p1, p2, rotate);

            float distance = GetDistance(p1, p2);
            float init_distance = distance;
            float prev = init_distance;
            //  int count = 1;

            keyboard.KeyDown((int)Keyboard.Keys.VK_UP);

            while (true)
            {
                x = GameInfo.GetPlayerX();
                y = GameInfo.GetPlayerY();

                p1 = new Point(x, y);
                p2 = new Point(p.getX(), p.getY());

                distance = GetDistance(p1, p2);

                if (prev < distance)
                {
                    keyboard.KeyUp((int)Keyboard.Keys.VK_UP);
                    return distance;
                }

                prev = distance;

                Console.WriteLine(distance);

                if (distance < Max_Distance)
                {
                    keyboard.KeyUp((int)Keyboard.Keys.VK_UP);
                    return distance;
                }

            }
        }

        //Walk to a given city from current destionation
        [STAThread]
        public void TravelWalk(string city, int end)
        {

            float rotate = 0.03f;

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
                MoveToPoint(zones.Dm[i], Max_Distance, rotate);              
            }
        }

        //Helper method to walk to the closes node in the road netwrok
        private int MoveToClosestNode()
        {
            float rotate = 0.03f;
            float min_distance = float.MaxValue;
            int index = -1;

            float x = GameInfo.GetPlayerX();
            float y = GameInfo.GetPlayerY();

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
            MoveToPoint(p, 5f, rotate);

            return index;
        }

        //Returns the position of your character
        public Point GetPlayerPosition()
        { 
            float x = GameInfo.GetPlayerX();
            float y = GameInfo.GetPlayerY();

            Point p = new Point(x, y);

            return p;
        }

        //Mount you character, set your mount on actionbar with keybind 0
        public void Mount()
        {
            keyboard.KeyDown((int)Keyboard.Keys.VK_0);
            Thread.Sleep(1);
            keyboard.KeyUp((int)Keyboard.Keys.VK_0);
            Thread.Sleep(2000);
        }
    }
}
