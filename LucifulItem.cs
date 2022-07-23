﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful
{
    internal class LucifulItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public float baseScale;
        public bool scaled = false;
        
        public int bonusProjectiles = 0;
        public float projectileSpread = 15f;
        public float spreadVariation = 0.3f;

        public static LucifulItem Convert(Item item) {
            return item.GetGlobalItem<LucifulItem>();
        }
    }
}