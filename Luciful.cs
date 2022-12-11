using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Luciful.Content.Items.Materials;

namespace Luciful
{
    public class Luciful : Mod
	{
		public Luciful() { Instance = this; }
		public static Luciful Instance { get; private set; }

        public bool merfolkStudy = false;
        public List<int> flipperShop = new List<int>();
        public int[] flipperShopOld = new int[] {};

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

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.PaperAirplaneA).AddIngredient(ModContent.ItemType<Paper>()).Register();

            Recipe.Create(ItemID.Book).AddIngredient(ItemID.Leather).AddIngredient(ModContent.ItemType<Paper>(), 10).AddTile(TileID.WorkBenches).Register();
        }
    }
}