using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Global;

namespace Luciful.Content.Items.Accessories
{
	public class AmethystGlove : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Infused Glove");
			Tooltip.SetDefault("Increases melee weapon size by 100%");
			Tooltip.SetDefault("5% decreased melee speed");
			Tooltip.SetDefault("Handy for true melee!");

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
			LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
			modPlayer.amethystGlove = true;
			modPlayer.amethystGloveCheckTick = modPlayer.equipmentCheckTick;
			player.GetAttackSpeed(DamageClass.Melee) -= 0.05f;
		}
    }
}