using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class BleedingOutDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bleeding Out");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<VampPlayer>().SacrificialDebuff = true;
        }
    }
}