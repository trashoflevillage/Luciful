using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.WorldBuilding;
using Luciful;
using Luciful.Common.Systems.Util.LootHelper;

namespace Luciful.Common.Systems.GenPasses.Chests
{
    internal class CobaltChest : GenPass
    {
        public CobaltChest(string name, float weight) : base(name, weight) { }
        
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
			GenerateChests();
        }

        public void GenerateChests()
        {
			LootTable primaryItems = new LootTable(new Loot[] { 
				new Loot((short)ModContent.ItemType<Content.Items.Weapons.Magic.HungrySpell>(), 1, 1, 1),
				new Loot((short)ModContent.ItemType<Content.Items.Tools.Special.CursedMirror>(), 1, 1, 1),
				new Loot(ItemID.LavaCharm, 1, 1, 1)
			});

			LootSet[] secondaryItems = new LootSet[]

			{
				new LootSet(new int[] { ItemID.Dynamite }, 10, 19, 0.3333f),
				new LootSet(new int[] { ItemID.HeartStatue, ItemID.StarStatue }, 1, 1, 0.20f),
				new LootSet(new int[] { ItemID.Rope }, 50, 100, 0.50f),
				new LootSet(new int[] { ItemID.CobaltBar, ItemID.PalladiumBar, ItemID.MythrilBar, ItemID.OrichalcumBar, ItemID.AdamantiteBar, ItemID.TitaniumBar }, 5, 14, 0.50f),
				new LootSet(new int[] { ItemID.CrystalBullet, ItemID.HolyArrow }, 25, 49, 0.50f),
				new LootSet(new int[] { ItemID.HealingPotion }, 3, 5, 0.50f),
				new LootSet(new int[] { ItemID.EndurancePotion, ItemID.LifeforcePotion, ItemID.InfernoPotion, ItemID.LuckPotion, ItemID.RagePotion }, 1, 2, 0.6667f),
				new LootSet(new int[] { ItemID.Torch }, 10, 20, 0.50f),
				new LootSet(new int[] { ItemID.WormholePotion }, 1, 2, 0.6667f),
				new LootSet(new int[] { ItemID.GoldCoin }, 5, 12, 0.50f),
				new LootSet(new int[] { ItemID.MechanicalWorm, ItemID.MechanicalSkull, ItemID.MechanicalEye }, 1, 1, 0.10f)
			};

			int chestCount;
			if (Main.maxTilesX >= 16800) chestCount = 600;
			else if (Main.maxTilesX >= 12800) chestCount = 400;
			else chestCount = 200;

			int x;
			int y;
			for (int i = 0; i < chestCount; i++)
			{
				bool success = false;
				int attempts = 0;
				while (!success)
				{
					attempts++;
					if (attempts > 1000)
					{
						break;
					}
					x = WorldGen.genRand.Next(0, Main.maxTilesX);
					y = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);
					int chest = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<Content.Tiles.Furniture.Chests.CobaltChest>(), false);
					if (chest != -1) {
                        Main.chest[chest].item[0].SetDefaults(primaryItems.NextLoot().item);
						int slot = 1;
						ItemStack? itemStack;
						for (int a = 0; a < secondaryItems.Length; a++)
                        {
							itemStack = secondaryItems[a].GetLoot();
							if (itemStack != null)
							{
								Main.chest[chest].item[slot].SetDefaults(itemStack.type);
								Main.chest[chest].item[slot].stack = itemStack.quantity;
								slot++;
                            }
                        }
					}
					success = chest != -1;
				}
			}
		}
    }
}
