using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Luciful.Content.Projectiles.Magic.HungryTome
{
    public class Hungry : ModProjectile
    {
        int nextFrame = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Hungry");
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.GemStaffBolt;

            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.damage = 90;
            Projectile.height = 30;
            Projectile.width = 30;
        }

        public override void Kill(int timeLeft)
        {
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, Projectile.velocity, 132);
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, Projectile.velocity, 133);
            SoundStyle sound;
            if (Main.rand.NextBool()) sound = SoundID.NPCDeath11;
            else sound = SoundID.NPCDeath12;
            SoundEngine.PlaySound(sound, Projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1, 20) <= 1 && target.type != NPCID.TargetDummy) Item.NewItem(target.GetSource_Loot(), target.Center, 1, 1, ItemID.Heart);
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            nextFrame++;
            if (nextFrame >= 10)
            {
                nextFrame = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type]) // this used to have a ++ before Projectile.frame, add that back if the anim breaks.
                    Projectile.frame = 0;
            }
        }
    }
}