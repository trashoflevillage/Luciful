using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Content.Items;
using Terraria.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Luciful
{
    internal class GlobalItems : GlobalItem
    {
        public override void ModifyItemScale(Item item, Player player, ref float scale)
        {
            if (item.DamageType == DamageClass.Melee && item.pick < 1 && item.axe < 1 && item.hammer < 1)
            {
                LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
                LucifulItem modItem = LucifulItem.Convert(item);
                if (modItem.scaled == false) { modItem.baseScale = item.scale; modItem.scaled = true; }
                item.scale = modPlayer.meleeWeaponScale + modItem.baseScale;
            }
        }

        public override void UseAnimation(Item item, Player player)
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            LucifulItem modItem = LucifulItem.Convert(item);
            if (item.pick == 0 && item.axe == 0 && item.hammer == 0)
            {
                if (item.DamageType == DamageClass.Melee) 
                    player.GetAttackSpeed(DamageClass.Melee) += modPlayer.bonusMeleeSpeed;
                if (item.DamageType == DamageClass.Magic)
                    player.GetAttackSpeed(DamageClass.Magic) += modPlayer.bonusMagicSpeed;
                if (item.DamageType == DamageClass.Ranged)
                    player.GetAttackSpeed(DamageClass.Ranged) += modPlayer.bonusRangedSpeed;
                if (item.DamageType == DamageClass.Summon)
                    player.GetAttackSpeed(DamageClass.Summon) += modPlayer.bonusSummonSpeed;
            }
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            LucifulItem modItem = LucifulItem.Convert(item);
            if (modItem.bonusProjectiles < 1) return true;

            int NumProjectiles = 1 + modItem.bonusProjectiles; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(modItem.projectileSpread));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(modItem.speedVariation);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue) // Healing potion stuff
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            healValue += modPlayer.healingPotency;
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

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.rare == ModContent.RarityType<Content.Rarities.Contracted>())
            {
                TooltipLine tooltipLine = new TooltipLine(Luciful.Instance, "Contracted", "[c/bc1f00:Contracted]");
                tooltips.Add(tooltipLine);
            }
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Content.Buffs.ContractualObligation>())) return false;
            return true;
        }
    }
}
