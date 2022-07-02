using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Content.Items;

namespace Luciful.Global
{
    internal class GlobalItems : GlobalItem
    {
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            if (item.DamageType == DamageClass.Melee)
            {
                LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
                if (modPlayer.amethystGlove) item.scale = 2f;
                else item.scale = 1f;
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
