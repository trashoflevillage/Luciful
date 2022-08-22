using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Projectiles.Boomerangs.ElementalBoomerang
{
	public class DualityFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flamarang");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Flamarang);

			AIType = ProjectileID.Bananarang;

			Projectile.damage = 36;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffID.OnFire, 180);
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180);
		}

		public override void AI()
		{
		}
	}
}