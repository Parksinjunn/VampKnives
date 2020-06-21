using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class BleedingOut2 : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            // NPC only buff so we'll just assign it a useless buff icon.
            texture = "VampKnives/Buffs/ConnorBuff";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bleeding Out a LOT");
            Description.SetDefault("Losing life");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().bleedingOut2 = true;
        }
    }
}