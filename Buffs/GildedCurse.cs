using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class GildedCurse : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            // NPC only buff so we'll just assign it a useless buff icon.
            texture = "VampKnives/Buffs/ConnorBuff";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Definitely on Fire");
            Description.SetDefault("Losing life");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyGlobalNPC>().gildedCurse = true;
            npc.velocity.X = npc.velocity.X * 0.5f;
            npc.velocity.Y = npc.velocity.Y * 0.5f;
            npc.extraValue = npc.value * 5;
        }
    }
}