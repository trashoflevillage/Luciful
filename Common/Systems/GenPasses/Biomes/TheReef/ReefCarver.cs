using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Luciful.Common.Systems.Util;
using Microsoft.Xna.Framework;

namespace Luciful.Common.Systems.GenPasses.Biomes.TheReef
{
    internal class ReefCarver : GenPass
    {
        public ReefCarver(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
        }
    }
}
