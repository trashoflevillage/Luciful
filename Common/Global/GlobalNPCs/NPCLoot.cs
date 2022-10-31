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
                case NPCID.AngryBones: npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Content.Items.Accessories.Combat.MarkedSkull>(), 50, 25)); break;
                case NPCID.AngryBonesBig: npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Content.Items.Accessories.Combat.MarkedSkull>(), 50, 25)); break;
                case NPCID.AngryBonesBigHelmet: npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Content.Items.Accessories.Combat.MarkedSkull>(), 50, 25)); break;
                case NPCID.AngryBonesBigMuscle: npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Content.Items.Accessories.Combat.MarkedSkull>(), 50, 25)); break;
                default: break;
            }
        }
    }
}
