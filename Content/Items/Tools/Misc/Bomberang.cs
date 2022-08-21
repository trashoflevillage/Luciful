using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Misc
{
    internal class Bomberang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomberang");
            Tooltip.SetDefault("Not a weapon!!!\nDestroys tiles on impact or if the projectile exists long enough");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodenBoomerang);

            Item.DamageType = DamageClass.Generic;
            Item.damage = 0;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.ElementalBoomerang.Bomberang>();

            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
        }
    }
}
