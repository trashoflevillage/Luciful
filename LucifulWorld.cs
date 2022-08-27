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
            //instance.bossBorder = null;
            List<string> lucifulData = new List<string>();
            foreach (KeyValuePair<string, bool> i in instance.bossesKilled)
                if (i.Value) lucifulData.Add("defeated" + i.Key);
            //if (instance.contractSigned) lucifulData.Add("contractSigned");
            tag.Add("lucifulData", lucifulData);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            //instance.bossBorder = null;
            instance.bossesKilled.Clear();

            IList<string> lucifulData = tag.GetList<string>("lucifulData");
            foreach (string i in lucifulData)
                if (i.Contains("defeated")) instance.bossesKilled.Add(i, true);
            //if (lucifulData.Contains("contractSigned")) instance.contractSigned = true; else instance.contractSigned = false;
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
