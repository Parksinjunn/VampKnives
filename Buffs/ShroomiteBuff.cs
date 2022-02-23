using Terraria;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives.NPCs;

namespace VampKnives.Buffs
{
    public class ShroomiteBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroomite Buff");
            Description.SetDefault("Covered in Shrooms!");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            KnifeDamagePlayer p = KnifeDamagePlayer.ModPlayer(player);
            if (Main.rand.Next(50) == 5)
                p.KnifeDamage = p.KnifeDamage * Main.rand.Next(1,4);
            p.KnifeCrit = (int)(p.KnifeCrit * .01);
            player.GetModPlayer<VampPlayer>().ShroomiteBuff = true; 
        }
    }
}