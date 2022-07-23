using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.General.Necklaces
{
    [AutoloadEquip(EquipType.Front)]
    public class MushroomNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Necklace");
            Tooltip.SetDefault("Increases potency of healing potions");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(copper: 3);
            Item.vanity = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.mushroomNecklace = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.WhiteString, 1).AddIngredient(ItemID.Mushroom, 1).Register();
        }
    }
}