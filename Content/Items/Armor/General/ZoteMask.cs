using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Armor.General
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class ZoteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Odd Mask");
            Tooltip.SetDefault("You feel increadibly weak whilst wearing this\n'Losing a battle earns you nothing and teaches you nothing.\nWin your battles, or don't engage in them at all!'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40; // Width of the item
            Item.height = 46; // Height of the item
            Item.value = Item.sellPrice(0); // How many coins the item is worth
            Item.rare = ItemRarityID.Purple; // The rarity of the item
            Item.defense = 1; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) -= 100f;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return false;
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
        }

        public override void AddRecipes()
        {
        }
    }
}