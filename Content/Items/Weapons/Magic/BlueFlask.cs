using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Luciful.Content.Items.Weapons.Magic
{
    public class BlueFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ToxicFlask); // Copies all the properties of the Toxic Flask

			Item.shoot = ModContent.ProjectileType<Projectiles.Magic.BlueFlask.BlueFlaskProjectile>();

			Item.damage = 15;
			Item.shootSpeed *= 0.90f;
			Item.mana = 5;
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
		}
	}
}