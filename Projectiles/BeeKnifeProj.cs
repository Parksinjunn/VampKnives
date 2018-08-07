using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class BeeKnifeProj : KnifeProjectile
	{
		public override void SetDefaults()
		{
			projectile.Name = "Bee Knife";
			projectile.width = 16;
			projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
          		}

		public override void AI()
		{
                                                                //this is projectile dust
           int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width-3, projectile.height-3, 244, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.DarkRed, 1.8f);
           Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
			projectile.alpha = (int)projectile.localAI[0] * 2;
			
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            float ran1 = Main.rand.Next(-1, 1);
            float ran2 = Main.rand.Next(-1, 1);
            int random = Main.rand.Next(4,8);
            Player owner = Main.player[projectile.owner];
            n.AddBuff(32, 300); //Slow 5
            n.AddBuff(31, 120); //confused 2
            for (int x = 0; x <= random; x++)
            {
                if(owner.strongBees == true)
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, ran1, ran2, 566, projectile.damage, projectile.knockBack, Main.myPlayer);
                else
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, ran1, ran2, 181, projectile.damage, projectile.knockBack, Main.myPlayer);
            }
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("HealProj"), (int)(projectile.damage * 0.75), 0, owner.whoAmI);
            Hoods(n);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player owner = Main.player[projectile.owner];
            float ran1 = Main.rand.Next(-10, 10);
            float ran2 = Main.rand.Next(-10, 10);
            if (owner.strongBees == true)
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, ran1, ran2, 566, projectile.damage, projectile.knockBack, Main.myPlayer);
            else
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, ran1, ran2, 181, projectile.damage, projectile.knockBack, Main.myPlayer);
            return true;
        }
        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 3) //once the frameCounter has reached 3 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}