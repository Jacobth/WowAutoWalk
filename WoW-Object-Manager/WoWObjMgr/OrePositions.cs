using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class OrePositions
    {

        public List<Point> OutlandOres;

        public OrePositions()
        {
            fillLists();
        }

        private void fillLists()
        {
            OutlandOres = new List<Point>();

            //Nagrand
            OutlandOres.Add(new Point(6427.75f, -1880.515f, 37.4053f));
            OutlandOres.Add(new Point(6476.825f, -1748.166f, 45.89928f));
            OutlandOres.Add(new Point(6411.032f, -1623.202f, 34.971f));
            OutlandOres.Add(new Point(6453.191f, -1552.855f, 35.67427f));
            OutlandOres.Add(new Point(6618.571f, -1636.21f, -0.5192f));
            OutlandOres.Add(new Point(6852.32f, -1968.955f, -79.49852f));
            OutlandOres.Add(new Point(6808.592f, -1882.095f, -37.2595f));
            OutlandOres.Add(new Point(7107.062f, -1865.141f, -83.39046f));
            OutlandOres.Add(new Point(7203.014f, -1968.95f, -102.937f));
            OutlandOres.Add(new Point(7240.261f, -2071.73f, -44f));
            OutlandOres.Add(new Point(7230.927f, -2141.189f, -112.7287f));
            OutlandOres.Add(new Point(7161.482f, -2316.789f, -13f));
            OutlandOres.Add(new Point(6159.284f, -2279.569f, 59.979f));
            OutlandOres.Add(new Point(6202.004f, -2232.468f, 48.37498f));
            OutlandOres.Add(new Point(6191.431f, -2183.957f, 82f));
            OutlandOres.Add(new Point(6357.212f, -2158.899f, 44.5f));
            OutlandOres.Add(new Point(6355.891f, -2157.692f, 45f));
            OutlandOres.Add(new Point(6337.947f, -2040.822f, 52.4f));
            OutlandOres.Add(new Point(6123.702f, -2584.954f, 21.5f));
        }

    }
}
