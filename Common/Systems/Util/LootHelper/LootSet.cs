using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Luciful.Common.Systems.Util.LootHelper
{
    internal class LootSet
    {
        public int[] contents;
        public int minQuantity;
        public int maxQuantity;
        public float chance;

        public LootSet(int[] contents, int minQuantity, int maxQuantity, float chance)
        {
            this.contents = contents;
            this.minQuantity = minQuantity;
            this.maxQuantity = maxQuantity;
            this.chance = chance;
        }

        public ItemStack? GetLoot()
        {
            if (WorldGen.genRand.NextFloat() <= chance)
            {
                int item = contents[WorldGen.genRand.Next(contents.Length)];
                int quantity = WorldGen.genRand.Next(minQuantity, maxQuantity + 1);
                return new ItemStack(item, quantity);
            }
            else return null;
        }
    }
}
