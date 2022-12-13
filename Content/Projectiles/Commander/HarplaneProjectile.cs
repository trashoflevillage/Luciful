using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Luciful.Content.Projectiles.Commander
{
    public class HarplaneProjectile : ModProjectile
    {
		public override void SetDefaults()
		{
            Projectile.aiStyle = 1;
            Projectile.damage = 4;
			Projectile.DamageType = ModContent.GetInstance<DamageClasses.Commander>();
			Projectile.knockBack = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 900;

			AIType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

		// We need to draw the projectile manually. If you don't include this, the projectile will be facing the wrong direction when flying left.
		public override bool PreDraw(ref Color lightColor)
		{
			if (Projectile.velocity.X < 0) Projectile.spriteDirection = -1;
			else Projectile.spriteDirection = 1;

			// This is where we specify which way to flip the sprite. If the projectile is moving to the left, then flip it vertically.
			SpriteEffects spriteEffects = ((Projectile.spriteDirection <= 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);

			// Getting texture of projectile
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			// Get the currently selected frame on the texture.
			Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], frameY: Projectile.frame);

			Vector2 origin = sourceRectangle.Size() / 2f;

			// Applying lighting and draw our projectile
			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			// It's important to return false, otherwise we also draw the original texture.
			return false;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (LucifulNPC.IsValidTarget(target.type))
            {

            }
        }
    }
}
