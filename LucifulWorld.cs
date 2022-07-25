using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace Luciful
{
    internal class LucifulWorld : ModSystem
    {
        public static bool contractSigned = false;

        public override void SaveWorldData(TagCompound tag)
        {

            List<string> lucifulData = new List<string>();

            if (contractSigned) lucifulData.Add("contractSigned");
            tag.Add("lucifulData", lucifulData);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            IList<string> lucifulData = tag.GetList<string>("lucifulData");
            contractSigned = lucifulData.Contains("contractSigned");
        }
    }
}
