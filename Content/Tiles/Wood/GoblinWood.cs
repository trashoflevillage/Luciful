using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Luciful.Content.Tiles.Wood
{
    internal class GoblinWood : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true; // Defines the tile as an ore.

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true; // Defines that light does not pass through this tile.

            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileMerge[TileID.BorealWood][Type] = true;
            Main.tileMerge[TileID.DynastyWood][Type] = true;
            Main.tileMerge[TileID.LivingWood][Type] = true;
            Main.tileMerge[TileID.PalmWood][Type] = true;
            Main.tileMerge[TileID.SpookyWood][Type] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;
            Main.tileMerge[TileID.HallowedIce][Type] = true;
            Main.tileMerge[TileID.CorruptIce][Type] = true;
            Main.tileMerge[TileID.FleshIce][Type] = true;
            Main.tileMerge[TileID.SnowBlock][Type] = true;

            AddMapEntry(new Color(102, 62, 6)); // Pretty self explanitory.

            DustType = DustID.DynastyWood;
            ItemDrop = ModContent.ItemType<Items.Placeables.Wood.GoblinWood>();
            HitSound = SoundID.Dig;

            MineResist = 2f; // How long the ore takes to mine.
            MinPick = 110; // Pick power needed to mine.
        }
    }
}
