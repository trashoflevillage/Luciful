using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    [AutoloadEquip(EquipType.HandsOff)]
    public class EmeraldGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Embedded Glove");
            Tooltip.SetDefault("Increases melee weapon size by 100%\nIncreases melee damage by 4%\n20% decreased melee speed\nHandy for true melee!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 27);
            Item.vanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.emeraldGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) -= 0.20f;
            player.GetDamage(DamageClass.Melee) += 0.04f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<SilkGlove>(), 1).AddIngredient(ItemID.Emerald, 3).AddTile(TileID.Anvils).Register();
        }
    }
}