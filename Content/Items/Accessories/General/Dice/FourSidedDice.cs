using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.General.Dice
{
    [AutoloadEquip(EquipType.Front)]
    public class FourSidedDice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Four Sided Dice");
            Tooltip.SetDefault("Increases damage output anywhere from 1-4%");

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
            modPlayer.fourSidedDice = true;
        }

        public override void AddRecipes()
        {
        }
    }
}