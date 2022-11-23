using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.DataStructures;
using Luciful.Content.Tiles;
using Microsoft.Xna.Framework;

namespace Luciful.Common.Systems.GenPasses.Structures
{
    internal class FracturedAltarGenPass : GenPass
    {
        public FracturedAltarGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            Vector2 selectedPos = new Vector2(0, (float)Main.worldSurface);
            for (int i = 0; i < Main.maxTilesX/2; i++)
            {
                selectedPos.Y = (float) Main.worldSurface;
                selectedPos.X = Main.maxTilesX / 2 + i;
                while (!Framing.GetTileSafely(selectedPos).HasTile) selectedPos.Y++;
                if (TryGenerateAltar(selectedPos)) break;
                selectedPos.X = Main.maxTilesX / 2 - i;
                while (!Framing.GetTileSafely(selectedPos).HasTile) selectedPos.Y++;
                if (TryGenerateAltar(selectedPos)) break;
            }
        }

        private bool TryGenerateAltar(Vector2 pos)
        {
            ushort evilTile;
            ushort evilGrass;
            int fracturedAltar;

            if (WorldGen.crimson)
            {
                evilTile = TileID.Crimstone;
                evilGrass = TileID.CrimsonGrass;
                fracturedAltar = ModContent.TileType<Content.Tiles.Furniture.CraftingStations.FracturedAltarCrimson>();
            }
            else
            {
                evilTile = TileID.Ebonstone;
                evilGrass = TileID.CorruptGrass;
                fracturedAltar = ModContent.TileType<Content.Tiles.Furniture.CraftingStations.FracturedAltarCorruption>();
            }

            int foundTile = Framing.GetTileSafely(pos).TileType;
            if (foundTile == evilTile || foundTile == evilGrass)
            {
                WorldGen.PlaceTile((int)pos.X, (int)pos.Y, TileID.DiamondGemspark, false, true);
            }
            else return false;
            return true;
        }
    }
}
