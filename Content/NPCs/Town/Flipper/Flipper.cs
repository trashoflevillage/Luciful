using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;

namespace Luciful.Content.NPCs.Town.Flipper
{
	[AutoloadHead]
	internal class Flipper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Market Flipper");
			Main.npcFrameCount[Type] = 26; // The amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 5; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 5;
			NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = -1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			NPC.Happiness
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
				.SetNPCAffection(NPCID.Golfer, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Merchant, AffectionLevel.Like)
				.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate)
            ;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.TravellingMerchant;
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("Coming from unknown origins, the Flipper will purchase items from the Travelling Merchant shortly before he leaves, and resell them at raised prices."),
			});
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return NPC.downedSlimeKing;
		}
		
		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Clay",
				"Walt",
				"David",
				"Tony",
				"Paul"
			};
		}

		public override ITownNPCProfile TownNPCProfile()
		{
			return new FlipperProfile();
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			chat.Add(Language.GetTextValue("My wares may be expensive, but what else are you going to be using that money on?"));
			chat.Add(Language.GetTextValue("She sells seashells on the seashore, and I flip the wares of other merchants!"));
			chat.Add(Language.GetTextValue("I was once an aspiring hero like you, and then I realized I could get rich from piggybacking other's success!"));

			chat.Add(Language.GetTextValue("Would you be interested in a laser ta- no? Suit yourself."), 0.1);
			chat.Add(Language.GetTextValue("I've heard rumor that an ancient fossil has been discovered by a cult in the icy depths. What would they want with that old thing?"), 0.1);

			return chat;
		}
		
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Shop";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			shop = firstButton;
		}

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
			Luciful instance = Luciful.Instance;
			if (instance.flipperShop.Count > 0)
			{
				foreach (int i in instance.flipperShop)
				{
					if (i != 0)
					{
						if (nextSlot > 40) break;
						shop.item[nextSlot].SetDefaults(i);
						shop.item[nextSlot].shopCustomPrice = shop.item[nextSlot].GetStoreValue() * 2;
						nextSlot++;
					}
				}
			}
		}

		public override bool CanGoToStatue(bool toKingStatue) => true;
	}

	public class FlipperProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("Luciful/Content/NPCs/Town/Flipper/Flipper");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("Luciful/Content/NPCs/Town/Flipper/Flipper_Party");

			return ModContent.Request<Texture2D>("Luciful/Content/NPCs/Town/Flipper/Flipper");
		}
		
		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Luciful/Content/NPCs/Town/Flipper/Flipper_Head");
	}
}
