using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class DungeonDartRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Neutralizer");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.DartRifle);
			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(gold: 1, silver: 50);

			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item99;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 45;
			Item.knockBack = 5f;
			Item.noMelee = true;
			
			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.useAmmo = AmmoID.Dart; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8f, 2f);
		}

		public override void AddRecipes()
		{
		}
	}
}
