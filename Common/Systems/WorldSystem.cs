﻿using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Luciful.Common.Systems.GenPasses;

namespace Luciful.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
            if (shiniesIndex != -1) 
            {
                tasks.Insert(shiniesIndex + 1, new AquamarineOreGenPass("Aquamarine Ore Pass", 320f));
                tasks.Insert(shiniesIndex + 1, new CopperOreGenPass("Inflating the copper economy", 320f));
                tasks.Insert(shiniesIndex + 1, new TinOreGenPass("Inflating the tin economy", 320f));
            }
        }
    }
}
