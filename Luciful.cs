using Terraria.ModLoader;

namespace Luciful
{
	public class Luciful : Mod
	{
		public Luciful() { Instance = this; }
		public static Luciful Instance { get; private set; }

		public bool contractSigned = false;
	}
}