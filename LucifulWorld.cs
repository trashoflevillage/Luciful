using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Luciful
{
    internal class LucifulWorld : ModSystem
    {
        public override void SaveWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            instance.bossBorder = null;
            List<string> lucifulData = new List<string>();
            foreach (KeyValuePair<string, bool> i in instance.bossesKilled)
                if (i.Value) lucifulData.Add("defeated" + i.Key);
            if (instance.contractSigned) lucifulData.Add("contractSigned");
            tag.Add("lucifulData", lucifulData);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            instance.bossBorder = null;
            instance.bossesKilled.Clear();

            IList<string> lucifulData = tag.GetList<string>("lucifulData");
            foreach (string i in lucifulData)
                if (i.Contains("defeated")) instance.bossesKilled.Add(i, true);
            if (lucifulData.Contains("contractSigned")) instance.contractSigned = true; else instance.contractSigned = false;
        }

        public override void PostUpdateEverything()
        {
            Luciful instance = Luciful.Instance;
            if (instance.bossBorder != null) instance.bossBorder.Tick();
        }
        public override void AddRecipeGroups()
        {
            if (RecipeGroup.recipeGroupIDs.ContainsKey("Wood"))
            {
                int index = RecipeGroup.recipeGroupIDs["Wood"];
                RecipeGroup group = RecipeGroup.recipeGroups[index];
                group.ValidItems.Add(ModContent.ItemType<Content.Items.Placeables.Wood.GoblinWood>());
            }
        }

        public void CreateExplosion(Vector2 position, int power = 2, int damage = 0)
        {
            CreateExplosion((int)position.X, (int)position.Y, power, damage);
        }

        public void CreateExplosion(int x, int y, int power = 2, int damage = 0)
        {

        }
    }
}
