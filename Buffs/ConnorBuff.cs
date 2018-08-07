using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Buffs
{
    public class ConnorBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Connor's Spirit follows you");
            Description.SetDefault("Connor's Spirit follows you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ExamplePlayer>().hasMyBuff = true;
            player.GetModPlayer<ExamplePlayer>(mod).Connor = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("ConnorAnim")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("ConnorAnim"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}