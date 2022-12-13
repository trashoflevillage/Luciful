using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Luciful.Common.Systems;
using Terraria.GameContent.Creative;

namespace Luciful.Content.Items.Weapons.Commander
{
    public class Harplane : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		
		public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = ModContent.GetInstance<DamageClasses.Commander>();
			Item.width = 16;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.autoReuse = true;
			Item.damage = 9;
			Item.knockBack = 0;
			Item.crit = 6;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item64;
			Item.shoot = ModContent.ProjectileType<Projectiles.Commander.HarplaneProjectile>();
			Item.shootSpeed = 30;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

        public override void AddRecipes()
        {
			CreateRecipe(1)
				.AddIngredient(ItemID.PaperAirplaneA)
				.AddIngredient(ItemID.Feather, 2)
				.AddIngredient(ItemID.Cloud, 5)
				.AddTile(TileID.SkyMill)
				.Register();
        }
    }
}
