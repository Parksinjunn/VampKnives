﻿using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class DPyroHoodBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark Pyromancy");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();

            // We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
            if (p.HoodIsVisible == true && p.dPyroAccessoryPrevious)
            {
                p.dPyroPower = true;
                //player.statMana -= 1;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}