using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Content.Items;
using Terraria.IO;

namespace Luciful
{
    internal class GlobalItems : GlobalItem
    {
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            if (item.DamageType == DamageClass.Melee && item.pick < 1 && item.axe < 1 && item.hammer < 1)
            {
                LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
                LucifulItem modItem = item.GetGlobalItem<LucifulItem>();
                if (modItem.scaled == false) { modItem.baseScale = item.scale; modItem.scaled = true; }
                float scaler = 0f;
                if (modPlayer.diamondGlove) scaler += 1.5f;
                if (modPlayer.amberGlove) scaler += 1.25f;
                if (modPlayer.rubyGlove) scaler += 1.25f;
                if (modPlayer.emeraldGlove) scaler += 1f;
                if (modPlayer.sapphireGlove) scaler += 0.75f;
                if (modPlayer.topazGlove) scaler += 0.5f;
                if (modPlayer.amethystGlove) scaler += 0.35f;
                item.scale = scaler + modItem.baseScale;
            }
        }


        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.SuspiciousLookingEye ||
                item.type == ItemID.WormFood ||
                item.type == ItemID.BloodySpine ||
                item.type == ItemID.Abeemination ||
                item.type == ItemID.MechanicalEye ||
                item.type == ItemID.MechanicalSkull ||
                item.type == ItemID.MechanicalWorm ||
                item.type == ItemID.LihzahrdPowerCell ||
                item.type == ItemID.CelestialSigil)
            {
                item.consumable = false;
            }
        }

    }
}
