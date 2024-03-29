﻿using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class SengosCurseBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sengo's Curse");
            Description.SetDefault("The Price of These Contraptions is Blood");
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer < VampPlayer > ().SengosCurse = true;
            base.Update(player, ref buffIndex);
        }
    }
}