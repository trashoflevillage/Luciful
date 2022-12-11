using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;

namespace Luciful.Content.Buffs
{
    internal class FragileBones : ModBuff
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brittle Bones");
			Description.SetDefault("Defense lowers with health"); Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
			BuffID.Sets.LongerExpertDebuff[Type] = false; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense -= Math.Clamp((player.statDefense / 2) - (player.statDefense / 2 * (player.statLife / player.statLifeMax)), 0, player.statDefense);
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.defense > 0) npc.defense -= Math.Clamp(npc.defense/3 - (npc.defense/3 * npc.life / npc.lifeMax), 0, npc.defense/3);
		}
	}
}
