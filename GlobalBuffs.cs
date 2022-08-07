using Terraria;
using Terraria.ModLoader;

namespace Luciful
{
    internal class GlobalBuffs : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            LucifulPlayer modPlayer = LucifulPlayer.Convert(player);
            if (modPlayer.infiniteBuffs.Contains(buffIndex)) player.AddBuff(buffIndex, 1);
        }
    }
}
