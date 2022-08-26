using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Luciful.Content.NPCs.Bosses;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Luciful.Common.Systems.Util;

namespace Luciful
{
    internal class LucifulNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public int cursedSparkTick = 0;

        //public bool contracted = false;
        public List<DropOneByOne> dropOneByOnes = new List<DropOneByOne>();

        public override void SetDefaults(NPC npc)
        {
            Luciful instance = Luciful.Instance;
            /*
            if (instance.contractSigned == true && Main.masterMode)
            {
                npc.lifeMax = (int) (1.2 * npc.lifeMax);
                npc.life = (int) (1.2 * npc.lifeMax);
            }*/

            if (npc.buffImmune[BuffID.Ichor])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.DilutedIchor>()] = true;
            if (npc.buffImmune[BuffID.CursedInferno])
                npc.buffImmune[ModContent.BuffType<Content.Buffs.CursedSpark>()] = true;
        }

        public void OnDespawn()
        {
        }
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            LucifulWorld.NPCs.Add(npc);
            LucifulNPC modNpc = Convert(npc);
            Luciful instance = Luciful.Instance;
            if (npc.boss) instance.bossesAlive++;
            /*
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
            else modNpc.contracted = false;*/
        }

        public static LucifulNPC Convert(NPC npc)
        {
            return npc.GetGlobalNPC<LucifulNPC>();
        }

        public override void OnKill(NPC npc)
        {
            Luciful instance = Luciful.Instance;
            /*if (npc.boss && contracted)
            {
                instance.bossesAlive--;
                if (instance.bossesAlive == 0) instance.bossBorder = null;
                if (!instance.bossesKilled.ContainsKey("defeated" + npc.type)) instance.bossesKilled.Add("defeated" + npc.type, true);
                int? essenceItem = null;
                switch (npc.type)
                {
                    case NPCID.EyeofCthulhu: essenceItem = ModContent.ItemType<EyeOfCthulhuEssence>(); break;
                }
                if (essenceItem != null)
                {
                    npc.DropItemInstanced(npc.position, npc.Size, essenceItem.Value, 5, true);
                }
            }*/
        }

        public static BossBorder GetBossBorder(NPC npc)
        {
            switch (npc.type)
            {
                default: return null;
                case NPCID.EyeofCthulhu: return new BossBorder(2000, DustID.SpectreStaff, npc.position);
            }
        }

        public static int? GetSummonItem(NPC npc)
        {
            switch (npc.type)
            {
                default: return null;
                case NPCID.KingSlime: return ItemID.SlimeCrown;
                case NPCID.EyeofCthulhu: return ItemID.SuspiciousLookingEye;
                case NPCID.BrainofCthulhu: return ItemID.BloodySpine;
            }
        }

        public static Player GetNearestPlayer(NPC npc)
        {
            return LocationHelper.GetNearestPlayer(npc.position);
        }

        public static void OnDespawn(NPC npc)
        {
            Luciful instance = Luciful.Instance;
            int? summonItem = GetSummonItem(npc);
            if (summonItem != null)
            {
                Vector2 itemPosition = npc.position;
                float newY = LocationHelper.GetNearestPlayer(npc.position).position.Y;
                Main.NewText(LocationHelper.GetNearestPlayer(npc.position).name);
                if (newY < itemPosition.Y) itemPosition.Y = newY;
                Tile tile = Framing.GetTileSafely(itemPosition);
                if (tile.HasTile)
                {
                    while (tile.HasTile)
                    {
                        itemPosition.Y++;
                        tile = Framing.GetTileSafely(itemPosition);
                    }
                }

                Item.NewItem(npc.GetSource_DropAsItem(), itemPosition, (int)summonItem);
            }
            if (npc.boss)
            {
                instance.bossesAlive--;
                //if (instance.bossesAlive == 0) instance.bossBorder = null;
            }
        }
    }
}