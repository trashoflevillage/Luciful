using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Armor.Summoner.Gel
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class GelHead : ModItem
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
            player.GetCritChance(DamageClass.Summon) += 0.02f;
            player.statManaMax2 += 20;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GelBreastplate>() && legs.type == ModContent.ItemType<GelLegs>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.Luciful.SetBonus.Gel"); // This is the setbonus tooltip
            player.AddBuff(BuffID.BabySlime, -1);
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ItemID.Gel, 10).AddTile(TileID.Solidifier).Register();
        }
    }
}