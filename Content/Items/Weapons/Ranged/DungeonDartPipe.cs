using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables.Bars;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class DungeonDartPipe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Piper");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Blowgun);
			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(gold: 1, silver: 50);

			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item64;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 32;
			Item.knockBack = 5f;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.useAmmo = AmmoID.Dart; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(7f, -7f);
		}

		public override void AddRecipes()
		{
		}
	}
}
