using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Luciful.Content.Items.Placeables;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Luciful.Content.Items.Toggles.World
{
	public class LuciferContract : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lucifer's Contract");
			Tooltip.SetDefault("Will you sign it?\nOnly usable in Master Mode");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.rare = ItemRarityID.Master;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 45;
			Item.useTurn = true;
		}

        public override void UseAnimation(Player player)
        {
			Luciful instance = Luciful.Instance;
			if (Main.masterMode)
			{
				if (instance.contractSigned == false)
				{
					SoundEngine.PlaySound(SoundID.ForceRoarPitched);
					NetworkText chatMessage = NetworkText.FromLiteral("Contract signed. Good luck.");
					ChatHelper.BroadcastChatMessage(chatMessage, Color.Red);
					instance.contractSigned = true;
				} else
				{
					SoundEngine.PlaySound(SoundID.Shatter);
					NetworkText chatMessage = NetworkText.FromLiteral("What happened to your confidence?");
					ChatHelper.BroadcastChatMessage(chatMessage, Color.OrangeRed);
					instance.contractSigned = false;
				}
			}
			else
            {
				SoundEngine.PlaySound(SoundID.Item16);
				NetworkText chatMessage = NetworkText.FromLiteral("Show more confidence if you want this additional challenge.");
				ChatHelper.BroadcastChatMessage(chatMessage, Color.OrangeRed);
			}
        }

        public override void AddRecipes()
		{
			CreateRecipe(1).Register();
		}
	}
}