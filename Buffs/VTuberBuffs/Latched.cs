using System;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs.VTuberBuffs
{
    public class Latched : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Latched");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().Latched = true;
        }
    }
}
