using System;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs.VTuberBuffs
{
    public class ImEnsured : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("I'm Ensured!");
            longerExpertDebuff = false;
            Description.SetDefault("I'm Ensured!");
            canBeCleared = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<VampPlayer>().MouseMilkBuff = true;
            base.Update(player, ref buffIndex);
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().MouseMilkDebuff = true;
        }
    }
}
