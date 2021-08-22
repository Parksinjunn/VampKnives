using System;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs.VTuberBuffs
{
    public class VeiLoveDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("VeiLoveDebuff");
            Description.SetDefault("So potent it degrades bones");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().VeiLove = true;
        }
    }
}
