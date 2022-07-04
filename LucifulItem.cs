using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public float baseScale;
        public bool scaled = false;
    }
}