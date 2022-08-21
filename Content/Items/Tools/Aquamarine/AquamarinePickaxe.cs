using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Aquamarine
{
    internal class AquamarinePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine Pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.autoReuse = true;
            Item.useTurn = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 15;
            Item.knockBack = 2f;
            Item.crit = 5;

            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;

            Item.pick = 100;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineBar>(), 20).AddTile(TileID.Anvils).Register();
        }
    }
}
