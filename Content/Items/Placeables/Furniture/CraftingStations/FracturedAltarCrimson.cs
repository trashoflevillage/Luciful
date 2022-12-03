using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Luciful.Content.Items.Placeables.Furniture.CraftingStations
{
    internal class FracturedAltarCrimson : ModItem
    {
        public override void SetStaticDefaults()
        {
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

            Item.createTile = ModContent.TileType<Tiles.Furniture.CraftingStations.FracturedAltarCrimson>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.CrimstoneBlock, 20)
                .AddIngredient(ItemID.Vertebrae, 5)
                .AddIngredient(ItemID.ViciousPowder, 20)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
