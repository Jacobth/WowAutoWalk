﻿using System;
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

            keyboard.KeyHold((int)Keyboard.Keys.VK_0, 1);
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
            int target = 0;

            float rot = GameInfo.GetPlayerRot();

            if(p1.getX() < p2.getX() && p1.getY() < p2.getY())
            {
                rotation = (Pi / 2) - angle;
                target = 1;
                Console.WriteLine("in 1");
            }
            else if(p1.getX() < p2.getX() && p1.getY() > p2.getY())
            {
                rotation = Pi - ((Pi / 2) - angle);
                target = 2;
                Console.WriteLine("in 2");
            }
            else if(p1.getX() > p2.getX() && p1.getY() > p2.getY())
            {
                rotation = Pi + (Pi/2) - angle;
                target = 3;
                Console.WriteLine("in 3" + " angle: " + angle);
            }
            else
            {
                rotation = (3 * Pi / 2) + angle;
                target = 4;
                Console.WriteLine("in 4");
            }

            int key = RotateDirection(rot, target);

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

            if(target != 0)
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

            return key;
        }

        //Adjust the pitch of the character before flying
        public void FixPitch()
        {
            keyboard.KeyHold((int)Keyboard.Keys.VK_SPACE, 700);
            keyboard.KeyHold((int)Keyboard.Keys.VK_X, 1200);

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

            float rotate = 0.08f;

            int start = MoveToClosestNode();

            float Min_Distance = 2f;

            ZoneLists zones = new ZoneLists();

         //   Cities c = cont.getCity(city);
            List<int> path = zones.Dun_Morogh.shortest_path(start, end);
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
                    distance = MoveToPoint(zones.Dm[i], Min_Distance, rotate);

                    if (distance <= Min_Distance)
                    {
                        break;
                    }
                }             
            }

            cThread.Abort();
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

        //Mount you character, set your mount on actionbar with keybind 0
        public void Mount()
        {
            keyboard.KeyClick((int)Keyboard.Keys.VK_0);      
            Thread.Sleep(2000);
        }
    }
}
