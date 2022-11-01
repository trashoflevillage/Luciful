using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Luciful.Common.Systems.Util;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace Luciful.Content.NPCs.Dungeon
{
    internal class SkeletonDartThrower : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necro Darter");

            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BoneThrowingSkeleton];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 0f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BoneThrowingSkeleton);
            NPC.width = 40;
            NPC.height = 54;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;

            NPC.damage = 25;
            NPC.lifeMax = 55;
            NPC.defense = 6;

            NPC.value = 130;

            NPC.aiStyle = NPCAIStyleID.Fighter;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Ammo.BoneDart>(), 1, 5, 10));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheDungeon,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("This cursed corpse utilizes darts made out of their fallen brethren to assault trespassers of the dungeon.")
            });
        }

        public override void OnKill()
        {
        }
    }
}
