﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Luciful.Content.Tiles
{
    internal class AquamarineOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true; // Defines the tile as an ore.

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true; // Defines that the tile blends with dirt.
            Main.tileBlockLight[Type] = true; // Defines that light does not pass through this tile.
            Main.tileShine[Type] = 900; // How often the tile sparkles!
            Main.tileShine2[Type] = true; // Color variation.
            Main.tileSpelunker[Type] = true; // Glows when using a Spelunker Potion.
            Main.tileOreFinderPriority[Type] = 590; // Metal Detector Priority

            AddMapEntry(new Color(66, 183, 255), Language.GetText("Aquamarine")); // Pretty self explanitory.

            DustType = DustID.Cobalt;
            ItemDrop = ModContent.ItemType<Items.Placeables.AquamarineOre>();
            HitSound = SoundID.Tink;

            MineResist = 2.5f; // How long the ore takes to mine.
            MinPick = 65; // Pick power needed to mine.
        }
    }
}
