using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Luciful.Content.Projectiles.Commander
{
    public class CommanderAirplane : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper Airplane");
        }

		public override void SetDefaults()
		{
            Projectile.aiStyle = 1;
            Projectile.damage = 4;
            Projectile.knockBack = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 900;

            AIType = ProjectileID.Bullet;
		}
    }
}
