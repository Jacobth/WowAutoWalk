using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr.Getters
{
    class ZoneInfo
    {
        private Dictionary<int, float> heights;
        private Dictionary<int, int> mineZones;

        public ZoneInfo()
        {
            FillList();
            FillZones();
        }

        public enum MapIds : int
        {
            ZulDrak = 66,

        }

        private void FillList()
        {
            heights = new Dictionary<int, float>();

            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
            heights[(int)MapIds.ZulDrak] = 0;
        }

        private void FillZones()
        {
            mineZones = new Dictionary<int, int>();

            mineZones[3518] = 0;    //nagrand
            mineZones[3521] = 0;    //zangarmarsh
            mineZones[3522] = 0;    //bladesedge
            mineZones[3523] = 0;    //netherstorm
            mineZones[3483] = 0;    //hellfire
            mineZones[3519] = 0;    //terokkar
            mineZones[3520] = 0;    //shadowmoon

            mineZones[495] = 1;    //howling
            mineZones[394] = 1;    //grizzly
            mineZones[66] = 1;    //zuldrak
            mineZones[67] = 1;    //stormpeaks
            mineZones[210] = 1;    //icecrown
            mineZones[2817] = 1;    //crystalsong
            mineZones[4395] = 1;    //dalaran
            mineZones[65] = 1;    //dragonblight
            mineZones[4197] = 1;    //wintergrasp
            mineZones[3711] = 1;    //sholazar
            mineZones[3537] = 1;    //borean
        }

        public int GetContinent(int zone)
        {
            return mineZones[zone];
        }

        public float GetZoneHeight(int mapId)
        {
            return heights[mapId];
        }
    }
}
