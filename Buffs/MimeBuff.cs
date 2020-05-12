using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Buffs
{
    public class MimeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mr. Mime!");
            Description.SetDefault("A creature from a baguette prote... wait... no he doesn't...");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ExamplePlayer>().Mime = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("MrMime")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 3), player.position.Y + (float)(player.height / 3), 0f, 0f, mod.ProjectileType("MrMime"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}