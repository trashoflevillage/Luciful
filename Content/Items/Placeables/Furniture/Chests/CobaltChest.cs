using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Luciful.Content.Items.Placeables.Furniture.Chests
{
    internal class CobaltChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Chest");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.SortingPriorityMaterials[Type] = 176;
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

            Item.rare = ItemRarityID.White;

            Item.createTile = ModContent.TileType<Tiles.Furniture.Chests.CobaltChest>();
        }
    }
}
