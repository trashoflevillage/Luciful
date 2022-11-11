using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Luciful
{
    internal class LucifulWorld : ModSystem
    {

        public static List<NPC> NPCs = new List<NPC>();
        
        public override void SaveWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            tag.Add("merfolkStudy", Luciful.Instance.merfolkStudy);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            Luciful.Instance.merfolkStudy = tag.GetBool("merfolkStudy");
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
    }
}
