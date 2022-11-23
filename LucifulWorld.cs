using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria.WorldBuilding;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulWorld : ModSystem
    {

        public static List<NPC> NPCs = new List<NPC>();
        
        public override void SaveWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            tag.Add("merfolkStudy", Luciful.Instance.merfolkStudy);
            tag.Add("flipperShop", Luciful.Instance.flipperShop.ToArray());
            tag.Add("flipperShopOld", Luciful.Instance.flipperShopOld);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            Luciful.Instance.merfolkStudy = tag.GetBool("merfolkStudy");
            Luciful.Instance.flipperShop = tag.GetIntArray("flipperShop").ToList();
            Luciful.Instance.flipperShopOld = tag.GetIntArray("flipperShopOld");
        }

        public override void PostUpdateEverything()
        {
            Luciful instance = Luciful.Instance;
            List<NPC> removeNPCs = new List<NPC>();
            foreach (NPC i in NPCs.Where(n => !n.active))
            {
                if (i.life > 0)
                    LucifulNPC.OnDespawn(i);
                removeNPCs.Add(i);
            }
            foreach (NPC i in removeNPCs)
            {
                NPCs.Remove(i);
            }

            //if (instance.bossBorder != null) instance.bossBorder.Tick();
        }
        public override void AddRecipeGroups()
        {
        }

        public override void ModifyHardmodeTasks(List<GenPass> list)
        {
            list.Add(new Common.Systems.GenPasses.Chests.CobaltChest("Generating Cobalt Chests", 1f));
        }
    }
}
