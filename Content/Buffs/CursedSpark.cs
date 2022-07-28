using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

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
			if (player.HasBuff(BuffID.CursedInferno)) player.ClearBuff(ModContent.BuffType<CursedSpark>());
			LucifulPlayer modPlayer = LucifulPlayer.Convert(player);
			modPlayer.cursedSparkTick++;
			if (modPlayer.cursedSparkTick > 59)
			{
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + "couldn't put the fire out."), 8, 0, false, false);
				modPlayer.cursedSparkTick = 0;
			}
			Dust.NewDust(player.position, player.width, player.height, DustID.CursedTorch);
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.HasBuff(BuffID.CursedInferno))
			{
				int index = npc.FindBuffIndex(ModContent.BuffType<CursedSpark>());
				if (index > -1) npc.DelBuff(index);
			}
			LucifulNPC modNPC = LucifulNPC.Convert(npc);
			modNPC.cursedSparkTick++;
			if (modNPC.cursedSparkTick > 59)
			{
				modNPC.cursedSparkTick = 0;
				npc.StrikeNPC(8, 0, 0);
			}
			Dust.NewDust(npc.position, npc.width, npc.height, DustID.CursedTorch);
		}
	}
}