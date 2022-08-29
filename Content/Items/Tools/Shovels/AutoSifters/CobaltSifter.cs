using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Shovels.AutoSifters
{
    internal class CobaltSifter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Sifter");
            Tooltip.SetDefault("Digs in a bigger area than a pickaxe\nAutomatically sifts tiles");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 65;
            modItem.autoSift = true;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item22;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 12)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
