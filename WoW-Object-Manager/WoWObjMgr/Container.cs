using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class Container
    {
        private Cities Shattrath = new Cities(5439, -1732, 550, "Shattrath");
        private Cities Dalaran = new Cities(650, 5792, 980, "Dalaran");

        private Dictionary<string, Cities> map;

        public Container()
        {
            map = new Dictionary<string, Cities>();
            map[Shattrath.getName()] = Shattrath;
            map[Dalaran.getName()] = Dalaran;

        }

        public Cities getCity(string name)
        {
            return map[name];
        }

    }
}
