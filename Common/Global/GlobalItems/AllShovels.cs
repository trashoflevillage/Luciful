using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Luciful.Common.Systems.Util;
using Luciful.Common.Systems.Util.LootHelper;
using Terraria.DataStructures;
using System;
using Terraria.ID;

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

        public override void HoldItem(Item item, Player player)
        {
            LucifulItem modItem = LucifulItem.Convert(item);

            if (modItem.shovelPower > 0)
            {
                player.cursorItemIconID = -1;
                Point mouse = Main.MouseWorld.ToTileCoordinates();

                if (player.IsInTileInteractionRange(mouse.X, mouse.Y))
                {
                    player.cursorItemIconID = player.HeldItem.type;
                    player.cursorItemIconText = "";
                    player.cursorItemIconEnabled = true;
                }
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
                    Random rng = new Random();
                    for (int i = 0; i < 9; i++)
                    {
                        tile = Main.tile[currentLoc.X, currentLoc.Y];

                        if ((modItem.shovelPower >= 35 || TileHelper.IsSoft(tile) && tile.HasTile)
                            && player.IsInTileInteractionRange(currentLoc.X, currentLoc.Y))
                            if (!modItem.autoSift) player.PickTile(currentLoc.X, currentLoc.Y, modItem.shovelPower);
                            else
                            {
                                Loot loot = TileHelper.TrySiftTile(tile);
                                if (loot != null)
                                {
                                    Item.NewItem(new EntitySource_TileBreak(currentLoc.X, currentLoc.Y), currentLoc.X * 16, currentLoc.Y * 16, 32, 32,
                                        loot.item, rng.Next(loot.maxQuantity - (loot.minQuantity + 1)) + loot.minQuantity + 1);
                                    WorldGen.KillTile(currentLoc.X, currentLoc.Y, false, false, true);
                                }
                            }
                        currentLoc = mineGrid.nextPos().Value;
                    }
                    return true;
                }
            }
            return base.UseItem(item, player);
        }
    }
}