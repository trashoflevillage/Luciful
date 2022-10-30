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
    internal class BossDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.KingSlime: npcLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 1, 20, 35)); break;
                default: break;
            }
        }
    }
}
