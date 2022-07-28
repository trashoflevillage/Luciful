using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Luciful.Content.Tiles;

namespace Luciful.Common.Systems.GenPasses.Ores
{
    internal class AquamarineOreGenPass : GenPass
    {
        public AquamarineOreGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int maxToSpawn = WorldGen.genRand.Next(500, 1000);
            int numSpawned = 0;
            int attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX); // Gets a random position on the X axis.
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY-150); // Gets a random position on the Y axis.

                Tile tile = Framing.GetTileSafely(x, y); // Gets the tile at those coordinates.
                if (tile.TileType == TileID.Stone || tile.TileType == TileID.Dirt || tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock || tile.TileType == TileID.Mud)      // || == OR
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(2, 4), ModContent.TileType<AquamarineOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts >= 10000) break;
            }
        }
    }
}
