using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.DataStructures;
using Luciful.Content.Tiles;

namespace Luciful.Common.Systems.GenPasses.Structures
{
    internal class GoldenGloryIslandGenPass : GenPass
    {
        public GoldenGloryIslandGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int maxToSpawn = 1;
            int numSpawned = 0;
            int attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(60, Main.maxTilesX-60); // Gets a random position on the X axis.
                int y = WorldGen.genRand.Next(90, 115); // Gets a random position on the Y axis.

                Tile tile = Framing.GetTileSafely(x, y); // Gets the tile at those coordinates.
                if (tile.HasTile == false)
                {
                    string path = "Content/Structures/GoldenGloryIsland";
                    Point16 position = new(x, y);
                    StructureHelper.Generator.GenerateStructure(path, position, Luciful.Instance);
                    numSpawned++;
                }
                else
                {
                    attempts++;
                    if (attempts >= 10000)
                    {
                        string path = "Content/Structures/GoldenGloryIsland";
                        Point16 position = new(x, y);
                        StructureHelper.Generator.GenerateStructure(path, position, Luciful.Instance);
                        break;
                    }
                }
            }
        }
    }
}
