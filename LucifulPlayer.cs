using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulPlayer : ModPlayer
    {
        // General stat increases
        public float bonusMeleeSpeed = 0f;
        public float bonusMagicSpeed = 0f;
        public float bonusRangedSpeed = 0f;
        public float bonusSummonSpeed = 0f;

        // Variables relating to if the player has accessories equipped
        public bool amethystGlove = false;
        public bool topazGlove = false;
        public bool sapphireGlove = false;
        public bool emeraldGlove = false;
        public bool rubyGlove = false;
        public bool amberGlove = false;
        public bool diamondGlove = false;
        public bool frightGauntlet = false;
        public bool mightGauntlet = false;
        public bool sightGauntlet = false;

        public bool mushroomNecklace = false;

        public bool fourSidedDice = false;

        public override void ResetEffects()
        {
            // General stat increases
            this.bonusMeleeSpeed = 0f;
            this.bonusMagicSpeed = 0f;
            this.bonusRangedSpeed = 0f;
            this.bonusSummonSpeed = 0f;

            // Variables relating to if the player has accessories equipped
            this.amethystGlove = false;
            this.topazGlove = false;
            this.sapphireGlove = false;
            this.emeraldGlove = false;
            this.rubyGlove = false;
            this.amberGlove = false;
            this.diamondGlove = false;
            this.frightGauntlet = false;
            this.mightGauntlet = false;
            this.sightGauntlet = false;

            this.mushroomNecklace = false;

            this.fourSidedDice = false;
        }

    }
}
