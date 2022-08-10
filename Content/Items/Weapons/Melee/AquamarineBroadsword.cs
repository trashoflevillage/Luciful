using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Weapons.Melee
{
    internal class AquamarineBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tideswinger");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 24;
            Item.autoReuse = false;
            Item.useTurn = false;
            Item.scale = 1.8f;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 40;
            Item.knockBack = 5f;
            Item.crit = 5;

            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineBar>(), 25).AddTile(TileID.Anvils).Register();
        }
    }
}
