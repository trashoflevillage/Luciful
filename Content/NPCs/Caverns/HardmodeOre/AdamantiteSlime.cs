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

namespace Luciful.Content.NPCs.Caverns.HardmodeOre
{
    internal class AdamantiteSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Slime");

            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BlueSlime];
            
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 0f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 52;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.damage = 100;
            NPC.lifeMax = 600;
            NPC.defense = 30;

            NPC.value = 200f;

            NPC.aiStyle = NPCID.BlueSlime;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.AdamantiteOre, 1, 1, 5));
        }
        
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Somehow, this slime has been infused with a powerful ore.")
            });
        }

        public override void OnKill()
        {
            int? npc = NPCHelper.GetHardmodeOreSlime(1);
            if (npc != null)
            {
                NPC.NewNPC(new EntitySource_Loot(NPC), (int)NPC.Center.X, (int)NPC.Center.Y, npc.Value);
                NPC.NewNPC(new EntitySource_Loot(NPC), (int)NPC.Center.X, (int)NPC.Center.Y, npc.Value);
            }
        }
    }
}
