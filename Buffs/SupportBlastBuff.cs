using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class SupportBlastBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("You are a true support");
            Description.SetDefault("Using this will boost the movement speed and dodge chance of the players near you");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            VampPlayer p = player.GetModPlayer<VampPlayer>();
            p.SupportArmorSetBuff = true;
        }
    }
}