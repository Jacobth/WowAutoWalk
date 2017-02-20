using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr.Getters
{
    class ZoneInfo
    {
        private Dictionary<int, float> heights;

        public ZoneInfo()
        {
            FillList();
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

        public float GetZoneHeight(int mapId)
        {
            return heights[mapId];
        }
    }
}
