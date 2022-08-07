using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Luciful.Content.Items.Materials.Essence;
using System.Collections.Generic;
using Luciful.Content.NPCs.Bosses;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

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
            Luciful instance = Luciful.Instance;
            if (instance.contractSigned == true && Main.masterMode)
            {
                npc.lifeMax = (int) (1.2 * npc.lifeMax);
                npc.life = (int) (1.2 * npc.lifeMax);
            }

            if (npc.buffImmune[BuffID.Ichor])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.DilutedIchor>()] = true;
            if (npc.buffImmune[BuffID.CursedInferno])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.CursedSpark>()] = true;
        }

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            LucifulNPC modNpc = Convert(npc);
            Luciful instance = Luciful.Instance;
            if (npc.boss) instance.bossesAlive++;
            if (instance.contractSigned == true && Main.masterMode)
            {
                modNpc.contracted = true;
                BossBorder newBossBorder;
                if (npc.boss) if (instance.bossBorder == null)
                    {
                        newBossBorder = GetBossBorder(npc);
                        newBossBorder.location = GetNearestPlayer(npc).position;
                        instance.bossBorder = newBossBorder;
                    }
            }
            else modNpc.contracted = false;
        }

        public static LucifulNPC Convert(NPC npc)
        {
            return npc.GetGlobalNPC<LucifulNPC>();
        }

        public override void OnKill(NPC npc)
        {
            Luciful instance = Luciful.Instance;
            if (npc.boss)
            {
                instance.bossesAlive--;
                if (instance.bossesAlive == 0) instance.bossBorder = null;
                if (!instance.bossesKilled.ContainsKey("defeated" + npc.type)) instance.bossesKilled.Add("defeated" + npc.type, true);
                int? essenceItem = null;
                if (contracted)
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

        public static BossBorder GetBossBorder(NPC npc)
        {
            switch (npc.type)
            {
                default: return null;
                case NPCID.EyeofCthulhu: return new BossBorder(2000, DustID.SpectreStaff, npc.position);
            }
        }

        public static Player GetNearestPlayer(NPC npc)
        {
            float? lastDistance = null;
            Player nearestPlayer = null;
            foreach (Player i in Main.player)
            {
                if (nearestPlayer != null && i.position.Distance(npc.position) < lastDistance)
                {
                    lastDistance = i.position.Distance(npc.position);
                    nearestPlayer = i;
                }
                if (nearestPlayer == null)
                {
                    lastDistance = i.position.Distance(npc.position);
                    nearestPlayer = i;
                }
            }
            return nearestPlayer;
        }

        public override bool CheckActive(NPC npc)
        {
            if (npc.boss)
            {
                int deadPlayers = 0;
                foreach (Player i in Main.player)
                {
                    if (i.dead)
                    {
                        deadPlayers++;
                    }
                }
                if (deadPlayers == Main.player.Length)
                {
                    OnDespawn(npc);
                    return true;
                }
                else return false;
            }
            else
            {
                OnDespawn(npc);
                return true;
            }
        }

        public void OnDespawn(NPC npc)
        {
            Luciful instance = Luciful.Instance;
            if (npc.boss)
            {
                instance.bossesAlive--;
                if (instance.bossesAlive == 0) instance.bossBorder = null;
            }
        }
    }
}
