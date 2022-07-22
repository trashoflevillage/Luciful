﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Armor.Melee.Granite
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class GraniteLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Leggings");
            Tooltip.SetDefault("5% increased melee damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(silver: 20); // How many coins the item is worth
            Item.rare = ItemRarityID.Blue; // The rarity of the item
            Item.defense = 3; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.Granite, 15).AddTile(TileID.HeavyWorkBench).Register();
        }
    }
}