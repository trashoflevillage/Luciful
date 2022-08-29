using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Luciful.Common.Systems.Util;

namespace Luciful.Content.NPCs
{
    internal class Kracken : ModNPC
    {
        int distance = 0;
        Vector2 spawnLoc;

        private enum ActionState
        {
            Phase1,
            Phase2
        }

        private enum Frame
        {
            State1,
            State2,
            State3,
            State4,
            State5,
            State6,
            State7,
            State8
        }

        // These are reference properties. One, for example, lets us write AI_State as if it's NPC.ai[0], essentially giving the index zero our own name.
        // Here they help to keep our AI code clear of clutter. Without them, every instance of "AI_State" in the AI code below would be "npc.ai[0]", which is quite hard to read.
        // This is all to just make beautiful, manageable, and clean code.
        public ref float AI_State => ref NPC.ai[0];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 8;
        }

        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 44;
            NPC.aiStyle = -1; // Use this for custom NPCs, 0 will cause the npc to automatically face the player, which is likely undesirable.
            NPC.damage = 60;
            NPC.lifeMax = 7500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 20000f;
            NPC.noTileCollide = true;
            NPC.boss = true;
        }

        public override int SpawnNPC(int tileX, int tileY)
        {
            spawnLoc = NPC.position;
            return base.SpawnNPC(tileX, tileY);
        }

        public override void AI()
        {
            if (AI_State == (float)ActionState.Phase1)
                AIPhase1();
            if (AI_State == (float)ActionState.Phase2)
                AIPhase2();
        }

        void AIPhase1()
        {
            int radius = 5;
            distance++;
            if (distance >= 360) distance = distance - 360;
            int newX = (int)(spawnLoc.X + radius * Math.Cos(2 * Math.PI * distance / 360));
            int newY = (int)(spawnLoc.Y + radius * Math.Sin(2 * Math.PI * distance / 360));
            Vector2 direction = NPC.DirectionTo(new Vector2(newX, newY));
            NPC.velocity = new Vector2(direction.X * 3, direction.Y * 3);
        }

        void AIPhase2()
        {

        }
    }
}
