using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Materials.Essence
{
    public class EyeOfCthulhuEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Beast's Eye");
            Tooltip.SetDefault("A powerful material made of concentrated energy from Cthulhu's eye");

            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 9999;
            Item.rare = ModContent.RarityType<Rarities.Contracted>();
            Item.value = Item.sellPrice(gold: 5);
        }
    }
}