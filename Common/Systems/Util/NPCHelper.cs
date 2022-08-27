using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace Luciful.Common.Systems.Util
{
    internal class NPCHelper
    {
        public static int GetNPCCount(int npcType)
        {
            int output = 0;
            foreach (NPC i in LucifulWorld.NPCs)
            {
                if (i.type == npcType) 
                {
                    output++;
                }
            }
            return output;
        }
    }
}
