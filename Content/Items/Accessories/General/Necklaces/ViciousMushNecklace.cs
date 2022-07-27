using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.General.Necklaces
{
    [AutoloadEquip(EquipType.Front)]
    public class ViciousMushNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vicious Mushroom Necklace");
            Tooltip.SetDefault("Inflict Diluted Ichor on hit");

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
            modPlayer.inflictDilutedIchor += 180;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WhiteString, 1)
                .AddIngredient(ItemID.ViciousMushroom, 1)
                .AddIngredient(ItemID.TissueSample, 5)
                .Register();
        }
    }
}