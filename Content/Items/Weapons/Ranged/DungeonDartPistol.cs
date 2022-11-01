﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables.Bars;
using Terraria.DataStructures;

namespace Luciful.Content.Items.Weapons.Ranged
{
	public class DungeonDartPistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Dartler");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.DartPistol);
			Item.width = 18;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(gold: 1, silver: 50);

			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;

			Item.UseSound = SoundID.Item98;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 20;
			Item.knockBack = 5f;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.useAmmo = AmmoID.Dart; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4.5f, 1.5f);
		}

		public override void AddRecipes()
		{
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			position.Y -= 0.5f;
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}