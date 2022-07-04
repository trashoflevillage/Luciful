using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulPlayer : ModPlayer
    {
        public bool amethystGlove = false;
        public bool topazGlove = false;
        public bool sapphireGlove = false;
        public bool emeraldGlove = false;
        public bool rubyGlove = false;
        public bool amberGlove = false;
        public bool diamondGlove = false;
        public int amethystGloveCheckTick = 0;
        public int equipmentCheckTick = 0;

        public override void ResetEffects()
        {
            this.amethystGlove = false;
            this.topazGlove = false;
            this.sapphireGlove = false;
            this.emeraldGlove = false;
            this.rubyGlove = false;
            this.amberGlove = false;
            this.diamondGlove = false;
        }

    }
}
