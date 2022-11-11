using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace Luciful.Common.Global.GlobalNPCs
{
    internal class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.KingSlime: npcLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 1, 20, 35)); break;
                case NPCID.AngryBones: npcLoot.Add(DungeonSkeletonDrop()); break;
                case NPCID.AngryBonesBig: npcLoot.Add(DungeonSkeletonDrop()); break;
                case NPCID.AngryBonesBigHelmet: npcLoot.Add(DungeonSkeletonDrop()); break;
                case NPCID.AngryBonesBigMuscle: npcLoot.Add(DungeonSkeletonDrop()); break;
                default: break;
            }
            if (npc.type == ModContent.NPCType<Content.NPCs.Dungeon.SkeletonDartThrower>()) npcLoot.Add(DungeonSkeletonDrop());
        }

        private IItemDropRule DungeonSkeletonDrop()
        {
            return ItemDropRule.NormalvsExpert(ModContent.ItemType<Content.Items.Accessories.Combat.MarkedSkull>(), 454, 303);
        }
    }
}
