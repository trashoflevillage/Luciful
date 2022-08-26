using Terraria.ModLoader;
using System.Collections.Generic;
using IL.Terraria;
using Luciful.Content.NPCs.Bosses;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace Luciful
{
    public class Luciful : Mod
	{
		public Luciful() { Instance = this; }
		public static Luciful Instance { get; private set; }

		//public bool contractSigned = false;
		public IDictionary<string, bool> bossesKilled = new Dictionary<string, bool>();

		public int bossesAlive = 0;
		//public BossBorder bossBorder = null;

		public override void Load()
        {
        }

        public void CreateExplosion(Vector2 position, int radius = 3, int damage = 0)
        {
            CreateExplosion((int)position.X, (int)position.Y, radius, damage);
        }
        public void CreateExplosion(Point position, int radius = 3, int damage = 0)
        {
            CreateExplosion((int)position.X, (int)position.Y, radius, damage);
        }
        public void CreateExplosion(int x, int y, int radius = 3, int damage = 0)
        {
            Point cornerA = new Point(x - radius, y - radius);
            Point cornerB = new Point(x + radius, y + radius);
            Point selectedLoc = cornerA;
            while (true)
            {
                if ((selectedLoc.X - x) * (selectedLoc.X - x) +
                    (selectedLoc.Y - y) * (selectedLoc.Y - y) <= radius * radius)
                {
                    LucifulTile.AttemptExplode(selectedLoc);
                }
                selectedLoc.X++;
                if (selectedLoc.X > cornerB.X)
                {
                    selectedLoc.X = cornerA.X;
                    selectedLoc.Y++;
                    if (selectedLoc.Y > cornerB.Y) break;
                }
            }
        }
    }
}