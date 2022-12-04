using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Common.Systems.Util;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    [AutoloadEquip(EquipType.HandsOff)]
    public class SapphireGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.meleeWeaponScale = 0.75f;
            modPlayer.bonusMeleeSpeed -= 0.20f;
            player.GetDamage(DamageClass.Melee) += 0.03f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<SilkGlove>(), 1).AddIngredient(ItemID.Sapphire, 3).AddTile(TileID.Anvils).Register();
        }
    }
}