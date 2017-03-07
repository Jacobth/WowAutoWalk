using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoWObjMgr.Utilities;

namespace WoWObjMgr.Getters
{
    class OreLists
    {
        public List<Point> GetCobalt()
        {
            List<Point> list = FileReader.ReadFile("cobalt.txt");

            return list;
        }

        public List<Point> GetRichCobalt()
        {
            List<Point> list = FileReader.ReadFile("rich_cobalt.txt");

            return list;
        }

        public List<Point> GetSaronite()
        {
            List<Point> list = FileReader.ReadFile("saronite.txt");

            return list;
        }

        public List<Point> GetRichSaronite()
        {
            List<Point> list = FileReader.ReadFile("rich_saronite.txt");

            return list;
        }

        public List<Point> GetTitanium()
        {
            List<Point> list = FileReader.ReadFile("titanium.txt");

            return list;
        }

        public List<Point> GetNorthrendOres()
        {
            List<Point> cobalt = GetCobalt();
            List<Point> rich_cobalt = GetRichCobalt();
            List<Point> saronite = GetSaronite();
            List<Point> rich_saronite = GetRichSaronite();
            List<Point> titanium = GetTitanium();

            int size = cobalt.Count + rich_cobalt.Count + saronite.Count + rich_saronite.Count + titanium.Count;

            List<Point> allOres = new List<Point>(size);

            allOres.AddRange(cobalt);
            allOres.AddRange(rich_cobalt);
            allOres.AddRange(saronite);
            allOres.AddRange(rich_saronite);
            allOres.AddRange(titanium);

            return allOres;
        }

        public List<Point> MineMap(string name)
        {
            Dictionary<string, List<Point>> map = new Dictionary<string, List<Point>>();

            map["cobalt"] = GetCobalt();
            map["rich_cobalt"] = GetRichCobalt();
            map["saronite"] = GetSaronite();
            map["rich_saronite"] = GetRichSaronite();
            map["titanium"] = GetTitanium();

            map["adamantite"] = GetAdamantite();
            map["rich_adamantite"] = GetRichAdamantite();
            map["fel_iron"] = GetFelIron();
            map["khorium"] = GetKhorium();
            map["nethercite"] = GetNethercite();

            if(!map.ContainsKey(name))
            {
                return new List<Point>();
            }

            return map[name];
        }

        public int MineZone(string name)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            map["adamantite"] = 0;
            map["rich_adamantite"] = 0;
            map["fel_iron"] = 0;
            map["khorium"] = 0;
            map["nethercite"] = 0;

            map["cobalt"] = 1;
            map["rich_cobalt"] = 1;
            map["saronite"] = 1;
            map["rich_saronite"] = 1;
            map["titanium"] = 1;

            if(!map.ContainsKey(name))
            {
                return -1;
            }

            return map[name];
        }

        public List<Point> GetAdamantite()
        {
            List<Point> list = FileReader.ReadFile("adamantite.txt");

            return list;
        }

        public List<Point> GetRichAdamantite()
        {
            List<Point> list = FileReader.ReadFile("rich_adamantite.txt");

            return list;
        }

        public List<Point> GetFelIron()
        {
            List<Point> list = FileReader.ReadFile("fel_iron.txt");

            return list;
        }

        public List<Point> GetKhorium()
        {
            List<Point> list = FileReader.ReadFile("khorium.txt");

            return list;
        }

        public List<Point> GetNethercite()
        {
            List<Point> list = FileReader.ReadFile("nethercite.txt");

            return list;
        }

        public List<Point> GetOutlandOres()
        {
            List<Point> adamantite = GetCobalt();
            List<Point> fel_iron = GetFelIron();
            List<Point> khorium = GetKhorium();
            List<Point> nethercite = GetNethercite();
            List<Point> rich_adamantite = GetRichAdamantite();

            int size = adamantite.Count + fel_iron.Count + khorium.Count + nethercite.Count + rich_adamantite.Count;

            List<Point> allOres = new List<Point>(size);

            allOres.AddRange(adamantite);
            allOres.AddRange(fel_iron);
            allOres.AddRange(khorium);
            allOres.AddRange(nethercite);
            allOres.AddRange(rich_adamantite);

            return allOres;
        }
    }
}
