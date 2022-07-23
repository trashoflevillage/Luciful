using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class AquamarineBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Surge");
			Tooltip.SetDefault("Shoots 2 arrows at a time");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			LucifulItem modItem = LucifulItem.Convert(Item);
			modItem.bonusProjectiles = 1;
			modItem.projectileSpread = 5f;
			modItem.spreadVariation = 0f;

			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 20);

			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = false;

			Item.UseSound = SoundID.Item5;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 20;
			Item.knockBack = 2f;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(7f, -1f);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(ModContent.ItemType<AquamarineBar>(), 15).AddTile(TileID.Anvils).Register();
		}
	}
}
