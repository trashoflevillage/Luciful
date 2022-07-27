﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Luciful.Content.Projectiles.Magic
{
	public class BlueFlaskCloud1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Flask Cloud");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ToxicCloud);

			AIType = ProjectileID.ToxicCloud;

			Projectile.penetrate = 6;
			Projectile.light = 0.4f;
		}

		public override void Kill(int timeLeft)
		{
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(1, 100) < 3) Item.NewItem(target.GetSource_Loot(), target.position, 1, 1, ItemID.Star);
		}
    }
}