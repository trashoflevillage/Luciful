using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Projectiles.Boomerangs
{
	public class Bomberang : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bomberang");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);

			AIType = ProjectileID.EnchantedBoomerang;

			Projectile.damage = 0;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 50;
			Projectile.DamageType = DamageClass.Generic;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Projectile.Kill();
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			Projectile.Kill();
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.Kill();
            return base.OnTileCollide(oldVelocity);
        }

        public override void Kill(int timeLeft)
		{if (Projectile.owner == Main.myPlayer)
			{
				Luciful.Instance.CreateExplosion(Projectile.position);
			}
        }

        public override void AI()
		{
		}
	}
}