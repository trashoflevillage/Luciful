using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Luciful.Content.Buffs
{
	public class ContractualObligation : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contractual Obligation");
			Description.SetDefault("Stay within the dotted line"); 
			Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
			BuffID.Sets.LongerExpertDebuff[Type] = false; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		public override void Update(Player player, ref int buffIndex)
		{
			Dust.NewDust(player.position, player.width, player.height, DustID.Blood);
			if (player.HasBuff(BuffID.PotionSickness) == false) player.AddBuff(BuffID.PotionSickness, 60);
			if (player.HasBuff(BuffID.Darkness) == false) player.AddBuff(BuffID.Darkness, 60);
		}
	}
}