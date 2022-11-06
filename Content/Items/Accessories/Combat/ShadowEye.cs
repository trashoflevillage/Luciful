using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Luciful.Common.Systems.Util;

namespace Luciful.Content.Items.Accessories.Combat
{
    public class ShadowEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Shadow");
            Tooltip.SetDefault("When attacking an enemy with 1/4 health or less, you are guaranteed to land a critical strike\n+5% critical strike chance\nYou can feel it staring back at you.");
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 5);
            Item.maxStack = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += 0.05f;
        }

        public override void AddRecipes()
        {
        }
    }
}