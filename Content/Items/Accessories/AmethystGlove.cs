using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Content.Items.Accessories
{
	public class AmethystGlove : ModItem
	{
        private float SizeIncrease = 6f;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Infused Glove");
			Tooltip.SetDefault("Increases melee weapon size");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.HeldItem.CountsAsClass(DamageClass.Melee))
			{
                GlobalItem.ModifyItemScale(player.HeldItem, player, ref SizeIncrease);
			}
		}
	}
}