using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class LucarioMinion : LucarioShooter
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targetting
		}

		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.Truffle);
            projectile.netImportant = true;
			projectile.width = 66;
			projectile.height = 58;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			inertia = 20f;
            shoot = ProjectileID.ChargedBlasterOrb;
            shootSpeed = 12f;
            aiType = ProjectileID.Truffle;
        }

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>(mod);
			if (player.dead)
			{
				modPlayer.lucario = false;
			}
			if (modPlayer.lucario)
			{
				projectile.timeLeft = 2;
			}
		}

		//public override void CreateDust()
		//{
		//	if (projectile.ai[0] == 0f)
		//	{
		//		if (Main.rand.Next(5) == 0)
		//		{
		//			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("PuriumFlame"));
		//			Main.dust[dust].velocity.Y -= 1.2f;
		//		}
		//	}
		//	else
		//	{
		//		if (Main.rand.Next(3) == 0)
		//		{
		//			Vector2 dustVel = projectile.velocity;
		//			if (dustVel != Vector2.Zero)
		//			{
		//				dustVel.Normalize();
		//			}
		//			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("PuriumFlame"));
		//			Main.dust[dust].velocity -= 1.2f * dustVel;
		//		}
		//	}
		//	Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
		//}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame-1) % 2;
			}
		}
	}
}