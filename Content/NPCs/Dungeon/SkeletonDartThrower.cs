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
        public Player targetPlayer = null;
        public bool throwing = false;
        private enum ActionState
        {
            Wander,
            Throwing
        }

        private enum Frame
        {
            Walk1,
            Walk2,
            Walk3,
            Walk4,
            Walk5,
            Walk6,
            Walk7,
            Walk8,
            Walk9,
            Walk10,
            Walk11,
            Walk12,
            Walk13,
            Walk14,
            Walk15,
            Throw1,
            Throw2,
            Throw3,
            Throw4,
        }

        public ref float AI_State => ref NPC.ai[0];
        public ref float Throwing_Cooldown => ref NPC.ai[1];
        public ref float Throw_Duration => ref NPC.ai[2];

        private float totalThrowDuration = 75f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necro Darter");

            Main.npcFrameCount[NPC.type] = 19;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = -1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 54;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;

            NPC.friendly = false;

            NPC.damage = 25;
            NPC.lifeMax = 55;
            NPC.defense = 6;

            NPC.value = 130;

            AnimationType = NPCID.BoneThrowingSkeleton;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Ammo.BoneDart>(), 1, 5, 10));
            int[] weaponDrops = {
                ModContent.ItemType<Items.Weapons.Ranged.DungeonDartPipe>(),
                ModContent.ItemType<Items.Weapons.Ranged.DungeonDartPistol>(),
                ModContent.ItemType<Items.Weapons.Ranged.DungeonDartRifle>()
            };
            npcLoot.Add(ItemDropRule.NormalvsExpertOneFromOptions(100, 75, weaponDrops));
            npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<Items.Accessories.Combat.MarkedSkull>(), 50, 25));
            npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 1, 2, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldenKey, 1, 2, 6));
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

        public override void HitEffect(int hitDirection, double damage)
        {
            IEntitySource deathEffectSource = NPC.GetSource_Death();
            if (NPC.life <= 0)
            {
                Gore.NewGore(deathEffectSource, NPC.Center, NPC.velocity, 42);
                Gore.NewGore(deathEffectSource, NPC.Center, NPC.velocity, 43);
                Gore.NewGore(deathEffectSource, NPC.Center, NPC.velocity, 43);
                Gore.NewGore(deathEffectSource, NPC.Center, NPC.velocity, 44);
                Gore.NewGore(deathEffectSource, NPC.Center, NPC.velocity, 44);
            }
            for (int i = 0; i < Main.rand.Next(5)+5; i++) 
                Dust.NewDust(NPC.Center, NPC.width, NPC.height, DustID.Bone);
        }

        public override void AI()
        {
            /*if (targetPlayer == null) targetPlayer = LocationHelper.GetNearestPlayer(NPC.position);
            float playerDistance = targetPlayer.Distance(NPC.position);
            if (playerDistance < 500f && Throwing_Cooldown <= 0)
            {
                if (!throwing)
                {
                    throwing = true;
                    AI_State = (float)ActionState.Throwing;
                    Throw_Duration = 0f;
                }
            } else
            {
                AI_State = (float)ActionState.Wander;
            }*/
            AI_State = (float)ActionState.Wander;
            switch (AI_State)
            {
                case (float)ActionState.Wander: Wander(); break;
                case (float)ActionState.Throwing: Throwing(); break;
            }
        }

        private void Wander()
        {
            NPC.aiStyle = NPCAIStyleID.Fighter;
            AIType = NPCID.AngryBones;
            Throwing_Cooldown--;
        }

        private void Throwing()
        {
            int oldAI = NPC.aiStyle;
            NPC.aiStyle = -1;
            AIType = -1;
            if (oldAI != -1)
            {
                NPC.velocity.X = 0;
                NPC.velocity.Y = 0;
            }
            int frameHeight = 58;
            Vector2 direction = new Vector2(NPC.direction, 0);
            Throw_Duration++;
            if (Throw_Duration <= totalThrowDuration/4)
                NPC.frame.Y = (int)Frame.Throw1 * frameHeight;
            else if (Throw_Duration <= (totalThrowDuration / 4) * 2)
                NPC.frame.Y = (int)Frame.Throw2 * frameHeight;
            else if (Throw_Duration <= (totalThrowDuration / 4) * 3)
                NPC.frame.Y = (int)Frame.Throw3 * frameHeight;
            else if (Throw_Duration <= (totalThrowDuration / 4) * 4)
                NPC.frame.Y = (int)Frame.Throw4 * frameHeight;
            if (Throw_Duration == totalThrowDuration && Main.netMode != NetmodeID.MultiplayerClient)
            {
                float distanceX = Math.Abs(NPC.position.X - targetPlayer.position.X);
                float distanceY = Math.Abs(NPC.position.Y - targetPlayer.position.Y);
                Vector2 velocity = new Vector2(distanceX, distanceY);
                Projectile.NewProjectile(NPC.GetSource_ReleaseEntity(), NPC.position, velocity, ModContent.ProjectileType<Projectiles.NPCs.BoneDartEvil>(), 13, 1);
                Throwing_Cooldown = 180;
                Throw_Duration = 0;
                throwing = false;
            }
            NPC.spriteDirection = NPC.direction;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.expertMode) target.AddBuff(ModContent.BuffType<Buffs.FragileBones>(), 300);
        }
    }
}
