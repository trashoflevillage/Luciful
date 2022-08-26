using System;
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
        public static Player GetNearestPlayer(Point position)
        {
            return GetNearestPlayer(new Vector2(position.X, position.Y));
        }
    }
}
