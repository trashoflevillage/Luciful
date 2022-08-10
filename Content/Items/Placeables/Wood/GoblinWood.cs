using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Luciful.Content.Items.Placeables.Wood
{
    internal class GoblinWood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblinbark");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
            ItemID.Sets.SortingPriorityMaterials[Type] = 176;
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.sellPrice(copper: 3);
            Item.maxStack = 999;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.White;

            Item.createTile = ModContent.TileType<Tiles.Wood.GoblinWood>();
        }
    }
}
