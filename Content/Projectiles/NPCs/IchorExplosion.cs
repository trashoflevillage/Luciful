using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Luciful.Content.Projectiles.NPCs
{
	public class IchorExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Blast");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ToxicCloud);

			AIType = ProjectileID.ToxicCloud;

			Projectile.penetrate = 6;
			Projectile.light = 0.6f;
			Projectile.damage = 10;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.scale = 1.5f;
		}

		public override void Kill(int timeLeft)
		{
		}

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			int duration = 360;
			if (crit) duration *= 2;
			target.AddBuff(BuffID.Ichor, duration);
        }
    }
}