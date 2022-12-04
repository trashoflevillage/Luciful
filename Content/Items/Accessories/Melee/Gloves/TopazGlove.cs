using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Luciful.Common.Systems.Util;

namespace Luciful.Content.Items.Accessories.Melee.Gloves
{
    [AutoloadEquip(EquipType.HandsOff)]
    public class TopazGlove : ModItem
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
            Item.value = Item.sellPrice(silver: 20);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.meleeWeaponScale = 0.5f;
            modPlayer.bonusMeleeSpeed -= 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.02f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<SilkGlove>(), 1).AddIngredient(ItemID.Topaz, 3).AddTile(TileID.Anvils).Register();
        }
    }
}