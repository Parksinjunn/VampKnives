using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class Lucario : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lucario");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bunny);
            projectile.netImportant = true;
            projectile.width = 66;
            projectile.height = 58;
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