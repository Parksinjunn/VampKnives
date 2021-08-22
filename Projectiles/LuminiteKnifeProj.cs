using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles
{
	public class LuminiteKnifeProj : KnifeProjectile
	{
		public override void SafeSetDefaults()
		{
			projectile.Name = "Luminite Knife";
			projectile.width = 16;
			projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }
        int DustID2;
		public override void AI()
		{
                                                                //this is projectile dust
           DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width-3, projectile.height-3, 45, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.LightBlue, 1.8f);
           Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
            //Dust
			projectile.alpha = (int)projectile.localAI[0] * 2;
			
        }

        public override void SafeOnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            n.AddBuff(169, 300); //Bleeding! debuff for 5 seconds
            n.AddBuff(164, 60); //Distorted for 1 second
        }
        //int hit = 0;
        //public override bool OnTileCollide(Vector2 velocityChange)
        //{
        //    hit++;
        //    if (hit >= 1)
        //    {
        //        Main.dust[DustID2].alpha = 0;
        //        projectile.Kill();
        //    }
        //    return true;
        //}

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