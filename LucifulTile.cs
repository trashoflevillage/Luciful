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
            return true;
        }

        public static bool AttemptExplode(Point position)
        {
            return AttemptExplode(position.X, position.Y);
        }
        public static bool AttemptExplode(Vector2 position)
        {
            return AttemptExplode((int)position.X, (int)position.Y);
        }
        public static bool AttemptExplode(int x, int y)
        {
            if (TileLoader.CanExplode(x, y))
            {
                if (Main.tile[x, y].HasTile) {
                    WorldGen.KillTile(x, y, false, false, false);
                    return true;
                }
            }
            return false;
        }


    }
}
