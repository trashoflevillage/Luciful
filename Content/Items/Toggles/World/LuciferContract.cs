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
			DisplayName.SetDefault("Lucifer's Contract"); // The item's description, can be set to whatever you want.
			Tooltip.SetDefault("Will you sign it?\nOnly usable in Master Mode"); // The item's description, can be set to whatever you want.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 1;
			Item.consumable = false; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.rare = ItemRarityID.Master;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 45;
			Item.useTurn = true;
		}

        public override void UseAnimation(Player player)
        {
			if (Main.masterMode)
			{
				if (LucifulWorld.contractSigned == false)
				{
					SoundEngine.PlaySound(SoundID.ForceRoarPitched);
					NetworkText chatMessage = NetworkText.FromLiteral("Contract signed. Good luck.");
					ChatHelper.BroadcastChatMessage(chatMessage, Color.Red);
					LucifulWorld.contractSigned = true;
				} else
				{
					SoundEngine.PlaySound(SoundID.Shatter);
					NetworkText chatMessage = NetworkText.FromLiteral("Too scared?");
					ChatHelper.BroadcastChatMessage(chatMessage, Color.OrangeRed);
					LucifulWorld.contractSigned = false;
				}
			}
			else
            {
				SoundEngine.PlaySound(SoundID.Item16);
				NetworkText chatMessage = NetworkText.FromLiteral("You're too weak.");
				ChatHelper.BroadcastChatMessage(chatMessage, Color.OrangeRed);
			}
        }

        public override void AddRecipes()
		{
			CreateRecipe(1).Register();
		}
	}
}