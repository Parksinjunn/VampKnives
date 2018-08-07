using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Imbued.JustMana
{
	public class MElementalKnivesProj : ModProjectile
	{
        public static int randInt(int min, int max)
        {

            // Usually this can be a field rather than a method variable
            Random rand = new Random();

            // nextInt is normally exclusive of the top value,
            // so add 1 to make it inclusive
            int randomNum = rand.Next(min, max);

            return randomNum;
        }
        public override void SetDefaults()
		{
			projectile.Name = "Elemental Knife";
			projectile.width = 16;
			projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 3;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 4;           //this is projectile frames
            projectile.hostile = false;
			projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = true;
            projectile.timeLeft = 300;
          		}
        public int element = randInt(1, 4);
		public override void AI()
		{
            if (element == 1)
            {
                //this is projectile dust
                int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 68, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Blue, 2f);
                int DustID3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 76, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.White, 1);
                Main.dust[DustID2].noGravity = true;
                Main.dust[DustID3].noGravity = false;
            }
            if(element == 2)
            {
                int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 127, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Red, 4f);
                Main.dust[DustID2].noGravity = true;
            }
            if(element ==3)
            {
                int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 133, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Yellow, 2f);
                Main.dust[DustID2].noGravity = true;
            }
            //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;	
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            projectile.position.X = n.position.X;
            projectile.position.Y = n.position.Y;
            projectile.velocity.X = n.velocity.X;
            projectile.velocity.Y = n.velocity.Y;
            if (element == 1)
            {
                n.AddBuff(44, 300); //Eleum! debuff for 5 seconds
                n.AddBuff(32, 60);
            }
            if(element == 2)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 612, 30, projectile.knockBack, Main.myPlayer);
            }
            if (element == 3)
            {
                n.AddBuff(24, 300); //Cinder! debuff for 5 seconds
                n.AddBuff(33, 120);
            }
            int healamnt = (int)(projectile.damage * .075);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 305, 0, projectile.knockBack); //Creates a new Projectile
            owner.statLife += healamnt; //Gives 7.5% of the damage dealt
            owner.HealEffect(healamnt, true); //Shows you have healed by that amount of health
            owner.statMana += healamnt;
            owner.ManaEffect(healamnt);
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