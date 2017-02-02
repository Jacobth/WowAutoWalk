using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class Point
    {
        private float x;
        private float y;
        private float z;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public float getZ()
        {
            return z;
        }

    }
}
