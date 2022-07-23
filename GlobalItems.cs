﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using Luciful.Content.Items;
using Terraria.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

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
                float scaler = 0f;
                if (modPlayer.frightGauntlet) scaler += 1.5f;
                if (modPlayer.mightGauntlet) scaler += 1.5f;
                if (modPlayer.sightGauntlet) scaler += 1.5f;
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
                newVelocity *= 1f - Main.rand.NextFloat(modItem.spreadVariation);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue) // Healing potion stuff
        {
            LucifulPlayer modPlayer = player.GetModPlayer<LucifulPlayer>();
            int bonusHeal = 0;
            if (modPlayer.mushroomNecklace) {
                bonusHeal += 10;
            }

            healValue = healValue + bonusHeal;
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
