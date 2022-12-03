using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Aquamarine
{
    internal class AquamarineHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 24;
            Item.autoReuse = true;
            Item.useTurn = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 23;
            Item.knockBack = 5f;
            Item.crit = 5;

            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;

            Item.axe = 30;
            Item.hammer = 70;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineBar>(), 15).AddTile(TileID.Anvils).Register();
        }
    }
}
