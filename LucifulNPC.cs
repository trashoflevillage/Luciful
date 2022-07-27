using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int cursedSparkTick = 0;

        public override void SetDefaults(NPC npc)
        {
            if (npc.buffImmune[BuffID.Ichor])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.DilutedIchor>()] = true;
            if (npc.buffImmune[BuffID.CursedInferno])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.CursedSpark>()] = true;
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
        }

        public static LucifulNPC Convert(NPC npc)
        {
            return npc.GetGlobalNPC<LucifulNPC>();
        }
    }
}
