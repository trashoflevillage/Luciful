using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Common.Systems.Util;
using Terraria.Utilities;

namespace Luciful.Content.Items.Accessories.General.Necklaces
{
    [AutoloadEquip(EquipType.Front)]
    public class MushroomNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Necklace");
            Tooltip.SetDefault("Increases life regeneration");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(copper: 3);
            LucifulItem modItem = LucifulItem.Convert(Item);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WhiteString, 1)
                .AddIngredient(ItemID.Mushroom, 1)
                .Register();
        }
    }
}