using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Luciful.Content.Items.Materials.Essence;
using System.Collections.Generic;

namespace Luciful
{
    internal class LucifulNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int cursedSparkTick = 0;

        public bool contracted = false;
        public List<DropOneByOne> dropOneByOnes = new List<DropOneByOne>();

        public override void SetDefaults(NPC npc)
        {
            LucifulNPC modNpc = Convert(npc);
            Luciful instance = Luciful.Instance;
            if (instance.contractSigned == true && Main.masterMode)
            {
                modNpc.contracted = true;
            }
            else modNpc.contracted = false;

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

        public override void OnKill(NPC npc)
        {
            if (contracted)
            {
                int? essenceItem = null;
                if (npc.boss)
                {
                    switch (npc.type)
                    {
                        case NPCID.EyeofCthulhu: essenceItem = ModContent.ItemType<EyeOfCthulhuEssence>(); break;
                    }
                }
                if (essenceItem != null)
                {
                    npc.DropItemInstanced(npc.position, npc.Size, essenceItem.Value, 5, true);
                }
            }
        }


    }
}
