using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Luciful.Common.Systems.Util;
using Microsoft.Xna.Framework;

namespace Luciful.Common.Systems.GenPasses.Biomes.TheReef
{
    internal class ReefCarver : GenPass
    {
        public ReefCarver(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            Point pos;
            bool dungeonOnLeft;
            int towardsReef;
            if (GenHelper.GetDungeonX() < 2100)
            {
                pos.X = Main.maxTilesX - 340; // Left
                dungeonOnLeft = true;
                towardsReef = -1;
            }
            else
            {
                pos.X = 340; // Right
                dungeonOnLeft = false;
                towardsReef = 1;
            }
            int awayFromReef = towardsReef * -1;
            pos.Y = Main.spawnTileY - 150;
            Tile tile;
            tile = Framing.GetTileSafely(pos);
            while (!tile.HasTile)
            {
                pos.Y++;
                tile = Framing.GetTileSafely(pos);
            }

            int attempts = 0;
            tile = Framing.GetTileSafely(pos);
            while (tile.TileType != TileID.Sand && tile.TileType != TileID.Crimsand && tile.TileType != TileID.Ebonsand)
            {
                if (attempts > 1000) break;

                pos.X += towardsReef;
                attempts++;

                tile = Framing.GetTileSafely(pos);
            }

            WorldGen.PlaceTile(pos.X, pos.Y, TileID.SolarBrick, false, true);

            attempts = 0;
            int oceanX = 0;
            for (int i = pos.X; Framing.GetTileSafely(i, pos.Y).HasTile; i++)
            {
                if (attempts > 1000) break;
                i += towardsReef;
                attempts++;
                oceanX = i;
            }

            Point mod = pos;
            if (dungeonOnLeft)
                mod.X += 215 * towardsReef;
            mod.Y += 231;

            for (int i = mod.Y; i > mod.Y - 100; i--)
                WorldGen.PlaceTile(pos.X, i, TileID.SolarBrick, false, true);
            WorldGen.PlaceTile(pos.X, pos.Y, TileID.NebulaBrick, false, true);
            WorldGen.PlaceTile(oceanX, pos.Y, TileID.VortexBrick, false, true);
        }
    }
}
