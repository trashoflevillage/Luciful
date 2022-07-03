using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulPlayer : ModPlayer
    {
        public bool amethystGlove = false;
        public int amethystGloveCheckTick = 0;
        public int equipmentCheckTick = 0;

        public override void ResetEffects()
        {
            this.amethystGlove = false;
        }

    }
}
