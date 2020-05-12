using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class ConnorAnim : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Connor");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Penguin);
            projectile.width = 45;
            projectile.height = 42;
			aiType = ProjectileID.Penguin;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.companionCube = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			if (player.dead)
			{
				modPlayer.Connor = false;
			}
			if (modPlayer.Connor)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}