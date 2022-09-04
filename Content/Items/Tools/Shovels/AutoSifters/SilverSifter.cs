using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;
using Microsoft.Xna.Framework;

namespace Luciful.Content.Items.Tools.Shovels.AutoSifters
{
    internal class SilverSifter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Sifter");
            Tooltip.SetDefault("Sifts tiles in a large area");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 28;
            modItem.autoSift = true;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item22;

            Item.channel = true;

            Item.useTime = 30;
            Item.useAnimation = 30;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 15)
                .AddTile(TileID.Anvils)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
