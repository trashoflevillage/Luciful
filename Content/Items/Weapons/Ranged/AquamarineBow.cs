using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class AquamarineBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aquamarine Bow");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;

			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = false;

			Item.UseSound = SoundID.Item5;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 31;
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
			return new Vector2(7f, -2f);
		}
	}
}
