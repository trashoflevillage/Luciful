using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Luciful.Common.Systems.Util;

namespace Luciful.Common.Global.GlobalItems
{
    internal class AllShovels : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            LucifulItem modItem = LucifulItem.Convert(item);
            if (modItem.shovelPower > 0)
            {
                int i = 0;
                bool found = false;
                foreach (TooltipLine line in tooltips)
                {
                    if (line.Name == "Knockback") 
                    {
                        found = true;
                        i++;
                        break;
                    }
                    i++;
                }
                if (found)
                    tooltips.Insert(i, new TooltipLine(Luciful.Instance, "shovelPower", modItem.shovelPower + "% shovel power"));
            }
        }

        public override bool? UseItem(Item item, Player player)
        {
            LucifulItem modItem = LucifulItem.Convert(item);
            if (modItem.shovelPower > 0)
            {
                if (item.useAnimation > item.useTime) item.useAnimation = item.useTime;
                Point mouse = Main.MouseWorld.ToTileCoordinates();
                Tile tile = Main.tile[mouse];
                if (tile.HasTile && (modItem.shovelPower >= 35 || TileHelper.IsSoft(tile)))
                {
                    Grid mineGrid = new(new Point(mouse.X - 1, mouse.Y - 1), new Point(mouse.X + 1, mouse.Y + 1));
                    Point currentLoc = mineGrid.currentPos;
                    for (int i = 0; i < 9; i++)
                    {
                        tile = Main.tile[currentLoc.X, currentLoc.Y];
                        if ((modItem.shovelPower >= 35 || TileHelper.IsSoft(tile))
                            && player.IsInTileInteractionRange(currentLoc.X, currentLoc.Y))
                            player.PickTile(currentLoc.X, currentLoc.Y, modItem.shovelPower);
                        currentLoc = mineGrid.nextPos().Value;
                    }
                    return true;
                }
            }
            return base.UseItem(item, player);
        }
    }
}