using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Shovels
{
    internal class DemoniteShovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Spade");
            Tooltip.SetDefault("Digs in a bigger area than a pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 35;
            
            Item.useTime = 15;
            Item.useAnimation = 15;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 12)
                .AddIngredient(ItemID.ShadowScale, 6)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
