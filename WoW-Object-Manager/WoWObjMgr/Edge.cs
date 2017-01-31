using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class Edge
    {
        public int from;
        /** The destination vertix */
        public int to;

        /**
        * Since from and to are final, there values must be
        * given to the constructor.
        */
        public Edge(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        /**
        * Find the weight for this edge.
        * @return the found weight.
        */
        public double getWeight()
        {
            return 0;
        }


        // ========================================================
        // the rest is not really needed for the laboration but I added it to make 
        // the class more complete

        /** Get the source
        * @return The value of from
        */
        public int getSource()
        {
            return from;
        }

        /** Get the destination
        * @return The value of to
        */
        public int getDest()
        {
            return to;
        }
    }
}
