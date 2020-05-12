using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class Arcanine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcanine");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bunny);
            projectile.netImportant = true;
            projectile.width = 40;
            projectile.height = 42;
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
				modPlayer.Arcanine = false;
			}
			if (modPlayer.Arcanine)
			{
				projectile.timeLeft = 2;
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int DustID2 = Dust.NewDust(new Vector2(projectile.position.X+35, projectile.position.Y + 36), 2, 2, 158, projectile.velocity.X * 0.2f, projectile.velocity.Y-5, 10, Color.Red, 1f);
            int DustID3 = Dust.NewDust(new Vector2(projectile.position.X + 15, projectile.position.Y + 36), 2, 2, 158, projectile.velocity.X * 0.2f, projectile.velocity.Y - 5, 10, Color.Red, 1f);
            return true;
        }
        //public override bool MinionContactDamage()
        //{
        //    return true;
        //}
        //public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        //{
        //    Player owner = Main.player[projectile.owner];
        //    if (projectile.spriteDirection == -1)
        //    {
        //        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 8, 0, 409, 5, projectile.knockBack, Main.myPlayer);
        //    }
        //    else
        //    {
        //        Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -8, 0, 409, 5, projectile.knockBack, Main.myPlayer);
        //    }
        //}
    }
}