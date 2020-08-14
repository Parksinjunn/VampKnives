using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class BandageBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bandaged");
            Description.SetDefault("");
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer < ExamplePlayer > ().Bandaged = true;
            base.Update(player, ref buffIndex);
        }
    }
}