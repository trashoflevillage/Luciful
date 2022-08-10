using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;


namespace Luciful.Content.Items.Placeables.Bars
{
    internal class BronzeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Bar");
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

            Item.createTile = ModContent.TileType<Tiles.Bars.BronzeBar>();
            Item.placeStyle = 0;

            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.TinOre, 2).AddIngredient(ItemID.CopperOre, 2).AddTile(TileID.Furnaces).Register();
        }
    }
}
