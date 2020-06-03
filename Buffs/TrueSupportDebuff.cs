using Terraria;
using Terraria.ModLoader;
using VampKnives;

namespace VampKnives.Buffs
{
    public class TrueSupportDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("You are a true support");
            Description.SetDefault("You do double the healing, but cannot heal yourself");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();

            if (p.IsTrueSupport == true)
            {
                p.TrueSupportBuff = 1.2f;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}