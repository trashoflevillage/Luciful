using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Tools.Shovels
{
    internal class PalladiumShovel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Shovel");
            Tooltip.SetDefault("Digs in a bigger area than a pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GravediggerShovel);

            LucifulItem modItem = LucifulItem.Convert(Item);
            modItem.shovelPower = 65;
            
            Item.useTime = 15;
            Item.useAnimation = 15;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PalladiumBar, 12)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
