using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using System.Collections.Generic;
using System;
using System.Collections;
using Microsoft.Xna.Framework;

namespace Luciful
{
    internal class LucifulPlayer : ModPlayer
    {
        // General stat increases

        public float bonusMeleeSpeed = 0f;
        public float bonusMagicSpeed = 0f;
        public float bonusRangedSpeed = 0f;
        public float bonusSummonSpeed = 0f;

        public float meleeWeaponScale = 0f;
        public float magicWeaponScale = 0f;
        public float rangedWeaponScale = 0f;
        public float summonWeaponScale = 0f;

        public int healingPotency = 0;

        public bool firstStrikeBenefits = false;

        // Tick variables

        public int cursedSparkTick = 0;

        // Equipment
        
        public ArrayList accessories = new ArrayList();

        // Positions
        public Vector2? deathPos = null;

        public override void ResetEffects()
        {
            // General stat increases

            bonusMeleeSpeed = 0f;
            bonusMagicSpeed = 0f;
            bonusRangedSpeed = 0f;
            bonusSummonSpeed = 0f;

            meleeWeaponScale = 0f;
            magicWeaponScale = 0f;
            rangedWeaponScale = 0f;
            summonWeaponScale = 0f;

            healingPotency = 0;

            firstStrikeBenefits = false;

            accessories.Clear();
        }

        // Everything past here is not for the setting and resetting of variables.

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHit(target, ref damage, ref knockback, ref crit);
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            ModifyHit(target, ref damage, ref knockback, ref crit);
        }

        public void ModifyHit(NPC target, ref int damage, ref float knockback, ref bool crit) 
        {
            if (firstStrikeBenefits && target.life == target.lifeMax)
            {
                damage *= 2;
                crit = true;
            }
            if (accessories.Contains(ModContent.ItemType<Content.Items.Accessories.Combat.ShadowEye>()))
                if (target.life <= target.lifeMax / 4) crit = true;
        }

        public static LucifulPlayer Convert(Player player)
        {
            return player.GetModPlayer<LucifulPlayer>();
        }

        public override void PostUpdate()
        {
            if (Player.statDefense > 0 && Player.HasBuff(ModContent.BuffType<Content.Buffs.FragileBones>())) {
                Player.statDefense -= Math.Clamp(Player.statDefense/2 - (Player.statDefense/2 * Player.statLife / Player.statLifeMax2), 0, Player.statDefense/2);
            }
        }

        public override void PreUpdateMovement()
        {
        }

        public override void PreUpdateBuffs()
        {
        }

        public override void OnRespawn(Player player)
        {
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            deathPos = Player.position;
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }
    }
}
