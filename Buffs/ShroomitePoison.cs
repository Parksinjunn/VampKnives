using System;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class ShroomitePoison : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            // NPC only buff so we'll just assign it a useless buff icon.
            texture = "VampKnives/Buffs/ConnorBuff";
            return base.Autoload(ref name, ref texture);
        }
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroomite Poison");
            Description.SetDefault("So potent it degrades bones");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().ShroomitePoison = true;
        }
    }
}
