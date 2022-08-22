using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Weapons.Melee
{
    internal class ElementalBoomerang : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Boomerang");
			Tooltip.SetDefault
				("Alternates between throwing Ice Boomerangs and Flamarangs" +
                "\nYou can throw multiple at a time" +
                "\nFlamarangs inflict On Fire!" +
                "\nIce Boomerangs inflict Frostburn");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WoodenBoomerang);

			Item.damage = 36;
			Item.useTime = 8;
			Item.shootSpeed = 16f;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.ElementalBoomerang.DualityFlame>();

			Item.rare = ItemRarityID.Orange;
		}

        public override bool? UseItem(Player player)
		{
			LucifulItem modItem = LucifulItem.Convert(Item);
			if (modItem.genericTracker1 == 0)
			{
				Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.ElementalBoomerang.DualityFrost>();
				modItem.genericTracker1 = 1;
			}
			else
			{
				Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.ElementalBoomerang.DualityFlame>();
				modItem.genericTracker1 = 0;
			}
			return true;
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Flamarang)
				.AddIngredient(ItemID.IceBoomerang)
				.AddTile(TileID.Anvils).Register();
		}
	}
}
