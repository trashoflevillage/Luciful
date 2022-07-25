using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Luciful.Content.Tiles
{
    internal class BlueFlask : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = false; // Acts similar to a platform.
            Main.tileFrameImportant[Type] = true; // ???
            Main.tileMergeDirt[Type] = false; // Defines that the tile blends with dirt.
            Main.tileBlockLight[Type] = false; // Defines that light does not pass through this tile.
            Main.tileShine[Type] = 1100; // How often the tile sparkles!
            Main.tileShine2[Type] = true; // Color variation.
            Main.tileSpelunker[Type] = true; // Glows when using a Spelunker Potion.

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(15, 224, 252), Language.GetText("Blue Flask")); // Pretty self explanitory.
        }


        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameX / 18;

            // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
            if (style == 0)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Weapons.Magic.BlueFlask>());
            }

            return base.Drop(i, j);
        }
    }
}
