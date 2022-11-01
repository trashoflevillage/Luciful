using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public static int? GetHardmodeOreSlime(int tier)
        {
            switch (tier)
            {
                case 0:
                    if (WorldGen.SavedOreTiers.Cobalt == TileID.Cobalt) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.CobaltSlime>();
                    if (WorldGen.SavedOreTiers.Cobalt == -1) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.PalladiumSlime>();
                    break;
                case 1:
                    if (WorldGen.SavedOreTiers.Mythril == TileID.Mythril) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.MythrilSlime>();
                    if (WorldGen.SavedOreTiers.Mythril == -1) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.OrichalcumSlime>();
                    break;
                case 2:
                    if (WorldGen.SavedOreTiers.Adamantite == TileID.Adamantite) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.AdamantiteSlime>();
                    if (WorldGen.SavedOreTiers.Adamantite == -1) return ModContent.NPCType<Content.NPCs.Caverns.HardmodeOre.TitaniumSlime>();
                    break;
            }
            return null;
        }
    }
}
