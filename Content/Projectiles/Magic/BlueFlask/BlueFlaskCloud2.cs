﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Luciful.Content.Projectiles.Magic.BlueFlask
{
    public class BlueFlaskCloud2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Flask Cloud");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ToxicCloud2);

            AIType = ProjectileID.ToxicCloud2;

            Projectile.penetrate = 6;
            Projectile.light = 0.4f;
            Projectile.damage = 10;
        }

        public override void Kill(int timeLeft)
        {
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1, 20) < 3 && target.type != NPCID.TargetDummy) Item.NewItem(target.GetSource_Loot(), target.Center, 1, 1, ItemID.Star);
        }
    }
}