using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr
{
    class ZoneLists
    {

        public ShortestPath Dun_Morogh = new ShortestPath();

        public List<Point> Dm = new List<Point>();
        public List<Point> Ew = new List<Point>();

        public ZoneLists()
        {
            init();
        }

        private void init()
        {
            //Dun Morogh
            //Path 1
            Dm.Add(new Point(-806.6632f, -5039.819f));  //0
            Dm.Add(new Point(-761.4087f, -5057.445f));  //1
            Dm.Add(new Point(-755.1614f, -5083.976f));  //2
            Dm.Add(new Point(-740.4354f, -5174.512f));  //3
            Dm.Add(new Point(-707.4255f, -5201.118f));  //4
            Dm.Add(new Point(-685f, -5213.607f));       //5
            Dm.Add(new Point(-616.655f, -5233.314f));   //6
            Dm.Add(new Point(-588f, -5241.403f));       //7
            Dm.Add(new Point(-561.2347f, -5243.811f));  //8
            Dm.Add(new Point(-511.3025f, -5249.823f));  //9
            Dm.Add(new Point(-494.4819f, -5260.757f));  //10
            Dm.Add(new Point(-520.171f, -5344.501f));  //11
            Dm.Add(new Point(-515.964f, -5409.126f));  //12
            Dm.Add(new Point(-535.5804f, -5486.84f));  //13
            Dm.Add(new Point(-495.5587f, -5528.292f));  //14
            Dm.Add(new Point(-477.8983f, -5550.292f));  //15
            Dm.Add(new Point(-482.9684f, -5602.179f));  //16

            Dun_Morogh.add_vertex(0, new Dictionary<int, int> { { 1, 1 } });
            Dun_Morogh.add_vertex(1, new Dictionary<int, int> { { 0, 1 }, { 2, 1 } });
            Dun_Morogh.add_vertex(2, new Dictionary<int, int> { { 1, 1 }, { 3, 1 } });
            Dun_Morogh.add_vertex(3, new Dictionary<int, int> { { 2, 1 }, { 4, 1 } });
            Dun_Morogh.add_vertex(4, new Dictionary<int, int> { { 3, 1 }, { 5, 1 } });
            Dun_Morogh.add_vertex(5, new Dictionary<int, int> { { 4, 1 }, { 6, 1 } });
            Dun_Morogh.add_vertex(6, new Dictionary<int, int> { { 5, 1 }, { 7, 1 } });
            Dun_Morogh.add_vertex(7, new Dictionary<int, int> { { 6, 1 }, { 8, 1 } });
            Dun_Morogh.add_vertex(8, new Dictionary<int, int> { { 7, 1 }, { 9, 1 } });
            Dun_Morogh.add_vertex(9, new Dictionary<int, int> { { 8, 1 }, { 10, 1 } });
            Dun_Morogh.add_vertex(10, new Dictionary<int, int> { { 9, 1 }, { 11, 1 } });
            Dun_Morogh.add_vertex(11, new Dictionary<int, int> { { 10, 1 }, { 12, 1 } });
            Dun_Morogh.add_vertex(12, new Dictionary<int, int> { { 11, 1 }, { 13, 1 } });
            Dun_Morogh.add_vertex(13, new Dictionary<int, int> { { 12, 1 }, { 14, 1 } });
            Dun_Morogh.add_vertex(14, new Dictionary<int, int> { { 13, 1 }, { 15, 1 } });
            Dun_Morogh.add_vertex(15, new Dictionary<int, int> { { 14, 1 }, { 16, 1 } });
            Dun_Morogh.add_vertex(16, new Dictionary<int, int> { { 15, 1 } });
        }

    }
}
