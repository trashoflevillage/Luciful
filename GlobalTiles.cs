using Terraria;
using Terraria.ModLoader;

namespace Luciful
{
    internal class GlobalTiles : GlobalTile
    {
        public override bool CanExplode(int x, int y, int type)
        {
            if (Main.tile[x, y].TileType == ModContent.TileType<Content.Tiles.Wood.GoblinWood>()) return false;
            return true;
        }
    }
}
