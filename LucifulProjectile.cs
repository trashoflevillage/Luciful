using Luciful.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace Luciful
{
    internal class LucifulProjectile : GlobalProjectile
    {
        public string texture;

        public override bool InstancePerEntity => true;

        public CommanderSpecial commanderSpecial = null;

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            commanderSpecial.OnActivate(projectile, target);
        }
    }
}
