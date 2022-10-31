using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System.Runtime;
using Luciful.Common.Systems.Util;

namespace Luciful.Content.Projectiles.Darts
{
	public class BoneDart : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necro Dart"); // The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
			Projectile.penetrate = 2; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.light = 0.1f; // How much light emit around the projectile
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.usesLocalNPCImmunity = true;

			AIType = ProjectileID.PoisonDart; // Act exactly like default Bullet
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.npc.Where(i => !i.friendly).Where(i => i.active).ToArray().Length > 1)
			{
				NPC newTarget = LocationHelper.GetNearestNPC(target.position, true, target);
				if (target.position.Distance(newTarget.position) < 1000f)
				{
					Projectile.velocity = (newTarget.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 15f;
					Projectile.rotation = Projectile.velocity.ToRotation();
				}
			}
		}
    }
}