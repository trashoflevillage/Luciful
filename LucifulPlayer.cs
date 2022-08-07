using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using System.Collections.Generic;

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

        public List<int> infiniteBuffs = new List<int>();

        public int inflictDilutedIchor = 0;
        public int inflictCursedSpark = 0;

        // Tick variables

        public int cursedSparkTick = 0;

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
            this.inflictCursedSpark = 0;

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

        public void HitNpc(NPC target, int damage, float knockback, bool crit)
        {
            if (inflictDilutedIchor > 0)
                target.AddBuff(ModContent.BuffType<Content.Buffs.DilutedIchor>(), inflictDilutedIchor);

            if (inflictCursedSpark > 0)
                target.AddBuff(ModContent.BuffType<Content.Buffs.CursedSpark>(), inflictCursedSpark);
        }

        public static LucifulPlayer Convert(Player player)
        {
            return player.GetModPlayer<LucifulPlayer>();
        }

        public override void PostUpdate()
        {
            Luciful instance = Luciful.Instance;
            Player player = Player;
            bool insideBossBorder = instance.bossBorder.ContainsPosition(player.position);
            if (!insideBossBorder) player.AddBuff(ModContent.BuffType<Content.Buffs.ContractualObligation>(), 1);
        }

        public override void OnRespawn(Player player)
        {
            infiniteBuffs.Clear();
        }
    }
}
