using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Luciful.Content.Items.Weapons.Magic
{
    public class HungrySpell : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tome of Hunger");
			Tooltip.SetDefault("Summons a hungry, fleshy mass that will munch on anything in its path\nEnemies have a chance of dropping hearts when struck");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.shoot = ModContent.ProjectileType<Projectiles.Magic.HungryTome.Hungry>();
			Item.shootSpeed = 35;

			Item.damage = 90;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 50;
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.UseSound = SoundID.NPCHit9;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(gold: 5);
		}

		public override void AddRecipes()
		{
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity.X *= 0.65f;
			velocity.Y *= 0.65f;
			knockback += 1;
			base.ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
        }
    }
}