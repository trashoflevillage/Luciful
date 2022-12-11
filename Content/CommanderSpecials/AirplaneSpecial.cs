using Luciful.Common.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace Luciful.Content.CommanderSpecials
{
    public class AirplaneSpecial : CommanderSpecial
    {
        public override void OnActivate(Projectile projectile, NPC target)
        {
            Projectile.NewProjectile(projectile.GetSource_FromAI(), projectile.Center, projectile.velocity, ProjectileID.SpikyBall, 1, 1);
        }
    }
}
