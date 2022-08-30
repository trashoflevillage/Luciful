using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luciful.Common.Systems.Util.LootHelper
{
    internal class Loot
    {
        public short item;
        public int minQuantity;
        public int maxQuantity;
        public int weight;

        public Loot(short item, int minQuantity, int maxQuantity, float chance)
        {
            this.item = item;
            this.minQuantity = minQuantity;
            this.maxQuantity = maxQuantity;
            weight = (int)(chance * 1000);
        }
    }
}
