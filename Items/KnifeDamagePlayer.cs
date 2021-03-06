﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class KnifeDamagePlayer : ModPlayer
    {
        public static KnifeDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<KnifeDamagePlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float knifeDamageMult = 1f;
        public float KnifeDamage = 1f;
        public float KnifeKnockback = 0f;
        public int KnifeCrit = 0;
        public int knifeDamageAdd = 0;

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            KnifeDamage = KnifeDamage * knifeDamageMult;
        }
        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            KnifeDamage = 1f;
            KnifeKnockback = 0f;
            if(VampKnives.Legacy)
            {
                knifeDamageMult = 1f;
            }
            if (VampKnives.Normal)
            {
                knifeDamageMult = 1.2f;
            }
            if (VampKnives.Unforgiving)
            {
                knifeDamageMult = 0.8f;
            }
            KnifeCrit = 0;
        }
    }
}