using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Buffs
{
	public class DilutedIchor : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diluted Ichor");
			Description.SetDefault("Defense is reduced by 3"); Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
			BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HasBuff(BuffID.Ichor)) player.ClearBuff(ModContent.BuffType<DilutedIchor>());
			player.statDefense -= 3;
			Dust.NewDust(player.position, player.width, player.height, DustID.Ichor);
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.HasBuff(BuffID.Ichor)) {
				int index = npc.FindBuffIndex(ModContent.BuffType<DilutedIchor>());
				if (index > -1) npc.DelBuff(index);
			} 
			npc.defense -= 2;
			Dust.NewDust(npc.position, npc.width, npc.height, DustID.Ichor);
		}
	}
}