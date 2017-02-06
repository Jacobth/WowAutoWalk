using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWObjMgr.Getters
{
    class GameInfo
    {

        /*Getters for alot of diffrent data for both target and the player
        */

        public static float GetPlayerRot()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return obj.Rotation;
        }

        public static float GetPlayerX()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return obj.XPos;
        }

        public static float GetPlayerY()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return obj.YPos;
        }

        public static float GetPlayerZ()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return obj.ZPos;
        }

        public static Point GetPlayerPos()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return new Point(obj.XPos, obj.YPos);
        }

        public static Point GetTargetPos()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalTarget();

            return new Point(obj.XPos, obj.YPos);
        }

        public static ulong GetTargetGuid()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalTarget();

            return obj.Guid;
        }

        public static bool IsTargetDead()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalTarget();

            return obj.isDead;
        }

        public static bool IsPlayerDead()
        {
            PlayerScan scan = new PlayerScan();

            scan.Ping();

            WowObject obj = scan.GetLocalPlayer();

            return obj.isDead;
        }

    }
}
