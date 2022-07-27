﻿using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;


namespace Luciful.Content.Items.Placeables
{
    internal class BlueFlaskPlaceable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Flask Placeable");
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

            Item.createTile = ModContent.TileType<Tiles.BlueFlask>();
            Item.placeStyle = 0;

            Item.rare = ItemRarityID.White;
        }
    }
}