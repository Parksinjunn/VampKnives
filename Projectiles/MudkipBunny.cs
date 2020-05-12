using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
    public class MudkipBunny : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mudkip");
            Main.projFrames[projectile.type] = 7;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bunny);
            projectile.netImportant = true;
            projectile.width = 36;
            projectile.height = 32;
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
				modPlayer.Mudkip = false;
			}
			if (modPlayer.Mudkip)
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