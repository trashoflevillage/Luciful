using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
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

        public override void PostAddRecipes()
        {
			foreach (Recipe i in Main.recipe)
            {
                if (i.HasResult(ItemID.GravediggerShovel)) i.DisableRecipe();
            }
        }
    }
}