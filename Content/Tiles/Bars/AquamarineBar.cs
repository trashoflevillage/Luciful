using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Luciful.Content.Tiles.Bars
{
    internal class AquamarineBar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true; // Acts similar to a platform.
            Main.tileFrameImportant[Type] = true; // ???
            Main.tileMergeDirt[Type] = true; // Defines that the tile blends with dirt.
            Main.tileBlockLight[Type] = true; // Defines that light does not pass through this tile.
            Main.tileShine[Type] = 1100; // How often the tile sparkles!
            Main.tileShine2[Type] = true; // Color variation.
            Main.tileSpelunker[Type] = true; // Glows when using a Spelunker Potion.

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(224, 194, 101), Language.GetText("Metal Bar")); // Pretty self explanitory.
        }


        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameX / 18;

            // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
            if (style == 0)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeables.Bars.AquamarineBar>());
            }

            return base.Drop(i, j);
        }
    }
}
