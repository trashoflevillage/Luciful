using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

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
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.shootSpeed = 13f;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Bomberang>();

            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
        }
    }
}
