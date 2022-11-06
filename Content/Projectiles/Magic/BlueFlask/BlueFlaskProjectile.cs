using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Luciful.Content.Projectiles.Magic.BlueFlask
{
    public class BlueFlaskProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Flask");

        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ToxicFlask);

            AIType = ProjectileID.ToxicFlask;

            Projectile.penetrate = 1;
            Projectile.damage = 15;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            Vector2 velocity = new Vector2(1, 1);
            int cloudProjectile;
            for (int i = 0; i < 15; i++)
            {
                velocity = velocity.RotatedBy(30);
                if (Main.rand.NextBool()) cloudProjectile = ModContent.ProjectileType<BlueFlaskCloud1>();
                else if (Main.rand.NextBool()) cloudProjectile = ModContent.ProjectileType<BlueFlaskCloud2>();
                else cloudProjectile = ModContent.ProjectileType<BlueFlaskCloud3>();
                Projectile.NewProjectile(Terraria.Entity.InheritSource(Projectile), Projectile.Center, velocity, cloudProjectile, 4, 1f, Projectile.owner);
            }
        }
    }
}