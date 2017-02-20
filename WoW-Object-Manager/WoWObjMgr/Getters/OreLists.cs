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
