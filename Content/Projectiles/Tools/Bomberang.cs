using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Projectiles.Tools.Bomberang
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
			Projectile.timeLeft = 120;
			Projectile.DamageType = DamageClass.Generic;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
		}

		public override void AI()
		{
		}
	}
}