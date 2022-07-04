using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Accessories.Melee.Gloves.Gauntlets
{
    public class MightGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gauntlet of Might");
            Tooltip.SetDefault("Increases melee weapon size by 150%\n30% decreased melee speed\nHandy for true melee!\nHopefully I don't forget to add effects later!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4)); // ticksperframe, frames
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.mightGauntlet = true;
            player.GetAttackSpeed(DamageClass.Melee) -= 0.30f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<AmethystGlove>(), 1)
                .AddIngredient(ModContent.ItemType<TopazGlove>(), 1)
                .AddIngredient(ModContent.ItemType<SapphireGlove>(), 1)
                .AddIngredient(ModContent.ItemType<EmeraldGlove>(), 1)
                .AddIngredient(ModContent.ItemType<RubyGlove>(), 1)
                .AddIngredient(ModContent.ItemType<AmberGlove>(), 1)
                .AddIngredient(ModContent.ItemType<DiamondGlove>(), 1)
                .AddIngredient(ItemID.HallowedBar, 8)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddTile(TileID.MythrilAnvil).Register();
        }
    }
}