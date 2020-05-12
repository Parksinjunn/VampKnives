using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Buffs
{
    public class LucarioBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lucario!");
            Description.SetDefault("A creature with the speed of a wyvern defends you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ExamplePlayer>().lucario = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Lucario")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 3), player.position.Y + (float)(player.height / 3), 0f, 0f, mod.ProjectileType("Lucario"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}