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
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            Luciful.Instance.merfolkStudy = tag.GetBool("merfolkStudy");
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
