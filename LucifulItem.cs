﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Luciful
{
    internal class LucifulItem : GlobalItem
    {
        public int genericTracker1 = 0;

        public override bool InstancePerEntity => true;
        public float baseScale;
        public bool scaled = false;

        public int shovelPower = 0;
        public bool autoSift = false;

        public int bonusProjectiles = 0;
        public float projectileSpread = 15f;
        public float speedVariation = 0.3f;

        public bool reforgable = false;

        public static LucifulItem Convert(Item item) {
            return item.GetGlobalItem<LucifulItem>();
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            modPlayer.accessories.Add(item.type);
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.PaperAirplaneA || item.type == ItemID.PaperAirplaneB)
            {
                item.value = Item.sellPrice(copper: 40);
            }
        }
    }
}