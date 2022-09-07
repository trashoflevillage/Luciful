using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Luciful.Common.Systems.GenPasses.Ores;
using Luciful.Common.Systems.GenPasses.Biomes.TheReef;
using Luciful.Common.Systems.GenPasses.Structures;

namespace Luciful.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
            if (shiniesIndex != -1) 
            {
                tasks.Insert(shiniesIndex + 1, new AquamarineOreGenPass("Generating aquatic treasures", 320f));
                tasks.Insert(shiniesIndex + 1, new CopperOreGenPass("Inflating the copper economy", 320f));
                tasks.Insert(shiniesIndex + 1, new TinOreGenPass("Inflating the tin economy", 320f));
                tasks.Insert(shiniesIndex + 1, new DesertLaboratoryGenPass("Simulating Albuquerque", 10f));
            }
            int trapsIndex = tasks.FindIndex(t => t.Name.Equals("Traps"));
            if (trapsIndex != -1)
            {
                tasks.Insert(trapsIndex + 1, new DesertLaboratoryGenPass("Simulating Albuquerque", 10f));
                tasks.Insert(trapsIndex + 1, new GoldenGloryIslandGenPass("Adding Sky Guns", 10f));
            }
            int slushIndex = tasks.FindIndex(t => t.Name.Equals("Slush"));
            if (slushIndex != -1)
                tasks.Insert(slushIndex + 1, new EvilOreGenPass("Inflating the evil economy", 320f));
            /* Since the goal of this GenPass is to increase the abundance of the evil ore in evil biomes, it is used in the slush index because
                the world doesn't generate corruption until after ores are generated, whereas slush is immediately after corruption.*/
            int beachIndex = tasks.FindIndex(t => t.Name.Equals("Final Cleanup"));
            if (beachIndex != -1)
            {
                tasks.Insert(beachIndex - 1, new ReefCarver("Extending the ocean", 10f));
            }
        }
    }
}
