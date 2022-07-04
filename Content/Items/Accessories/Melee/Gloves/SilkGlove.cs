using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    public class SilkGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silk Glove");
            Tooltip.SetDefault("4% increased melee speed");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 5);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.04f;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.Silk, 8).AddTile(TileID.Loom).Register();
        }
    }
}