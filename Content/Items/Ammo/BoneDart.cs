using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Ammo
{
    public class BoneDart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necro Dart"); // The item's description, can be set to whatever you want.
			Tooltip.SetDefault("Victim's defense temporarily lowers with health"); // The item's description, can be set to whatever you want.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PoisonDart);
			Item.damage = 13; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 9999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 2f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<Projectiles.Darts.BoneDart>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 2f; // The speed of the projectile.
			Item.ammo = AmmoID.Dart; // The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(100).AddIngredient(ItemID.Bone, 1).AddTile(TileID.BoneWelder).Register();
		}
	}
}