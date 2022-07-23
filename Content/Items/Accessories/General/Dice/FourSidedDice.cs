using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories.General.Dice
{
    public class FourSidedDice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Four Sided Dice");
            Tooltip.SetDefault("Increases critical strike chance by 4%");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(copper: 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            player.GetCritChance(DamageClass.Generic) += 0.4f;
        }

        public override void AddRecipes()
        {
        }
    }
}