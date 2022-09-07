using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.ID;

namespace Luciful.Common.Systems.GenPasses
{
    internal class GenHelper
    {
        public static int GetWorldSizeMultiplier(int width)
        {
            return (width / 4200) * 2;
        }

        public static int GetDungeonX()
        {
            for (int x = 0; x <= Main.maxTilesX; x++)
            {
                Tile tile = Framing.GetTileSafely(x, 934);
                if (tile.TileType == TileID.BlueDungeonBrick ||
                    tile.TileType == TileID.GreenDungeonBrick ||
                    tile.TileType == TileID.PinkDungeonBrick)
                {
                    return x;
                }
            }
            return 7405;
        }
    }
}
