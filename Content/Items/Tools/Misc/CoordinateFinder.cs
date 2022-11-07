using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;
using Microsoft.Xna.Framework;
using Luciful.Common.Systems.GenPasses;

namespace Luciful.Content.Items.Tools.Misc
{
    internal class CoordinateFinder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coordinate Finder");
            Tooltip.SetDefault("'Superb for impersonating devs!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.UseSound = SoundID.Item92;

            Item.rare = ItemRarityID.Quest;
        }

        public override bool? UseItem(Player player)
        {
            Point mouse = Main.MouseWorld.ToTileCoordinates();
            Main.NewText($"{mouse}");
            return base.UseItem(player);
        }
    }
}
