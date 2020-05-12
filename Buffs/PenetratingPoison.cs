using System;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class PenetratingPoison : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Penetrating Poison");
            Description.SetDefault("So potent it degrades bones");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ExamplePlayer>().PenetratingPoison = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().PenetratingPoison = true;
        }
    }
}
