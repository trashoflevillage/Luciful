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

		public bool contractSigned = false;
		public IDictionary<string, bool> bossesKilled = new Dictionary<string, bool>();

		public int bossesAlive = 0;
		public BossBorder bossBorder = null;

		public override void Load()
        {
        }
    }
}