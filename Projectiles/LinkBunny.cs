using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class LinkBunny : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Link Bunny");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
            projectile.width = 40;
            projectile.height = 38;
            projectile.netImportant = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
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
				modPlayer.Link = false;
			}
			if (modPlayer.Link)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}