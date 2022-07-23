using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Luciful.Content.Buffs
{
	public class CursedSpark : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Spark");
			Description.SetDefault("Less slowly losing life"); Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
			BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statLife -= 10;
			Dust.NewDust(player.position, player.width, player.height, DustID.CursedTorch);
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			LucifulNPC modNPC = LucifulNPC.Convert(npc);
			modNPC.cursedSparkTick++;
			if (modNPC.cursedSparkTick > 59)
            {
				npc.StrikeNPCNoInteraction(8, 0f, 0);
				modNPC.cursedSparkTick = 0;
            }
			Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch);
		}
	}
}