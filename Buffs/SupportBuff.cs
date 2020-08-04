using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class SupportBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("You're being supported");
            Description.SetDefault("You've been supported!\nYou've gained:\n-Increased Movement Speed\n-Increased Damage\n-Increased Life Regen\n-Increased Armor");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            p.SupportArmorBuff = true;
        }
    }
}