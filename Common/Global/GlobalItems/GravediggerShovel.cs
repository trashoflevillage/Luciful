using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace Luciful.Common.Global.GlobalItems
{
    internal class GravediggerShovel : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.GravediggerShovel)
            {
                tooltips.Add(new TooltipLine(Luciful.Instance, "Disable", "[c/FF0000:This item has been disabled]\n[c/FF0000:Use the 'Iron Shovel' instead]"));
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.GravediggerShovel)
                return false;
            return true;
        }
    }
}