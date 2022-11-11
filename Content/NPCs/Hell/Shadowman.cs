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

namespace Luciful.Content.NPCs.Hell
{
    internal class Shadowman : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Man");

            Main.npcFrameCount[NPC.type] = 15;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = -1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;

            NPC.HitSound = SoundID.NPCHit54;
            NPC.DeathSound = SoundID.NPCDeath52;

            NPC.friendly = false;
            NPC.rarity = 4;

            NPC.damage = 75;
            NPC.lifeMax = 500;
            NPC.defense = 10;
            NPC.knockBackResist = 0.8f;

            NPC.value = 130;
            NPC.lavaImmune = true;

            AnimationType = NPCID.ChaosElemental;
            AIType = NPCID.ChaosElemental;
            NPC.aiStyle = NPCAIStyleID.Fighter;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Items.Accessories.Combat.ShadowEye>(), 4, 2));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A mysterious shadow being that guards the obsidian towers of the underworld.")
            });
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneUnderworldHeight && NPC.CountNPCS(ModContent.NPCType<Shadowman>()) < 1)
            {
                return .08f;
            }
            return 0f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (target.statLife <= target.statLifeMax / 4) damage *= 2;
        }
    }
}
