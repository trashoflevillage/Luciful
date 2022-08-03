using System;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;

namespace Luciful.Content.NPCs.Bosses
{
    public class BossBorder
    {
        public int radius;
        public int dust;
        public Vector2 location;
        public int dustWidth;
        public int dustHeight;

        public BossBorder(int radius, int dust, Vector2 location, int dustWidth = 1, int dustHeight = 1)
        {
            this.radius = radius;
            this.dust = dust;
            this.location = location;
            this.dustWidth = dustWidth;
            this.dustHeight = dustHeight;
        }
        public void Tick() {
            if (this != null)
            {
                for (double i = 0; i < 360; i += 2)
                {
                    Vector2 dustLocation = new Vector2(location.X + radius * (float)Math.Cos(i), location.Y + radius * (float)Math.Sin(i));
                    Dust.NewDust(dustLocation, dustWidth, dustHeight, dust);
                }
            }
        }

        public bool ContainsPosition(Vector2 position)
        {
            if ((position.X - location.X) * (position.X - location.X) +
                (position.Y - location.Y) * (position.Y - location.Y) <= radius * radius)
                return true;
            else
                return false;
        }
    }
}
