using Luciful.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace Luciful
{
    internal class LucifulProjectile : GlobalProjectile
    {
        public string texture;

        public override bool InstancePerEntity => true;
    }
}
