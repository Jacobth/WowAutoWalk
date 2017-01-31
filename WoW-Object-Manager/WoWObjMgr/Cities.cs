using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class Cities
    {
        private float x;
        private float y;
        private float z;
        private string name;

        public Cities(float x, float y, float z, string name)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.name = name;
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

        public string getName()
        {
            return name;
        }

    }
}
