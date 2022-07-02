using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables;

namespace Luciful.Content.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class AquamarineRangedHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Aquamarine Helmet");
			Tooltip.SetDefault("5% increased ranged critical strike chance\n8% increased ranged damage");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(silver: 20); // How many coins the item is worth
			Item.rare = ItemRarityID.Orange; // The rarity of the item
			Item.defense = 4; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 0.5f;
			player.GetDamage(DamageClass.Ranged) += 0.8f;
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AquamarineBreastplate>() && legs.type == ModContent.ItemType<AquamarineLegs>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased ranged speed"; // This is the setbonus tooltip
			player.GetAttackSpeed(DamageClass.Ranged) += 0.05f; // Increase dealt damage for all weapon classes by 20%
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineBar>(), 12).AddTile(TileID.Anvils).Register();
		}
	}
}