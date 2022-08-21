using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Luciful
{
    internal class LucifulTile : GlobalTile
    {
        public override bool CanExplode(int x, int y, int type)
        {
            if (Main.tile[x, y].TileType == ModContent.TileType<Content.Tiles.Wood.GoblinWood>()) return false;
            return true;
        }
        public static bool AttemptExplode(Vector2 position)
        {
            return AttemptExplode((int)position.X, (int)position.Y);
        }

        public static bool AttemptExplode(int x, int y)
        {
            if (TileLoader.CanExplode(x, y))
            {
                bool a = false;
                TileLoader.KillTile(x, y, Main.tile[x, y].TileType, ref a, ref a, ref a);
                return true;
            }
            else return false;
        }


    }
}
