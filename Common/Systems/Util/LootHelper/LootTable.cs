using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luciful.Common.Systems.Util.LootHelper
{
    internal class LootTable
    {
        public Loot[] contents;
        public int totalWeight = 0;

        public LootTable(Loot[] contents)
        {
            this.contents = contents;
            foreach (Loot i in contents)
            {
                totalWeight += i.weight;
            }
        }

        public Loot NextLoot()
        {
            Random rng = new Random();
            int weightTester = (rng.Next() % totalWeight);
            foreach (Loot i in contents)
            {
                if (i.weight > weightTester)
                    return i;
                else weightTester -= i.weight;
            }
            return null;
        }
    }
}
