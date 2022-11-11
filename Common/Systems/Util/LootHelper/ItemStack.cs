using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luciful.Common.Systems.Util.LootHelper
{
    internal class ItemStack
    {
        public int type;
        public int quantity;
        public ItemStack(int type, int quantity)
        {
            this.type = type;
            this.quantity = quantity;
        }
    }
}
