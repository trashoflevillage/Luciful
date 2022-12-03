using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class GoldenGlory : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			LucifulItem modItem = LucifulItem.Convert(Item);
			modItem.bonusProjectiles = 5;
			modItem.projectileSpread = 5f;
			modItem.speedVariation = 0.2f;

			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 1);

			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = false;

			Item.UseSound = SoundID.Item36;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 16;
			Item.knockBack = 2f;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(3.5f, -1f);
		}

		public override void AddRecipes()
		{
		}
	}
}
