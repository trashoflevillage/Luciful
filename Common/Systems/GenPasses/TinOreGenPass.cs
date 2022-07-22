using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Luciful.Content.Tiles;

namespace Luciful.Common.Systems.GenPasses
{
    internal class TinOreGenPass : GenPass
    {
        public TinOreGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            int maxToSpawn = WorldGen.genRand.Next(500, 1000);
            int numSpawned = 0;
            int attempts = 0;
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX); // Gets a random position on the X axis.
                int y = WorldGen.genRand.Next(0, Main.maxTilesY); // Gets a random position on the Y axis.

                Tile tile = Framing.GetTileSafely(x, y); // Gets the tile at those coordinates.
                if (tile.TileType == TileID.Stone || tile.TileType == TileID.Dirt || tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock || tile.TileType == TileID.Mud)      // || == OR
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(10, 15), TileID.Tin);
                    numSpawned++;
                }

                attempts++;
                if (attempts >= 10000) break;
            }
        }
    }
}
