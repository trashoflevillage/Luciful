﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Shovels
{
    internal class SilverShovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Shovel");
            Tooltip.SetDefault("Digs in a bigger area than a pickaxe\nOnly digs up soft tiles");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 28;
            
            Item.useTime = 16;
            Item.useAnimation = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 12)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
