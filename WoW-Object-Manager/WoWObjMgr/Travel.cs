using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WoWObjMgr.Getters;
using WoWObjMgr.Threads;

namespace WoWObjMgr
{
    class Travel
    {       
        private ZoneLists zones;
        private Container cont;
        private Keyboard keyboard;

        private const float DROP_DISTANCE = 8f;

        public static bool isMoving = true;

        public Travel()
        {
            zones = new ZoneLists();
            cont = new Container();
            keyboard = new Keyboard();
        }
      
        [STAThread]
        public void TravelFly(string city) {

            float Min_Distance = 50f;
            float Rotation = 0.05f;

            Cities c = cont.getCity(city);
               
            FixPitch();    
                
            Lift(c.getZ());

            float distance = 0;

            while (true)
            {
                distance = MoveToPoint(new Point(c.getX(), c.getY()), Min_Distance, Rotation);

                if (distance <= Min_Distance)
                {
                    break;
                }
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

            Thread t = new Thread(() => StuckThread.CallStuck(0));
            t.Start();

            while (GameInfo.GetPlayerZ() < z)
            {
                if(!isMoving) 
                {
                    isMoving = true;
                    t.Abort();      
                    break;
                }
            }

            t.Abort();

            keyboard.KeyUp((int)Keyboard.Keys.VK_SPACE);
        }

        //Land on the ground and dismount
        public void Land(float z)
        {
            keyboard.KeyDown((int)Keyboard.Keys.VK_X);

            Thread t = new Thread(() => StuckThread.CallStuck(0));
            t.Start();

            while (GameInfo.GetPlayerZ() > z + DROP_DISTANCE)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    t.Abort();
                    break;
                }
            }

            t.Abort();

            keyboard.KeyUp((int)Keyboard.Keys.VK_X);

            keyboard.KeyHold((int)Keyboard.Keys.VK_0, 1);

            Thread.Sleep(1500);
        }

        //Rotate the character to point towards the target
        public void Rotate(Point target, float diff)
        {

            Point p1 = GameInfo.GetPlayerPos();
            Point p3 = new Point(p1.getX(), target.getY());

            Console.WriteLine("x1 :" + p1.getX() + " x2: " + target.getX() + " y1: " + p1.getY() + " y2: " + target.getY() + " z1: " + p1.getZ() + " z2: " + target.getZ());

            float a = p1.getY() - p3.getY();
            float b = target.getX() - p3.getX();
            float c = (float)Math.Sqrt((a * a) + (b * b));

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            float angle = (float)Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));            

            float Pi = (float)Math.PI;
            float rotation = 0;
            int area = 0;

            float rot = GameInfo.GetPlayerRot();

            if(p1.getX() < target.getX() && p1.getY() < target.getY())
            {
                rotation = (Pi / 2) - angle;
                area = 1;
                Console.WriteLine("in 1");
            }
            else if(p1.getX() < target.getX() && p1.getY() > target.getY())
            {
                rotation = Pi - ((Pi / 2) - angle);
                area = 2;
                Console.WriteLine("in 2");
            }
            else if(p1.getX() > target.getX() && p1.getY() > target.getY())
            {
                rotation = Pi + (Pi/2) - angle;
                area = 3;
                Console.WriteLine("in 3" + " angle: " + angle);
            }
            else
            {
                rotation = (3 * Pi / 2) + angle;
                area = 4;
                Console.WriteLine("in 4");
            }

            int key = RotateDirection(rot, area);

            while(Math.Abs(rot - rotation) > diff)
            {
                keyboard.KeyHold(key, 10);

                rot = GameInfo.GetPlayerRot();
            }
        }

        /*Makes the roation more realistic, can turn 
        both right or left depending on whats closest
        to the desired angle.
        */
        private int RotateDirection(float rot, int target)
        {
            int key = -1;

            float Pi = (float)Math.PI;

            float first = 0;
            float second = Pi / 2;
            float third = Pi;
            float fourth = 3 * Pi / 2;

            int right = (int)Keyboard.Keys.VK_RIGHT;
            int left = (int)Keyboard.Keys.VK_LEFT;

            if (target != 0)
            {

                if(rot > first && rot < second)
                {
                    if(target < 4)
                    {
                        key = (int)Keyboard.Keys.VK_LEFT;
                    }
                    else
                    {
                        key = (int)Keyboard.Keys.VK_RIGHT;
                    }
                }

                else if(rot > second && rot < third)
                {
                    if(target == 1)
                    {
                        key = (int)Keyboard.Keys.VK_RIGHT;
                    }

                    else
                    {
                        key = (int)Keyboard.Keys.VK_LEFT;
                    }
                }

                else if(rot > third && rot < fourth)
                {
                    if(target == 2)
                    {
                        key = (int)Keyboard.Keys.VK_RIGHT;
                    }
                    else
                    {
                        key = (int)Keyboard.Keys.VK_LEFT;
                    }
                }

                else
                {
                    if(target == 3)
                    {
                        key = (int)Keyboard.Keys.VK_RIGHT;
                    }
                    else
                    {
                        key = (int)Keyboard.Keys.VK_LEFT;
                    }
                }

            }

            if(key == left)
            {
                Console.WriteLine("Left turn");
            }
            else
            {
                Console.WriteLine("Right turn");
            }

            return key;
        }

        //Adjust the pitch of the character before flying
        public void FixPitch()
        {
            keyboard.KeyHold((int)Keyboard.Keys.VK_SPACE, 500);
            keyboard.KeyHold((int)Keyboard.Keys.VK_X, 1000);

            Thread.Sleep(1000); 
        }

        //Helper method for capturing coordinates data
        public void Capture()
        {
            while (true)
            {
                Console.WriteLine("X: " + GameInfo.GetPlayerX() + " Y: " + GameInfo.GetPlayerY() + " Z: " + GameInfo.GetPlayerZ());
            }
        }

        //Move towards given point p
        [STAThread]
        public float MoveToPoint(Point target, float Max_Distance, float rotate)
        {          
            Rotate(target, rotate);

            Point currentPos = GameInfo.GetPlayerPos();

            float distance = GetDistance(currentPos, target);
            float init_distance = distance;
            float prev = init_distance;

            keyboard.KeyDown((int)Keyboard.Keys.VK_UP);

            Thread t = new Thread(() => StuckThread.CallStuck(1));
            t.Start();

            while (true)
            {               
                currentPos = GameInfo.GetPlayerPos();
                target = new Point(target.getX(), target.getY());

                distance = GetDistance(currentPos, target);

                if (prev < distance)
                {
                    keyboard.KeyUp((int)Keyboard.Keys.VK_UP);
                    t.Abort();
                    return distance;
                }

                prev = distance;

            //    Console.WriteLine(distance);

                if (distance < Max_Distance)
                {
                    keyboard.KeyUp((int)Keyboard.Keys.VK_UP);
                    t.Abort();
                    return distance;
                }

                if (!isMoving)
                {
                    isMoving = true;
                    t.Abort();
                    return -1;
                }
            }
        }

        //Walk to a given city from current destionation
        [STAThread]
        public void TravelWalk(string city)
        {

            ZoneLists zones = new ZoneLists();

            float rotate = 0.04f;

            int end = zones.Dun_Morogh_Map[city];
            int start = MoveToClosestNode(rotate);

            float Min_Distance = 2f;

         //   Cities c = cont.getCity(city);
            List<int> path = zones.Eversong_Woods.shortest_path(start, end);
            path.Reverse();

            foreach (int i in path)
            {
                Console.WriteLine(i);
            }
                
            Thread.Sleep(500);

            ThreadStart thread = new ThreadStart(JumpThread.CallJump);
            Thread cThread = new Thread(thread);
            cThread.Start();

            foreach (int i in path)
            {
                float distance = 0;

                while (true)
                {
                    distance = MoveToPoint(zones.Ew[i], Min_Distance, rotate);

                    if (distance <= Min_Distance)
                    {
                        break;
                    }
                }             
            }

            cThread.Abort();
        }

        //Helper method to walk to the closes node in the road netwrok
        private int MoveToClosestNode(float rotate)
        {
            ThreadStart thread = new ThreadStart(JumpThread.CallJump);
            Thread cThread = new Thread(thread);
            cThread.Start();

            float min_distance = float.MaxValue;
            int index = -1;

            Point p1 = GameInfo.GetPlayerPos();

            for (int i = 0; i < zones.Ew.Count; i++) 
            {
                float distance = GetDistance(p1, zones.Ew[i]);

                if(distance < min_distance)
                {
                    min_distance = distance;
                    index = i;
                }
            }

            Point p = zones.Ew[index];
            MoveToPoint(p, 5f, rotate);

            cThread.Abort();

            return index;
        }

        //Mount you character, set your mount on actionbar with keybind 0
        public void Mount()
        {
            keyboard.KeyClick((int)Keyboard.Keys.VK_0);      
            Thread.Sleep(2000);
        }

        public void click()
        {
            while (true)
            {
                keyboard.KeyHold((int)Keyboard.Keys.VK_1, 10);
                Thread.Sleep(300);
            }
        }
    }
}
