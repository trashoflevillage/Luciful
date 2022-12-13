using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Luciful.Common.Systems.Util;
using System.Linq;

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
        }

        public static LucifulNPC Convert(NPC npc)
        {
            return npc.GetGlobalNPC<LucifulNPC>();
        }

        public static int? GetSummonItem(NPC npc)
        {
            switch (npc.type)
            {
                default: return null;
                case NPCID.KingSlime: return ItemID.SlimeCrown;
                case NPCID.EyeofCthulhu: return ItemID.SuspiciousLookingEye;
                case NPCID.EaterofWorldsHead: return ItemID.WormFood;
                case NPCID.BrainofCthulhu: return ItemID.BloodySpine;
                case NPCID.QueenBee: return ItemID.Abeemination;
                case NPCID.QueenSlimeBoss: return ItemID.QueenSlimeCrystal;
                case NPCID.Spazmatism: return ItemID.MechanicalEye;
                case NPCID.Retinazer: return ItemID.MechanicalEye;
                case NPCID.SkeletronPrime: return ItemID.MechanicalSkull;
                case NPCID.TheDestroyer: return ItemID.MechanicalWorm;
                case NPCID.DukeFishron: return ItemID.TruffleWorm;
                case NPCID.HallowBoss: return ItemID.EmpressButterfly;
                case NPCID.Golem: return ItemID.LihzahrdPowerCell;
                case NPCID.MoonLordCore: return ItemID.CelestialSigil;
            }
        }

        public static Player GetNearestPlayer(NPC npc)
        {
            return LocationHelper.GetNearestPlayer(npc.position);
        }

        public static void OnDespawn(NPC npc)
        {
            bool? dropSpawnItem = null;
            Luciful instance = Luciful.Instance;
            if (npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer)
                if ((NPCHelper.GetNPCCount(NPCID.Spazmatism) + NPCHelper.GetNPCCount(NPCID.Retinazer)) <= 1)
                    dropSpawnItem = true;
            if (dropSpawnItem == null)
                if (NPCHelper.GetNPCCount(npc.type) == 1) dropSpawnItem = true;
            if (dropSpawnItem != null && dropSpawnItem.Value)
            {
                int? summonItem = GetSummonItem(npc);
                if (summonItem != null)
                {
                    Vector2 itemPosition = npc.position;
                    float newY = LocationHelper.GetNearestPlayer(npc.position).position.Y;
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
            }
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            Luciful instance = Luciful.Instance;
            foreach (int i in instance.flipperShopOld)
            {
                instance.flipperShop.Remove(i);
            }
            instance.flipperShopOld = instance.flipperShop.ToArray();
            foreach (int i in shop.Reverse())
            {
                instance.flipperShop.Insert(0, i);
            }
        }

        public static bool IsValidTarget(int type)
        {
            int[] invalidTypes = new int[]
            {
                NPCID.TargetDummy
            };

            if (invalidTypes.Contains(type))
                return false;

            return true;
        }
    }
}