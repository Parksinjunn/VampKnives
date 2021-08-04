using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Items
{
    public class KnifeDamagePlayer : ModPlayer
    {
        public static KnifeDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<KnifeDamagePlayer>();
        }

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
            knifeDamageMult = 1f * VampKnives.ConfigDamageMult;
            KnifeCrit = 0;
        }
    }
}