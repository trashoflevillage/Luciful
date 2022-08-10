using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Luciful.Content.Items.Placeables.Ores;

namespace Luciful.Content.Items.Placeables.Bars
{
    internal class AquamarineBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine Bar");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            ItemID.Sets.SortingPriorityMaterials[Type] = 177;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.sellPrice(copper: 50);
            Item.maxStack = 999;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<Tiles.Bars.AquamarineBar>();
            Item.placeStyle = 0;

            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineOre>(), 4).AddTile(TileID.Hellforge).Register();
        }
    }
}
