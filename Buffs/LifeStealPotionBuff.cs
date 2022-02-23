using Terraria;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class LifeStealPotionBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lifesteal Potion");
            Description.SetDefault("Lifesteal increased by 10%");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            VampPlayer p = player.GetModPlayer<VampPlayer>();
            p.HealAccMult *= 1.1f;
            base.Update(player, ref buffIndex);
        }
    }
}