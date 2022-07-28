using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Luciful.Content.Rarities
{
	public class Contracted : ModRarity
	{
		public override Color RarityColor => new Color(221, 40, 4);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			return Type;
		}
    }
}