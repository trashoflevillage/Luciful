using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Luciful
{
    internal class LucifulWorld : ModSystem
    {
        public override void SaveWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;
            List<string> lucifulData = new List<string>();

            if (instance.contractSigned) lucifulData.Add("contractSigned");
            tag.Add("lucifulData", lucifulData);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            Luciful instance = Luciful.Instance;

            IList<string> lucifulData = tag.GetList<string>("lucifulData");
            if (lucifulData.Contains("contractSigned")) instance.contractSigned = true; else instance.contractSigned = false;
        }
    }
}
