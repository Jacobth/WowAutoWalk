using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr.Getters
{
    class ZoneLists
    {

        public ShortestPath Dun_Morogh = new ShortestPath();
        public ShortestPath Eversong_Woods = new ShortestPath();

        public List<Point> Dm = new List<Point>();
        public List<Point> Ew = new List<Point>();

        public Dictionary<string, int> Dun_Morogh_Map = new Dictionary<string, int>();

        public Dictionary<string, ShortestPath> pathList = new Dictionary<string, ShortestPath>();
        public Dictionary<string, List<Point>> pointList = new Dictionary<string, List<Point>>();

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
            Dm.Add(new Point(-513f, -5752f));  //17
            Dm.Add(new Point(-510f, -5834f));  //18
            Dm.Add(new Point(-470f, -5910f));  //19
            Dm.Add(new Point(-407f, -5966f));  //20
            Dm.Add(new Point(-349f, -5996f));  //21
            Dm.Add(new Point(-260f, -6012f));  //22
            Dm.Add(new Point(-99f, -5951f));  //23
            Dm.Add(new Point(-52f, -5927f));  //24
            Dm.Add(new Point(-34f, -5907f));  //25

            Dun_Morogh_Map.Add("ironforge", 0);
           // Dun_Morogh_Map.Add("");

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
            Dun_Morogh.add_vertex(16, new Dictionary<int, int> { { 15, 1 }, { 17, 1 } });
            Dun_Morogh.add_vertex(17, new Dictionary<int, int> { { 16, 1 }, { 18, 1 } });
            Dun_Morogh.add_vertex(18, new Dictionary<int, int> { { 17, 1 }, { 19, 1 } });
            Dun_Morogh.add_vertex(19, new Dictionary<int, int> { { 18, 1 }, { 20, 1 } });
            Dun_Morogh.add_vertex(20, new Dictionary<int, int> { { 19, 1 }, { 21, 1 } });
            Dun_Morogh.add_vertex(21, new Dictionary<int, int> { { 20, 1 }, { 22, 1 } });
            Dun_Morogh.add_vertex(22, new Dictionary<int, int> { { 21, 1 }, { 23, 1 } });
            Dun_Morogh.add_vertex(23, new Dictionary<int, int> { { 22, 1 }, { 24, 1 } });
            Dun_Morogh.add_vertex(24, new Dictionary<int, int> { { 23, 1 }, { 25, 1 } });

            //Sista
            Dun_Morogh.add_vertex(25, new Dictionary<int, int> { { 24, 1 } });

            //Eversong Woods
            Ew.Add(new Point(-6346.082f, 10350.8f));//0
            Ew.Add(new Point(-6329.172f, 10092.21f));//1
            Ew.Add(new Point(-6455.539f, 10007.71f));//2
            Ew.Add(new Point(-6516.314f, 9946.403f));//3
            Ew.Add(new Point(-6598f, 9788f));//4
            Ew.Add(new Point(-6731f, 9575f));//5

            Eversong_Woods.add_vertex(0, new Dictionary<int, int> { { 1, 1 } });
            Eversong_Woods.add_vertex(1, new Dictionary<int, int> { { 0, 1 }, { 2, 1 } });
            Eversong_Woods.add_vertex(2, new Dictionary<int, int> { { 1, 1 }, { 3, 1 } });
            Eversong_Woods.add_vertex(3, new Dictionary<int, int> { { 2, 1 }, { 4, 1 } });
            Eversong_Woods.add_vertex(4, new Dictionary<int, int> { { 3, 1 }, { 5, 1 } });
            Eversong_Woods.add_vertex(5, new Dictionary<int, int> { { 4, 1 } });
        }

    }
}
