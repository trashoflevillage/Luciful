using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    public class AmberGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Embedded Glove");
            Tooltip.SetDefault("Increases melee weapon size by 125%\n25% decreased melee speed\nHandy for true melee!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 34);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.amberGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) -= 0.25f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<SilkGlove>(), 1).AddIngredient(ItemID.Amber, 3).AddTile(TileID.Anvils).Register();
        }
    }
}