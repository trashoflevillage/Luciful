using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.General.Necklaces
{
    [AutoloadEquip(EquipType.Front)]
    public class VileMushNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vile Mushroom Necklace");
            Tooltip.SetDefault("Inflict Cursed Spark on hit");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 3);
            Item.vanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = LucifulPlayer.Convert(player);
            modPlayer.inflictCursedSpark += 180;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WhiteString, 1)
                .AddIngredient(ItemID.VileMushroom, 1)
                .AddIngredient(ItemID.ShadowScale, 5)
                .Register();
        }
    }
}