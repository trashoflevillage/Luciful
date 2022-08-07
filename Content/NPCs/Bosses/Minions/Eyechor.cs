using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;

namespace Luciful.Content.NPCs.Bosses.Minions
{
    internal class Eyechor : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyechor");
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.ServantofCthulhu];

			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					ModContent.BuffType<Buffs.DilutedIchor>(),
					BuffID.Ichor,
					BuffID.Confused
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(NPC.type, debuffData);


			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.ServantofCthulhu);
			NPC.lifeMax = 100;
			NPC.defense = 1;
			NPC.knockBackResist = 0f;
			NPC.damage = 16;
		}

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.AddBuff(ModContent.BuffType<Buffs.DilutedIchor>(), 480);
        }

        public override void AI()
        {
        }

        public override void OnKill()
		{
			for (int i = 0; i < 50; i++) Dust.NewDust(NPC.Center, 1, 1, DustID.Blood);
			Vector2 velocity = new Vector2(0, 0);
			Projectile.NewProjectile(Projectile.InheritSource(NPC), NPC.Center, velocity, ModContent.ProjectileType<Projectiles.NPCs.IchorExplosion>(), 3, 0f, Main.myPlayer);
			SoundEngine.PlaySound(SoundID.Item14, NPC.Center);
		}
    }
}
