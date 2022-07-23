using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulNPC : GlobalNPC
    {
        public int cursedSparkTick = 0;

        public override void SetDefaults(NPC npc)
        {
            if (npc.buffImmune[BuffID.Ichor])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.DilutedIchor>()] = true;
            if (npc.buffImmune[BuffID.CursedInferno])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.CursedSpark>()] = true;
        }

        public static LucifulNPC Convert(NPC npc)
        {
            return npc.GetGlobalNPC<LucifulNPC>();
        }
    }
}
