using Terraria;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class MurderPotionBuff : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Murder Potion");
            Description.SetDefault("Randomly deal massive damage, crit is lowered");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            KnifeDamagePlayer p = KnifeDamagePlayer.ModPlayer(player);
            if (Main.rand.Next(50) == 5)
                p.KnifeDamage = p.KnifeDamage * 10;
            p.KnifeCrit = (int)(p.KnifeCrit * .01);
        }
    }
}