using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Armor.Melee.Granite
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class GraniteHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(silver: 20); // How many coins the item is worth
            Item.rare = ItemRarityID.Blue; // The rarity of the item
            Item.defense = 3; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 0.05f;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GraniteBreastplate>() && legs.type == ModContent.ItemType<GraniteLegs>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            player.setBonus = Language.GetTextValue("Mod.Luciful.SetBonus.Granite"); // This is the setbonus tooltip
            modPlayer.bonusMeleeSpeed += 0.05f; // Increase dealt damage for all weapon classes by 20%
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.Granite, 10).AddTile(TileID.HeavyWorkBench).Register();
        }
    }
}