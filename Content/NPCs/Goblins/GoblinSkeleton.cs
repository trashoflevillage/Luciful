using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.NPCs.Goblins
{
    internal class GoblinSkeleton : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Skeleton");
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GoblinPeon];

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f,
				Direction = 1
			};

		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.GoblinPeon);
			NPC.lifeMax = 100;
			NPC.defense = 6;
			NPC.knockBackResist = 0f;
			NPC.damage = 16;

			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;

			AIType = NPCID.GoblinPeon;
			AnimationType = NPCID.GoblinPeon;
		}

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.Bleeding, 480);
        }

        public override void AI()
        {
        }

        public override void OnKill()
		{
			for (int i = 0; i < 50; i++) Dust.NewDust(NPC.Center, 1, 1, DustID.Blood);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("The animated, rotten corpse of a goblin. How odd.")
			});
		}
	}
}
