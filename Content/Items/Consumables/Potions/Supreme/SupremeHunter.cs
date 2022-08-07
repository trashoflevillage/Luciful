using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Luciful.Content.Rarities;
using Luciful.Content.Items.Materials.Essence;

namespace Luciful.Content.Items.Consumables.Potions.Supreme
{
	public class SupremeHunter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supreme Hunter Potion");
			Tooltip.SetDefault("Grants the effects of Hunter for a very long time\nNot Consumable");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.rare = ModContent.RarityType<Contracted>();
			Item.value = Item.sellPrice(silver: 80);
		}

        public override void UseAnimation(Player player)
		{
			LucifulPlayer modPlayer = LucifulPlayer.Convert(player);
			modPlayer.infiniteBuffs.Add(BuffID.Hunter);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HunterPotion)
				.AddIngredient(ModContent.ItemType<EyeOfCthulhuEssence>(), 1)
				.AddTile(TileID.Anvils).Register();
		}
	}
}