using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class CobaltBunny : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Bunny");
			Main.projFrames[projectile.type] = 7;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
            projectile.width = 36;
            projectile.height = 28;
            projectile.position.Y -= 15;
			aiType = ProjectileID.Bunny;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			if (player.dead)
			{
				modPlayer.Cobalt = false;
			}
			if (modPlayer.Cobalt)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}