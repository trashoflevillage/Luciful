using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Ammo
{
    public class AquamarineArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whirlpool Arrow"); // The item's description, can be set to whatever you want.
			Tooltip.SetDefault("Bounces back after hitting a wall\nDoes not attempt to bounce towards enemies\nIgnores water"); // The item's description, can be set to whatever you want.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.Arrows.AquamarineArrow>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 2f; // The speed of the projectile.
			Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(100).AddIngredient(ItemID.WoodenArrow, 100).AddIngredient(ModContent.ItemType<AquamarineBar>(), 1).AddTile(TileID.Anvils).Register();
		}
	}
}