using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Luciful.Content.Items.Placeables.Furniture.CraftingStations
{
    internal class FracturedAltarCorruption : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fractured Altar");
            Tooltip.SetDefault("Can craft items that demon altars can");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0);
            Item.maxStack = 999;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Blue;

            Item.createTile = ModContent.TileType<Tiles.Furniture.CraftingStations.FracturedAltarCorruption>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.EbonstoneBlock, 20)
                .AddIngredient(ItemID.RottenChunk, 5)
                .AddIngredient(ItemID.VilePowder, 20)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
