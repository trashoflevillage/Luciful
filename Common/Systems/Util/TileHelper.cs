using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace Luciful.Common.Systems.Util
{
    internal class TileHelper
    {
        public static bool IsSoft(Tile tile)
        {
            if (GetSoftTiles().Contains(tile.TileType)) return true;
            return false;
        }

        public static List<ushort> GetSoftTiles()
        {
            List<ushort> softTiles = new List<ushort>();
            {
                softTiles.Add(TileID.Ash);
                softTiles.Add(TileID.ClayBlock);
                softTiles.Add(TileID.CorruptGrass);
                softTiles.Add(TileID.Crimsand);
                softTiles.Add(TileID.CrimsonGrass);
                softTiles.Add(TileID.Dirt);
                softTiles.Add(TileID.Ebonsand);
                softTiles.Add(TileID.Grass);
                softTiles.Add(TileID.HallowedGrass);
                softTiles.Add(TileID.JungleGrass);
                softTiles.Add(TileID.Mud);
                softTiles.Add(TileID.GolfGrass);
                softTiles.Add(TileID.GolfGrassHallowed);
                softTiles.Add(TileID.MushroomGrass);
                softTiles.Add(TileID.Pearlsand);
                softTiles.Add(TileID.Sand);
                softTiles.Add(TileID.Silt);
                softTiles.Add(TileID.Slush);
                softTiles.Add(TileID.ShellPile);
                softTiles.Add(TileID.SnowBlock);
            }
            return softTiles;
        }
    }
}
