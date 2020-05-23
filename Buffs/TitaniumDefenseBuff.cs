using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using VampKnives.NPCs;
using VampKnives.Projectiles.DefenseKnivesProj;

namespace VampKnives.Buffs
{
    public class TitaniumDefenseBuff : ModBuff
    {
        public int Timer;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Titanium Barrier");
            Description.SetDefault("Surrounded by titanium shards");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if(ProjCount.GetActiveTitanium() < 8 * Main.ActivePlayersCount)
            {
                Timer++;
                if(Timer > 17)
                {
                    Projectile.NewProjectile(player.position, new Vector2(0f, 0f), ModContent.ProjectileType<Projectiles.DefenseKnivesProj.TitaniumDefenseProj>(), 12, 60, player.whoAmI);
                    ProjCount.NumActiveTitanium++;
                    Timer = 0;
                }
            }
        }
    }
}