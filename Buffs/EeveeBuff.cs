using Terraria;
using Terraria.ModLoader;

namespace VampKnives.Buffs
{
    public class EeveeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Eevee!");
            Description.SetDefault("A creature of many forms protects you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ExamplePlayer>().Eevee = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("EBunny")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 3), player.position.Y + (float)(player.height / 3), 0f, 0f, mod.ProjectileType("EBunny"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}