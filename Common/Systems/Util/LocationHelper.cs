﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework;
using IL.Terraria.DataStructures;

namespace Luciful.Common.Systems.Util
{
    internal class LocationHelper
    {

        public static bool CanSee(Vector2 pos1, Vector2 pos2)
        {
            while (pos1.X != pos2.X && pos1.Y != pos2.Y)
            {
                if (Framing.GetTileSafely(pos1).HasTile)
                {
                    return false;
                }
                pos1.MoveTowards(pos2, 1);
            }
            return true;
        }
        public static Player GetNearestPlayer(Vector2 position)
        {
            float? lastDistance = null;
            Player nearestPlayer = null;
            foreach (Player i in Main.player)
            {
                if (nearestPlayer != null && i.position.Distance(position) < lastDistance)
                {
                    lastDistance = i.position.Distance(position);
                    nearestPlayer = i;
                }
                if (nearestPlayer == null)
                {
                    lastDistance = i.position.Distance(position);
                    nearestPlayer = i;
                }
            }
            return nearestPlayer;
        }
        public static NPC GetNearestNPC(Vector2 position, bool noFriendly = false, NPC exclusion = null)
        {
            float? lastDistance = null;
            NPC nearestNPC = null;
            foreach (NPC i in Main.npc)
            {
                if (i != exclusion && (!noFriendly || !i.friendly))
                {
                    if (nearestNPC != null && i.position.Distance(position) < lastDistance)
                    {
                        lastDistance = i.position.Distance(position);
                        nearestNPC = i;
                    }
                    if (nearestNPC == null)
                    {
                        lastDistance = i.position.Distance(position);
                        nearestNPC = i;
                    }
                }
            }
            return nearestNPC;
        }

        public static Player GetNearestPlayer(Point position)
        {
            return GetNearestPlayer(new Vector2(position.X, position.Y));
        }
    }
}
