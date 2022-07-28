using Terraria.ModLoader;
using System.Collections.Generic;

namespace Luciful
{
	public class Luciful : Mod
	{
		public Luciful() { Instance = this; }
		public static Luciful Instance { get; private set; }

		public bool contractSigned = false;
		public IDictionary<string, bool> bossesKilled = new Dictionary<string, bool>();
	}
}