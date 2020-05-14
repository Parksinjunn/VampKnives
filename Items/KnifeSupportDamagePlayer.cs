using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
    public class KnifeSupportDamagePlayer : KnifeDamagePlayer
    {
        public static KnifeSupportDamagePlayer KnifeDamagePlayer(Player player)
        {
            return player.GetModPlayer<KnifeSupportDamagePlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float knifeSupportDamageMult = 1f;
        public float KnifeSupportDamage = 1f;
        public int knifeSupportDamageAdd = 0;

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            KnifeSupportDamage = KnifeSupportDamage * knifeSupportDamageMult;
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
            KnifeSupportDamage = 1f;
            knifeSupportDamageMult = 1f;
        }
    }
}