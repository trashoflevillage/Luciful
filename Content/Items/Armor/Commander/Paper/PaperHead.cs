using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Luciful.Content.Items.Armor.Commander.Paper
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class PaperHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24; // Width of the item
            Item.height = 20; // Height of the item
            Item.value = Item.sellPrice(silver: 15); // How many coins the item is worth
            Item.rare = ItemRarityID.White; // The rarity of the item
            Item.defense = 1; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            //return body.type == ModContent.ItemType<BronzeBreastplate>() && legs.type == ModContent.ItemType<BronzeLegs>();
            return false;
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mod.Luciful.SetBonus.Paper"); // This is the setbonus tooltip
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient(ModContent.ItemType<Materials.Paper>(), 8).AddIngredient(ItemID.BambooBlock, 5).AddTile(TileID.WorkBenches).Register();
        }
    }
}