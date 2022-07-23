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

        public float meleeWeaponScale = 0f;
        public float magicWeaponScale = 0f;
        public float rangedWeaponScale = 0f;
        public float summonWeaponScale = 0f;

        public int healingPotency = 0;

        // Infliction of buffs/debuffs

        public int inflictDilutedIchor = 0;
        public int inflictCursedSpark = 180;

        public override void ResetEffects()
        {
            // General stat increases

            this.bonusMeleeSpeed = 0f;
            this.bonusMagicSpeed = 0f;
            this.bonusRangedSpeed = 0f;
            this.bonusSummonSpeed = 0f;

            this.meleeWeaponScale = 0f;
            this.magicWeaponScale = 0f;
            this.rangedWeaponScale = 0f;
            this.summonWeaponScale = 0f;

            this.healingPotency = 0;

            // Infliction of buffs/debuffs

            this.inflictDilutedIchor = 0;
            this.inflictCursedSpark = 180;

        }

        // Everything past here is not for the setting and resetting of variables.

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            HitNpc(target, damage, knockback, crit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            HitNpc(target, damage, knockback, crit);
        }

        /// <summary>
        /// Allows you to create special effects when this player hits an NPC in any way.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="damage"></param>
        /// <param name="knockback"></param>
        /// <param name="crit"></param>
        public void HitNpc(NPC target, int damage, float knockback, bool crit)
        {
            if (inflictDilutedIchor > 0)
                target.AddBuff(ModContent.BuffType<Content.Buffs.DilutedIchor>(), inflictDilutedIchor);

            if (inflictCursedSpark > 0)
                target.AddBuff(ModContent.BuffType<Content.Buffs.CursedSpark>(), inflictCursedSpark);
        }
    }
}
