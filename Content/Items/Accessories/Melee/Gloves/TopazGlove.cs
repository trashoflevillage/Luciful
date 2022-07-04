﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    public class TopazGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Topaz Embedded Glove");
            Tooltip.SetDefault("Increases melee weapon size by 50%\n5% decreased melee speed\nHandy for true melee!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 20);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.topazGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) -= 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<SilkGlove>(), 1).AddIngredient(ItemID.Topaz, 3).AddTile(TileID.Anvils).Register();
        }
    }
}