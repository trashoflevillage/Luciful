using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Luciful.Common.Systems.Util.LootHelper;

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

        public static Loot? TrySiftTile(Tile tile)
        {
            if (tile.HasTile)
            {
                if (GetSiftables().Contains(tile.TileType))
                {
                    LootTable lootTable;
                    switch (tile.TileType)
                    {
                        case TileID.Silt: lootTable =  new LootTable(new Loot[] {
                            new Loot(ItemID.PlatinumCoin, 1, 11, 0.000073f),
                            new Loot(ItemID.GoldCoin, 1, 100, 0.001017f),
                            new Loot(ItemID.SilverCoin, 1, 100, 0.003534f),
                            new Loot(ItemID.CopperCoin, 1, 100, 0.642145f),
                            new Loot(ItemID.AmberMosquito, 1, 1, 0.0001f),
                            new Loot(ItemID.Amethyst, 1, 16, 0.003333f),
                            new Loot(ItemID.Topaz, 1, 16, 0.003333f),
                            new Loot(ItemID.Sapphire, 1, 16, 0.003333f),
                            new Loot(ItemID.Emerald, 1, 16, 0.003333f),
                            new Loot(ItemID.Ruby, 1, 16, 0.003333f),
                            new Loot(ItemID.Diamond, 1, 16, 0.003333f),
                            new Loot(ItemID.Amber, 1, 16, 0.009598f),
                            new Loot(ItemID.CopperOre, 1, 16, 0.039192f),
                            new Loot(ItemID.TinOre, 1, 16, 0.039192f),
                            new Loot(ItemID.IronOre, 1, 16, 0.039192f),
                            new Loot(ItemID.LeadOre, 1, 16, 0.039192f),
                            new Loot(ItemID.SilverOre, 1, 16, 0.039192f),
                            new Loot(ItemID.TungstenOre, 1, 16, 0.039192f),
                            new Loot(ItemID.GoldOre, 1, 16, 0.039192f),
                            new Loot(ItemID.PlatinumOre, 1, 16, 0.039192f),
                        }); break;
                        case TileID.Slush: lootTable = new LootTable(new Loot[] {
                            new Loot(ItemID.PlatinumCoin, 1, 11, 0.000073f),
                            new Loot(ItemID.GoldCoin, 1, 100, 0.001017f),
                            new Loot(ItemID.SilverCoin, 1, 100, 0.003534f),
                            new Loot(ItemID.CopperCoin, 1, 100, 0.642145f),
                            new Loot(ItemID.AmberMosquito, 1, 1, 0.0001f),
                            new Loot(ItemID.Amethyst, 1, 16, 0.003333f),
                            new Loot(ItemID.Topaz, 1, 16, 0.003333f),
                            new Loot(ItemID.Sapphire, 1, 16, 0.003333f),
                            new Loot(ItemID.Emerald, 1, 16, 0.003333f),
                            new Loot(ItemID.Ruby, 1, 16, 0.003333f),
                            new Loot(ItemID.Diamond, 1, 16, 0.003333f),
                            new Loot(ItemID.Amber, 1, 16, 0.009598f),
                            new Loot(ItemID.CopperOre, 1, 16, 0.039192f),
                            new Loot(ItemID.TinOre, 1, 16, 0.039192f),
                            new Loot(ItemID.IronOre, 1, 16, 0.039192f),
                            new Loot(ItemID.LeadOre, 1, 16, 0.039192f),
                            new Loot(ItemID.SilverOre, 1, 16, 0.039192f),
                            new Loot(ItemID.TungstenOre, 1, 16, 0.039192f),
                            new Loot(ItemID.GoldOre, 1, 16, 0.039192f),
                            new Loot(ItemID.PlatinumOre, 1, 16, 0.039192f),
                        }); break;
                        case TileID.DesertFossil: lootTable = new LootTable(new Loot[] {
                            new Loot(ItemID.FossilOre, 1, 1, 0.1f),
                            new Loot(ItemID.PlatinumCoin, 1, 11, 0.000066f),
                            new Loot(ItemID.GoldCoin, 1, 100, 0.000915f),
                            new Loot(ItemID.SilverCoin, 1, 100, 0.012178f),
                            new Loot(ItemID.CopperCoin, 1, 100, 0.577876f),
                            new Loot(ItemID.AmberMosquito, 1, 100, 0.0027f),
                            new Loot(ItemID.Amethyst, 1, 16, 0.0015f),
                            new Loot(ItemID.Topaz, 1, 16, 0.0015f),
                            new Loot(ItemID.Sapphire, 1, 16, 0.0015f),
                            new Loot(ItemID.Emerald, 1, 16, 0.0015f),
                            new Loot(ItemID.Ruby, 1, 16, 0.0015f),
                            new Loot(ItemID.Diamond, 1, 16, 0.0015f),
                            new Loot(ItemID.Amber, 1, 16, 0.017629f),
                            new Loot(ItemID.CopperOre, 1, 16, 0.035259f),
                            new Loot(ItemID.TinOre, 1, 16, 0.035259f),
                            new Loot(ItemID.IronOre, 1, 16, 0.035259f),
                            new Loot(ItemID.LeadOre, 1, 16, 0.035259f),
                            new Loot(ItemID.SilverOre, 1, 16, 0.035259f),
                            new Loot(ItemID.TungstenOre, 1, 16, 0.035259f),
                            new Loot(ItemID.GoldOre, 1, 16, 0.035259f),
                            new Loot(ItemID.PlatinumOre, 1, 16, 0.035259f),
                        }); break;
                        default: return null;
                    }
                    return lootTable.NextLoot();
                }
            }
            return null;
        }


        public static ushort[] GetSiftables()
        {
            ushort[] output = new ushort[3] { TileID.Slush, TileID.Silt, TileID.DesertFossil };
            return output;
        }
    }
}
