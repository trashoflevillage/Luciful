﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Shovels
{
    internal class IronShovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Shovel");
            Tooltip.SetDefault("Replacement for the Gravedigger's Shovel\nDigs in a bigger area than a pickaxe\nOnly digs up soft tiles");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 25;

            Item.useTime = 17;
            Item.useAnimation = 17;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 12)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.GravediggerShovel)
                .Register();
        }
    }
}
