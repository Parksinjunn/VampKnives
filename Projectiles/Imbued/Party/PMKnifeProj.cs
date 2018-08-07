using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Projectiles.Imbued.Party
{
	public class PMKnifeProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.Name = "PM Knife";
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
           int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width-3, projectile.height-3, 244, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Pink, 1.8f);
           Main.dust[DustID2].noGravity = true;
                                                          //this make that the projectile faces the right way 
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            //projectile.light = .04f;
			//projectile.alpha = (int)projectile.localAI[0] * 2;
			
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            n.AddBuff(69, 300); //PM! debuff for 5 seconds
            int healamnt = (int)(projectile.damage * .075);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 305, 0, projectile.knockBack); //Creates a new Projectile
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 289, 0, projectile.knockBack); //Creates a new Projectile
            int DustID4 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 254, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Pink, 1.8f);
            Main.PlaySound(SoundID.Item85, projectile.position);
            owner.statLife += healamnt; //Gives 7.5% of the damage dealt
            owner.HealEffect(healamnt, true); //Shows you have healed by that amount of health
            owner.statMana += healamnt;
            owner.ManaEffect(healamnt);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 289, 0, projectile.knockBack); //Creates a new Projectile
            int DustID4 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width - 3, projectile.height - 3, 254, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 10, Color.Pink, 1.8f);
            Main.PlaySound(SoundID.Item85, projectile.position);
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